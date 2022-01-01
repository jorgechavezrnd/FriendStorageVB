Class Application

    Protected Overrides Sub OnStartup(e As StartupEventArgs)
        MyBase.OnStartup(e)

        Dim mainWindow = New MainWindow(New MainViewModel())
        mainWindow.Show()
    End Sub

End Class
