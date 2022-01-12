Imports System.Threading
Imports System.Net
Imports System.Net.Http
Imports Newtonsoft.Json

Public Class FIASDownload
	Const FIASurl = "https://fias.nalog.ru/WebServices/Public/GetAllDownloadFileInfo"
	Private Shared ReadOnly HTTP As New HttpClient()
	Private Shared FilesList As List(Of FIASUpdate)
	Private Shared WithEvents WC As New WebClient
	Shared Property CurrentVersion As Integer
	Shared Property LastVersion As Integer

	'https://fias.nalog.ru/WebServices/Public/GetLastDownloadFileInfo
	'https://fias.nalog.ru/WebServices/Public/GetAllDownloadFileInfo
	Public Shared Sub GetDB()

	End Sub

	Public Shared Async Function GetFilesList() As Task
		Try
			Dim str = Await HTTP.GetStringAsync(FIASurl)
			FilesList = JsonConvert.DeserializeObject(Of List(Of FIASUpdate))(str)
		Catch

		End Try
	End Function

	'Private Shared Async Function DownloadFiles(progress As IProgress(Of Integer), ct As CancellationToken) As Task
	'For i = 0 To FilesList.GetUpperBound(0)
	'	Await WC.DownloadFileTaskAsync(New Uri(FilesList(i).FiasDeltaDbfUrl), "")
	'Next
	'ct.ThrowIfCancellationRequested()
	'End Function

End Class