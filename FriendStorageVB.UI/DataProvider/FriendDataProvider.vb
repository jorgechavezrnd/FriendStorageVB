Imports FriendStorageVB.DataAccess
Imports FriendStorageVB.Model

Public Class FriendDataProvider
    Implements IFriendDataProvider

    Private ReadOnly m_dataServiceCreator As Func(Of IDataService)

    Sub New(dataServiceCreator As Func(Of IDataService))
        m_dataServiceCreator = dataServiceCreator
    End Sub

    Public Function GetFriendById(id As Integer) As [Friend] Implements IFriendDataProvider.GetFriendById
        Using dataService = m_dataServiceCreator()
            Return dataService.GetFriendById(id)
        End Using
    End Function

    Public Sub SaveFriend([friend] As [Friend]) Implements IFriendDataProvider.SaveFriend
        Using dataService = m_dataServiceCreator()
            dataService.SaveFriend([friend])
        End Using
    End Sub

    Public Sub DeleteFriend(id As Integer) Implements IFriendDataProvider.DeleteFriend
        Using dataService = m_dataServiceCreator()
            dataService.DeleteFriend(id)
        End Using
    End Sub

End Class
