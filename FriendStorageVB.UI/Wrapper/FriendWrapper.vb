Imports System.Runtime.CompilerServices
Imports FriendStorageVB.Model

Public Class FriendWrapper
    Inherits ViewModelBase

    Private ReadOnly m_friend As [Friend]
    Private m_isChanged As Boolean

    Sub New([friend] As [Friend])
        m_friend = [friend]
    End Sub

    Public ReadOnly Property Model As [Friend]
        Get
            Return m_friend
        End Get
    End Property

    Public Property IsChanged As Boolean
        Get
            Return m_isChanged
        End Get
        Private Set(value As Boolean)
            m_isChanged = value
            OnPropertyChanged()
        End Set
    End Property

    Public Sub AcceptChanges()
        IsChanged = False
    End Sub

    Public ReadOnly Property Id As Integer
        Get
            Return m_friend.Id
        End Get
    End Property

    Public Property FirstName As String
        Get
            Return m_friend.FirstName
        End Get
        Set(value As String)
            m_friend.FirstName = value
            OnPropertyChanged()
        End Set
    End Property

    Public Property LastName As String
        Get
            Return m_friend.LastName
        End Get
        Set(value As String)
            m_friend.LastName = value
            OnPropertyChanged()
        End Set
    End Property

    Public Property Birthday As DateTime?
        Get
            Return m_friend.Birthday
        End Get
        Set(value As DateTime?)
            m_friend.Birthday = value
            OnPropertyChanged()
        End Set
    End Property

    Public Property IsDeveloper As Boolean
        Get
            Return m_friend.IsDeveloper
        End Get
        Set(value As Boolean)
            m_friend.IsDeveloper = value
            OnPropertyChanged()
        End Set
    End Property

    Protected Overrides Sub OnPropertyChanged(<CallerMemberName> Optional propertyName As String = Nothing)
        MyBase.OnPropertyChanged(propertyName)
        If propertyName <> NameOf(IsChanged) Then
            IsChanged = True
        End If
    End Sub

End Class
