Imports System.Data
Imports System.IO
Imports System.Threading
Imports System.Xml
Imports System.Xml.Serialization
Imports LiquidTechnologies.FastInfoset

Public Class FIAS1C
	Const GAR_XSD = "D:\Data\FIAS_GAR\gar_schemas"
	Const ASS = "D:\Data\FIASs\66"
	Const ASSD = ASS + "\Decoded"
	'Private Path

	Public Shared Sub MakeTables()
		Dim DS = New DataSet("GAR")
		For Each XSD In Directory.EnumerateFiles(GAR_XSD)
			DS.ReadXmlSchema(XSD)
		Next
		Dim C = DS.Tables.Count

		'Dim f = New DataTable("ADDRESSOBJECTS")
		'f.ReadXmlSchema(XSD)
		'Dim c = f.Columns.Count
	End Sub

	Public Sub New(Path As String, ConString As String)

	End Sub

	Public Shared Sub Read()
		MakeTables()
		'ReadADDROBJ()
		'ReadHOUSE()
		'ReadBuildings()
		'ReadStatuses()

	End Sub

	Public Shared Sub ReadBuildings()
		Dim HOUSE = $"{ASS}\66_HOUSE.FI"
		Dim Buildings As List(Of Building)
		Using FIReader = XmlReader.Create(New FIReader(HOUSE), Nothing)
			Dim H As Houses = DirectCast(New XmlSerializer(GetType(Houses)).Deserialize(FIReader), Houses)
			Buildings = H.House.AsParallel.SelectMany(Function(x) Building.FromHouses(x)).ToList()
		End Using

		Using BI = New BuildingImporter()
			BI.Import(Buildings, New Progress(Of TaskProgress), CancellationToken.None)
		End Using

	End Sub

	Public Shared Sub ReadStatuses()
		Dim ADDRSTATUS = $"{ASS}\ADDRSTATUS.FI"

		Using FIReader = XmlReader.Create(New FIReader(ADDRSTATUS), Nothing), SI = New AddressStatusImporter()
			Dim H = DirectCast(New XmlSerializer(GetType(AddressStatuses)).Deserialize(FIReader), AddressStatuses)
			SI.Import(H, New Progress(Of TaskProgress), CancellationToken.None)
		End Using
	End Sub

	Public Shared Sub ReadHOUSE()
		Dim HOUSE = $"{ASS}\66_HOUSE.FI"
		Dim doc As XmlDocument = New XmlDocument()

		' Read a Fast Infoset encoded file into an XmlDocument using FIReader
		Dim FIReader = XmlReader.Create(New FIReader(HOUSE), Nothing)
		Dim H As Houses = DirectCast(New XmlSerializer(GetType(Houses)).Deserialize(FIReader), Houses)
		H.House.AsParallel.ForAll(
			Sub(x)
				x.AOGUID = Base64ToGUID(x.AOGUID)
				x.EXTRAGUID = Base64ToGUID(x.EXTRAGUID)
			End Sub)
		DBImporter.ImportH(H, New Progress(Of TaskProgress), CancellationToken.None)
		FIReader.Close()

		FIReader = XmlReader.Create(New FIReader(HOUSE), Nothing)
		doc.Load(FIReader)
		For Each C As XmlNode In doc.FirstChild.ChildNodes
			C.Attributes("AOGUID").Value = Base64ToGUID(C.Attributes("AOGUID").Value)
			C.Attributes("EXTRAGUID").Value = Base64ToGUID(C.Attributes("EXTRAGUID").Value)
		Next
		doc.Save($"{ASSD}\HOUSE.XML")
		FIReader.Close()
	End Sub

	Public Shared Sub ReadADDROBJ()
		Dim ADDROBJ = $"{ASS}\66_ADDROBJ.FI"
		Dim doc As XmlDocument = New XmlDocument()

		' Read a Fast Infoset encoded file into an XmlDocument using FIReader
		Dim FIReader = XmlReader.Create(New FIReader(ADDROBJ), Nothing)
		Dim AO As AddressObjects = DirectCast(New XmlSerializer(GetType(AddressObjects)).Deserialize(FIReader), AddressObjects)
		Dim dd = Base64ToGUID(AO.Object(0).AOGUID)
		AO.Object.AsParallel.ForAll(
			Sub(x)
				x.AOGUID = Base64ToGUID(x.AOGUID)
				x.EXTRAGUID = Base64ToGUID(x.EXTRAGUID)
				x.PARENTGUID = Base64ToGUID(x.PARENTGUID)
				x.PARENTGUIDMUN = Base64ToGUID(x.PARENTGUIDMUN)
			End Sub)
		DBImporter.ImportAO(AO, New Progress(Of TaskProgress), Threading.CancellationToken.None)
		FIReader.Close()

		'Сохранение перекодированных
		FIReader = XmlReader.Create(New FIReader(ADDROBJ), Nothing)
		doc.Load(FIReader)
		For Each C As XmlNode In doc.FirstChild.ChildNodes
			C.Attributes("AOGUID").Value = Base64ToGUID(C.Attributes("AOGUID").Value)
			C.Attributes("EXTRAGUID").Value = Base64ToGUID(C.Attributes("EXTRAGUID").Value)
			C.Attributes("PARENTGUID").Value = Base64ToGUID(C.Attributes("PARENTGUID").Value)
			C.Attributes("PARENTGUIDMUN").Value = Base64ToGUID(C.Attributes("PARENTGUIDMUN").Value)
		Next
		doc.Save($"{ASSD}\ADDROBJ.XML")
		FIReader.Close()
	End Sub

	''' <summary>
	''' Распаковка FI, создание схемы XML и генерация классов для VB
	''' </summary>
	Public Shared Sub DecompressFI()
		Dim xsd = "C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.7.2 Tools\xsd.exe"
		Dim Files = Directory.GetFiles(ASS)
		For Each F In Files
			Dim FileName = Path.GetFileNameWithoutExtension(F)
			Dim CName = FileName.Replace("66_", "")
			Using FIReader = XmlReader.Create(New FIReader(F), Nothing)
				Dim XML As XmlDocument = New XmlDocument()
				XML.Load(FIReader)
				XML.Save($"{ASS}\XML\{FileName}.xml")
			End Using
			'создание схемы XML и генерация классов для VB
			Process.Start(xsd, $"{ASS}\XML\{FileName}.xml /out:{ASS}\XSD").WaitForExit()
			If FileName <> CName Then
				If File.Exists($"{ASS}\XSD\{CName}.xsd") Then File.Delete($"{ASS}\XSD\{CName}.xsd")
				File.Move($"{ASS}\XSD\{FileName}.xsd", $"{ASS}\XSD\{CName}.xsd")
			End If
			'генерация классов для VB
			Process.Start(xsd, $"{ASS}\XSD\{CName}.xsd /c /language:VB /out:{ASS}\VB").WaitForExit()
		Next
	End Sub

	Private Shared Function Base64ToGUID(str As String) As String
		Return DataHelper.Base64ToGUID(str).ToString
	End Function

End Class