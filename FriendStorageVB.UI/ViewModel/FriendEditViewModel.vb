Imports FriendStorageVB.Model

Public Interface IFriendEditViewModel

    Sub Load(friendId As Integer)
    Property [Friend] As [Friend]

End Interface

Public Class FriendEditViewModel
    Inherits ViewModelBase
    Implements IFriendEditViewModel

    Private ReadOnly m_dataProvider As IFriendDataProvider
    Private m_friend As [Friend]

    Sub New(dataProvider As IFriendDataProvider)
        m_dataProvider = dataProvider
    End Sub

    Public Property [Friend] As [Friend] Implements IFriendEditViewModel.Friend
        Get
            Return m_friend
        End Get
        Set(value As [Friend])
            m_friend = value
            OnPropertyChanged()
        End Set
    End Property

    Public Sub Load(friendId As Integer) Implements IFriendEditViewModel.Load
        Dim [friend] = m_dataProvider.GetFriendById(friendId)
        Me.Friend = [friend]
    End Sub

End Class
