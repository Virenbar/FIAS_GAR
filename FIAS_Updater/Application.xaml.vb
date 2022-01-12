Class Application

	Private Sub Application_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
		JANL.SQL.SQLHelper.DefaultConn = "Data Source=RYBAKOVAV;Initial Catalog=FIAS1C;Integrated Security=true"
	End Sub

	' События приложения, например, Startup, Exit и DispatcherUnhandledException,
	' можно обрабатывать в данном файле.

End Class