Imports System.ComponentModel
Imports FriendStorageVB.Model
Imports Prism.Events

Public Interface IFriendEditViewModel

    Sub Load(friendId As Integer?)
    Property [Friend] As FriendWrapper

End Interface

Public Class FriendEditViewModel
    Inherits ViewModelBase
    Implements IFriendEditViewModel

    Private ReadOnly m_dataProvider As IFriendDataProvider
    Private ReadOnly m_eventAggregator As IEventAggregator
    Private m_friend As FriendWrapper

    Sub New(dataProvider As IFriendDataProvider,
            eventAggregator As IEventAggregator)
        m_dataProvider = dataProvider
        m_eventAggregator = eventAggregator
        SaveCommand = New DelegateCommand(Sub(obj) OnSaveExecute(obj), Function(arg) OnSaveCanExecute(arg))
    End Sub

    Private m_saveCommand As ICommand
    Public Property SaveCommand As ICommand
        Get
            Return m_saveCommand
        End Get
        Private Set(value As ICommand)
            m_saveCommand = value
        End Set
    End Property

    Public Property [Friend] As FriendWrapper Implements IFriendEditViewModel.Friend
        Get
            Return m_friend
        End Get
        Set(value As FriendWrapper)
            m_friend = value
            OnPropertyChanged()
        End Set
    End Property

    Public Sub Load(friendId As Integer?) Implements IFriendEditViewModel.Load
        Dim [friend] = If(friendId.HasValue,
                          m_dataProvider.GetFriendById(friendId),
                          New [Friend])

        Me.Friend = New FriendWrapper([friend])

        AddHandler Me.Friend.PropertyChanged, Sub(sender, e) Friend_PropertyChanged(sender, e)

        CType(SaveCommand, DelegateCommand).RaiseCanExecuteChanged()
    End Sub

    Private Sub Friend_PropertyChanged(sender As Object, e As PropertyChangedEventArgs)
        CType(SaveCommand, DelegateCommand).RaiseCanExecuteChanged()
    End Sub

    Private Sub OnSaveExecute(obj As Object)
        m_dataProvider.SaveFriend([Friend].Model)
        [Friend].AcceptChanges()
        m_eventAggregator.GetEvent(Of FriendSavedEvent).Publish([Friend].Model)
    End Sub

    Private Function OnSaveCanExecute(arg As Object) As Boolean
        Return [Friend] IsNot Nothing AndAlso [Friend].IsChanged
    End Function

End Class
