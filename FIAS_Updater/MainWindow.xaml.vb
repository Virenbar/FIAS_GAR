Class MainWindow

	Private Async Sub B_GetFiles_Click(sender As Object, e As RoutedEventArgs) Handles B_GetFiles.Click
		Await FIASDownload.GetFilesList()
	End Sub

	Private Sub MI_ReadFI_Click(sender As Object, e As RoutedEventArgs) Handles MI_ReadFI.Click
		FIAS1C.Read()
	End Sub

	Private Sub MI_Decompress_Click(sender As Object, e As RoutedEventArgs) Handles MI_Decompress.Click
		FIAS1C.DecompressFI()
	End Sub

End Class