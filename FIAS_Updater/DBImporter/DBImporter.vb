Imports System.Data
Imports System.Data.SqlClient
Imports System.Threading
Imports JANL.SQL

Public Class DBImporter
	Const UploadCount = 10000

	Public Shared Sub ImportAO(AO As AddressObjects, PP As IProgress(Of TaskProgress), CT As CancellationToken)
		Dim Count = 0
		'SQLCommands.UP_INSP_ImportTerroristPre().Execute()
		PP.Report(New TaskProgress("Чтение файла"))
		Using DT As New DataTable("S_AdrObj"),
			SQLBC = New SqlBulkCopy(SQLHelper.NewConnection())

			Dim Max = AO.Object.Count
			Dim ImportDate = Date.Parse(AO.UpdateDate)

			With DT.Columns
				.Add(New DataColumn With {.ColumnName = "AOGUID", .DataType = GetType(Guid)})
				.Add(New DataColumn With {.ColumnName = "ParentGUID", .DataType = GetType(Guid)})
				.Add(New DataColumn With {.ColumnName = "ParentGUIDMun", .DataType = GetType(Guid)})
				.Add(New DataColumn With {.ColumnName = "ExtraGUID", .DataType = GetType(Guid)})
				.Add(New DataColumn With {.ColumnName = "AOLevel", .DataType = GetType(Byte)})
				.Add(New DataColumn With {.ColumnName = "CODE", .DataType = GetType(String)})
				.Add(New DataColumn With {.ColumnName = "FormalName", .DataType = GetType(String)})
				.Add(New DataColumn With {.ColumnName = "ShortName", .DataType = GetType(String)})
			End With
			SQLBC.DestinationTableName = DT.TableName

			PP.Report(New TaskProgress("Импорт в БД"))
			For Each A In AO.Object
				Count += 1
				Dim R = DT.NewRow()
				R("AOGUID") = AsGUID(A.AOGUID)
				R("PARENTGUID") = AsGUID(A.PARENTGUID)
				R("ParentGUIDMun") = AsGUID(A.PARENTGUIDMUN)
				R("ExtraGUID") = AsGUID(A.EXTRAGUID)
				R("AOLevel") = A.AOLEVEL
				R("CODE") = A.CODE
				R("FormalName") = A.FORMALNAME
				R("ShortName") = A.SHORTNAME

				DT.Rows.Add(R)
				If DT.Rows.Count = UploadCount Then
					CT.ThrowIfCancellationRequested()
					SQLBC.WriteToServer(DT)
					DT.Clear()
					PP.Report(New TaskProgress(Count, Max))
				End If
			Next
			If DT.Rows.Count > 0 Then SQLBC.WriteToServer(DT)
			SQLBC.Close()

			PP.Report(New TaskProgress(Count, Max))
			'SQLCommands.UP_INSP_ImportTerroristPost(ImportDate).Execute()
			PP.Report(New TaskProgress("Импорт завершён"))
			Thread.Sleep(500)
		End Using

	End Sub

	Public Shared Sub ImportH(H As Houses, PP As IProgress(Of TaskProgress), CT As CancellationToken)
		Dim Count = 0
		'SQLCommands.UP_INSP_ImportTerroristPre().Execute()
		PP.Report(New TaskProgress("Чтение файла"))
		Using DT As New DataTable("S_House"),
			SQLBC = New SqlBulkCopy(SQLHelper.NewConnection())

			Dim Max = H.House.Count
			Dim ImportDate = Date.Parse(H.UpdateDate)

			With DT.Columns
				.Add(New DataColumn With {.ColumnName = "AOGUID", .DataType = GetType(Guid)})
				.Add(New DataColumn With {.ColumnName = "ExtraGUID", .DataType = GetType(Guid)})
				.Add(New DataColumn With {.ColumnName = "Buildings", .DataType = GetType(String)})
			End With
			SQLBC.DestinationTableName = DT.TableName

			PP.Report(New TaskProgress("Импорт в БД"))
			For Each A In H.House
				Count += 1
				Dim R = DT.NewRow()
				R("AOGUID") = AsGUID(A.AOGUID)
				R("ExtraGUID") = AsGUID(A.EXTRAGUID)
				R("Buildings") = A.BUILDINGS

				DT.Rows.Add(R)
				If DT.Rows.Count = UploadCount Then
					CT.ThrowIfCancellationRequested()
					SQLBC.WriteToServer(DT)
					DT.Clear()
					PP.Report(New TaskProgress(Count, Max))
				End If
			Next
			If DT.Rows.Count > 0 Then SQLBC.WriteToServer(DT)
			SQLBC.Close()

			PP.Report(New TaskProgress(Count, Max))
			'SQLCommands.UP_INSP_ImportTerroristPost(ImportDate).Execute()
			PP.Report(New TaskProgress("Импорт завершён"))
			Thread.Sleep(500)
		End Using

	End Sub

	Private Shared Function AsGUID(GUID As String) As Object
		If String.IsNullOrWhiteSpace(GUID) Then Return DBNull.Value
		Return New Guid(GUID)
	End Function

End Class