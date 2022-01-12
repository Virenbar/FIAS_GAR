Imports System.Text.RegularExpressions
Imports FIAS_Updater.DataHelper

Public Class Building

	''' <summary>
	''' Some magic
	''' </summary>
	Private Shared ReadOnly R As New Regex("^(?<s1>\d)(?<n>[^~]*)(~(?<a1>\d*)?(~(?<s2>\d)~(?<a2>.+))?)?$", RegexOptions.Compiled)

	Public Property AOGUID As Guid
	Public Property ExtraGUID As Guid
	Public Property BuildingGUID As Guid
	Public Property Building As String
	Public Property ESTSTAT As Byte?
	Public Property Number As String
	Public Property NumberA1 As String
	Public Property STRSTAT As Byte?
	Public Property NumberA2 As String

	Public Shared Function FromHouses(Houses As HousesHouse) As List(Of Building)
		Dim AOGUID = Base64ToGUID(Houses.AOGUID)
		Dim ExtraGUID = Base64ToGUID(Houses.EXTRAGUID)
		Dim Builds = New List(Of Building)
		Dim Strings = Houses.BUILDINGS.Split(ControlChars.Tab)
		For Each Item In Strings
			Dim GUID = Base64ToGUID(Item.Substring(0, 24))
			Dim Building = Item.Substring(24)

			Dim M = R.Match(Building)
			If M.Success Then
				Dim Build = New Building() With {
					.AOGUID = AOGUID,
					.ExtraGUID = ExtraGUID,
					.BuildingGUID = GUID,
					.Building = Building,
					.ESTSTAT = NByte(M.Groups("s1").Value),
					.Number = M.Groups("n").Value,
					.NumberA1 = M.Groups("a1").Value,
					.STRSTAT = NByte(M.Groups("s2").Value),
					.NumberA2 = M.Groups("a2").Value}
				Builds.Add(Build)
			Else
				Throw New Exception("Не удалось распознать адрес")
			End If
		Next
		Return Builds
	End Function

End Class