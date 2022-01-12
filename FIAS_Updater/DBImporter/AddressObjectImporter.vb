Imports System.Data
Imports FIAS_Updater.DataHelper

Public Class AddressObjectImporter
	Inherits BaseDBImporter(Of AddressObjects)

	Public Sub New()
		MyBase.New("S_AddressObject")
	End Sub

	Protected Overrides Sub FillDataTable(Source As AddressObjects)
		For Each S In Source.Object
			Dim R = NewRow()
			R("AOGUID") = AsGUID(S.AOGUID)
			R("PARENTGUID") = AsGUID(S.PARENTGUID)
			R("ParentGUIDMun") = AsGUID(S.PARENTGUIDMUN)
			R("ExtraGUID") = AsGUID(S.EXTRAGUID)
			R("AOLevel") = S.AOLEVEL
			R("CODE") = S.CODE
			R("FormalName") = S.FORMALNAME
			R("ShortName") = S.SHORTNAME
			InsertRow(R)
		Next
	End Sub

	Protected Overrides Function CreateDT() As DataTable
		Dim DT = New DataTable()
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
		Return DT
	End Function

	Private Shared Function AsGUID(GUID As String) As Object
		If String.IsNullOrWhiteSpace(GUID) Then Return DBNull.Value
		Return New Guid(GUID)
	End Function

End Class