Public Class MainViewModel
    Inherits ViewModelBase

    Public ReadOnly Property NavigationViewModel As INavigationViewModel

    Sub New(navigationViewModel As INavigationViewModel)
        Me.NavigationViewModel = navigationViewModel
    End Sub

    Public Sub Load()
        NavigationViewModel.Load()
    End Sub

End Class
