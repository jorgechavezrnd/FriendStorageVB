Imports FriendStorageVB.Model

Public Interface IDataService
    Inherits IDisposable

    Function GetFriendById(friendId As Integer) As [Friend]
    Sub SaveFriend([friend] As [Friend])
    Sub DeleteFriend(friendId As Integer)
    Function GetAllFriends() As IEnumerable(Of [Friend])

End Interface
