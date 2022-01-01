Class MainWindow

    Private m_viewModel As MainViewModel

    Sub New(viewModel As MainViewModel)
        InitializeComponent()
        AddHandler Loaded, Sub() MainWindow_Loaded()
        m_viewModel = viewModel
        DataContext = m_viewModel
    End Sub

    Private Sub MainWindow_Loaded()
        m_viewModel.Load()
    End Sub

End Class
