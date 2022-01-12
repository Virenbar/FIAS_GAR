Public Class DataHelper

	Private Shared Function AsGUID(GUID As String) As Object
		If String.IsNullOrWhiteSpace(GUID) Then Return DBNull.Value
		Return New Guid(GUID)
	End Function

	Public Shared Function Base64ToGUID(str As String) As Guid
		If String.IsNullOrEmpty(str) Then Return Guid.Empty
		Return New Guid(FlipEndian(Convert.FromBase64String(str)))
	End Function

	''' <summary>
	''' Ъуъ Microsoft
	''' </summary>
	''' <remarks>
	''' В GUID первые 8 байт little-endian, остальные big-endian
	''' </remarks>
	Private Shared Function FlipEndian(Bytes As Byte()) As Byte()
		Dim BBytes = New Byte(15) {}
		For i As Integer = 8 To 15
			BBytes(i) = Bytes(i)
		Next
		'
		BBytes(3) = Bytes(0)
		BBytes(2) = Bytes(1)
		BBytes(1) = Bytes(2)
		BBytes(0) = Bytes(3)
		'
		BBytes(5) = Bytes(4)
		BBytes(4) = Bytes(5)
		'
		BBytes(6) = Bytes(7)
		BBytes(7) = Bytes(6)

		Return BBytes
	End Function

	Public Shared Function NByte(str As String) As Byte?
		If String.IsNullOrWhiteSpace(str) Then Return Nothing
		Return CByte(str)
	End Function

	Public Shared Function AsDBNull(O As Object) As Object
		If O IsNot Nothing AndAlso O.ToString.Length = 0 Then O = Nothing
		If IsNumeric(O) AndAlso CLng(O) = 0 Then O = Nothing
		Return If(O, DBNull.Value)
	End Function

End Class