Imports FriendStorageVB.Model

Public Interface IFriendDataProvider

    Function GetFriendById(id As Integer) As [Friend]
    Sub SaveFriend([friend] As [Friend])
    Sub DeleteFriend(id As Integer)

End Interface
