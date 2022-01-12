Imports System.Data
Imports System.Data.SqlClient
Imports System.Threading
Imports JANL.SQL

Public MustInherit Class BaseDBImporter(Of T)
	Implements IDisposable

	Protected CT As CancellationToken
	Protected Max As Integer
	Protected PP As IProgress(Of TaskProgress)
	Private Const UploadCount = 10000
	Private Count As Integer
	Private DT As DataTable
	Private SQLBC As SqlBulkCopy

	Public Sub New(TableName As String)
		DT = CreateDT()
		SQLBC = New SqlBulkCopy(SQLHelper.NewConnection()) With {.DestinationTableName = TableName}
	End Sub

	Public Sub Import(Source As T, PP As IProgress(Of TaskProgress), CT As CancellationToken)
		Me.PP = PP
		Me.CT = CT
		PP.Report(New TaskProgress("Подготовка"))
		PreImport(Source)
		PP.Report(New TaskProgress("Чтение файла"))

		'Dim Max = AO.Object.Count
		FillDataTable(Source)
		If DT.Rows.Count > 0 Then SQLBC.WriteToServer(DT)

		PP.Report(New TaskProgress("Завершение", Count, Max))
		PostImport(Source)
		PP.Report(New TaskProgress("Импорт завершён"))
		Thread.Sleep(500)
	End Sub

	Protected MustOverride Function CreateDT() As DataTable

	Protected MustOverride Sub FillDataTable(Source As T)

	Protected Sub InsertRow(R As DataRow)
		DT.Rows.Add(R)
		Count += 1
		If DT.Rows.Count = UploadCount Then
			PP.Report(New TaskProgress("Импорт в БД"))
			CT.ThrowIfCancellationRequested()
			SQLBC.WriteToServer(DT)
			DT.Clear()
			PP.Report(New TaskProgress(Count, Max))
		End If
	End Sub

	Protected Function NewRow() As DataRow
		Return DT.NewRow()
	End Function

	Protected Overridable Sub PostImport(Source As T)
	End Sub

	Protected Overridable Sub PreImport(Source As T)
	End Sub

#Region "IDisposable Support"
	Private disposedValue As Boolean ' Для определения избыточных вызовов

	' Этот код добавлен редактором Visual Basic для правильной реализации шаблона высвобождаемого класса.
	Public Sub Dispose() Implements IDisposable.Dispose
		' Не изменяйте этот код. Разместите код очистки выше в методе Dispose(disposing As Boolean).
		Dispose(True)
		' TODO: раскомментировать следующую строку, если Finalize() переопределен выше.
		' GC.SuppressFinalize(Me)
	End Sub

	' IDisposable
	Protected Overridable Sub Dispose(disposing As Boolean)
		If Not disposedValue Then
			If disposing Then
				DT.Dispose()
				SQLBC.Close()
			End If

			' TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже Finalize().
			' TODO: задать большим полям значение NULL.
		End If
		disposedValue = True
	End Sub

	' TODO: переопределить Finalize(), только если Dispose(disposing As Boolean) выше имеет код для освобождения неуправляемых ресурсов.
	'Protected Overrides Sub Finalize()
	'    ' Не изменяйте этот код. Разместите код очистки выше в методе Dispose(disposing As Boolean).
	'    Dispose(False)
	'    MyBase.Finalize()
	'End Sub
#End Region

End Class