Imports System.Collections.ObjectModel
Imports FriendStorageVB.DataAccess
Imports FriendStorageVB.Model

Public Class NavigationViewModel
    Inherits ViewModelBase

    Public ReadOnly Property Friends As ObservableCollection(Of [Friend])

    Sub New()
        Friends = New ObservableCollection(Of [Friend])()
    End Sub

    Public Sub Load()
        Dim dataService = New FileDataService()

        For Each [friend] In dataService.GetAllFriends()
            Friends.Add([friend])
        Next
    End Sub

End Class
