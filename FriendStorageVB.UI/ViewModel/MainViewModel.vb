Public Class MainViewModel
    Inherits ViewModelBase

    Public ReadOnly Property NavigationViewModel As NavigationViewModel

    Sub New()
        NavigationViewModel = New NavigationViewModel()
    End Sub

    Public Sub Load()
        NavigationViewModel.Load()
    End Sub

End Class
