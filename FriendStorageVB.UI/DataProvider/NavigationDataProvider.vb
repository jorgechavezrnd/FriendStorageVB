Imports FriendStorageVB.DataAccess
Imports FriendStorageVB.Model

Public Class NavigationDataProvider
    Implements INavigationDataProvider

    Private ReadOnly m_dataServiceCreator As Func(Of IDataService)

    Sub New(dataServiceCreator As Func(Of IDataService))
        m_dataServiceCreator = dataServiceCreator
    End Sub

    Public Function GetAllFriends() As IEnumerable(Of LookupItem) Implements INavigationDataProvider.GetAllFriends
        Using dataService = m_dataServiceCreator()
            Return dataService.GetAllFriends()
        End Using
    End Function

End Class
