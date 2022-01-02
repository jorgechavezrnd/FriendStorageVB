Imports Autofac

Class Application

    Protected Overrides Sub OnStartup(e As StartupEventArgs)
        MyBase.OnStartup(e)

        Dim bootStrapper = New BootStrapper()
        Dim container = bootStrapper.BootStrap()

        Dim mainWindow = container.Resolve(Of MainWindow)
        mainWindow.Show()
    End Sub

End Class
