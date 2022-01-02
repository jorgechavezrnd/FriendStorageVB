Imports System.Collections.ObjectModel
Imports FriendStorageVB.Model

Public Interface INavigationViewModel

    Sub Load()

End Interface

Public Class NavigationViewModel
    Inherits ViewModelBase
    Implements INavigationViewModel

    Public ReadOnly Property Friends As ObservableCollection(Of LookupItem)

    Private ReadOnly m_dataProvider As INavigationDataProvider

    Sub New(dataProvider As INavigationDataProvider)
        Friends = New ObservableCollection(Of LookupItem)()
        m_dataProvider = dataProvider
    End Sub

    Public Sub Load() Implements INavigationViewModel.Load
        Friends.Clear()
        For Each lookupItem In m_dataProvider.GetAllFriends()
            Friends.Add(lookupItem)
        Next
    End Sub

End Class
