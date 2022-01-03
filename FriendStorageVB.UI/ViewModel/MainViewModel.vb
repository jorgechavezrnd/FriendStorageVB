Imports System.Collections.ObjectModel
Imports Prism.Events

Public Class MainViewModel
    Inherits ViewModelBase

    Private m_selectedFriendEditViewModel As IFriendEditViewModel
    Private ReadOnly m_friendEditVmCreator As Func(Of IFriendEditViewModel)

    Public ReadOnly Property NavigationViewModel As INavigationViewModel
    Public ReadOnly Property FriendEditViewModels As ObservableCollection(Of IFriendEditViewModel)
    Public Property SelectedFriendEditViewModel As IFriendEditViewModel
        Get
            Return m_selectedFriendEditViewModel
        End Get
        Set(value As IFriendEditViewModel)
            m_selectedFriendEditViewModel = value
            OnPropertyChanged()
        End Set
    End Property

    Private m_addFriendCommand As ICommand
    Public Property AddFriendCommand As ICommand
        Get
            Return m_addFriendCommand
        End Get
        Private Set(value As ICommand)
            m_addFriendCommand = value
        End Set
    End Property

    Private m_closeFriendTabCommand As ICommand
    Public Property CloseFriendTabCommand As ICommand
        Get
            Return m_closeFriendTabCommand
        End Get
        Private Set(value As ICommand)
            m_closeFriendTabCommand = value
        End Set
    End Property

    Sub New(navigationViewModel As INavigationViewModel,
            friendEditVmCreator As Func(Of IFriendEditViewModel),
            eventAggregator As IEventAggregator)
        Me.NavigationViewModel = navigationViewModel
        FriendEditViewModels = New ObservableCollection(Of IFriendEditViewModel)
        m_friendEditVmCreator = friendEditVmCreator
        eventAggregator.GetEvent(Of OpenFriendEditViewEvent).Subscribe(Sub(friendId) OnOpenFriendEditView(friendId))
        eventAggregator.GetEvent(Of FriendDeletedEvent).Subscribe(Sub(friendId) OnFriendDeleted(friendId))
        CloseFriendTabCommand = New DelegateCommand(Sub(obj) OnCloseFriendTabExecute(obj))
        AddFriendCommand = New DelegateCommand(Sub(obj) OnAddFriendExecute(obj))
    End Sub

    Private Sub OnFriendDeleted(friendId As Integer)
        Dim friendEditVm = FriendEditViewModels.Single(Function(vm) vm.Friend.Id = friendId)
        FriendEditViewModels.Remove(friendEditVm)
    End Sub

    Private Sub OnCloseFriendTabExecute(obj As Object)
        Dim friendEditVm = CType(obj, IFriendEditViewModel)
        FriendEditViewModels.Remove(friendEditVm)
    End Sub

    Private Sub OnAddFriendExecute(obj As Object)
        SelectedFriendEditViewModel = CreateAndLoadFriendEditViewModel(Nothing)
    End Sub

    Private Function CreateAndLoadFriendEditViewModel(friendId As Integer?) As IFriendEditViewModel
        Dim friendEditVm = m_friendEditVmCreator()
        FriendEditViewModels.Add(friendEditVm)
        friendEditVm.Load(friendId)
        Return friendEditVm
    End Function

    Private Sub OnOpenFriendEditView(friendId As Integer)
        Dim friendEditVm = FriendEditViewModels.SingleOrDefault(Function(vm) vm.Friend.Id = friendId)
        If friendEditVm Is Nothing Then
            friendEditVm = CreateAndLoadFriendEditViewModel(friendId)
        End If
        SelectedFriendEditViewModel = friendEditVm
    End Sub

    Public Sub Load()
        NavigationViewModel.Load()
    End Sub

End Class
