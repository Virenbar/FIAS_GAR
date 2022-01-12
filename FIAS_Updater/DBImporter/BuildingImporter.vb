Imports System.Data
Imports FIAS_Updater.DataHelper

Public Class BuildingImporter
	Inherits BaseDBImporter(Of List(Of Building))

	Public Sub New()
		MyBase.New("S_Building")
	End Sub

	Protected Overrides Sub FillDataTable(Source As List(Of Building))
		For Each S In Source
			Dim R = NewRow()
			R("AOGUID") = S.AOGUID
			R("ExtraGUID") = S.ExtraGUID
			R("BuildingGUID") = S.BuildingGUID
			R("Building") = S.Building
			R("ESTSTAT") = AsDBNull(S.ESTSTAT)
			R("Number") = AsDBNull(S.Number)
			R("NumberA1") = AsDBNull(S.NumberA1)
			R("STRSTAT") = AsDBNull(S.STRSTAT)
			R("NumberA2") = AsDBNull(S.NumberA2)
			InsertRow(R)
		Next
	End Sub

	Protected Overrides Function CreateDT() As DataTable
		Dim DT = New DataTable()
		With DT.Columns
			.Add(New DataColumn With {.ColumnName = "AOGUID", .DataType = GetType(Guid)})
			.Add(New DataColumn With {.ColumnName = "ExtraGUID", .DataType = GetType(Guid)})
			.Add(New DataColumn With {.ColumnName = "BuildingGUID", .DataType = GetType(Guid)})
			.Add(New DataColumn With {.ColumnName = "Building", .DataType = GetType(String)})
			.Add(New DataColumn With {.ColumnName = "ESTSTAT", .DataType = GetType(Byte)})
			.Add(New DataColumn With {.ColumnName = "Number", .DataType = GetType(String)})
			.Add(New DataColumn With {.ColumnName = "NumberA1", .DataType = GetType(String)})
			.Add(New DataColumn With {.ColumnName = "STRSTAT", .DataType = GetType(Byte)})
			.Add(New DataColumn With {.ColumnName = "NumberA2", .DataType = GetType(String)})
		End With
		Return DT
	End Function

End Class