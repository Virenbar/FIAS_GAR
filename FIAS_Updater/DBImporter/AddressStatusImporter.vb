Imports System.Data
Imports FIAS_Updater.DataHelper

Public Class AddressStatusImporter
	Inherits BaseDBImporter(Of AddressStatuses)

	Public Sub New()
		MyBase.New("S_AddressStatus")
	End Sub

	Protected Overrides Sub FillDataTable(Source As AddressStatuses)
		For Each S In Source.AddressStatus
			Dim R = NewRow()
			R("Type") = S.TYPE
			R("ID") = S.ID
			R("Key") = S.KEY
			R("Value") = S.VALUE
			InsertRow(R)
		Next
	End Sub

	Protected Overrides Function CreateDT() As DataTable
		Dim DT = New DataTable()
		With DT.Columns
			.Add(New DataColumn With {.ColumnName = "Type", .DataType = GetType(String)})
			.Add(New DataColumn With {.ColumnName = "ID", .DataType = GetType(Integer)})
			.Add(New DataColumn With {.ColumnName = "Key", .DataType = GetType(String)})
			.Add(New DataColumn With {.ColumnName = "Value", .DataType = GetType(String)})
		End With
		Return DT
	End Function

End Class