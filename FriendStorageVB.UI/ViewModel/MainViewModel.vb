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
        CloseFriendTabCommand = New DelegateCommand(Sub(obj) OnCloseFriendTabExecute(obj))
    End Sub

    Private Sub OnCloseFriendTabExecute(obj As Object)
        Dim friendEditVm = CType(obj, IFriendEditViewModel)
        FriendEditViewModels.Remove(friendEditVm)
    End Sub

    Private Sub OnOpenFriendEditView(friendId As Integer)
        Dim friendEditVm = FriendEditViewModels.SingleOrDefault(Function(vm) vm.Friend.Id = friendId)
        If friendEditVm Is Nothing Then
            friendEditVm = m_friendEditVmCreator()
            FriendEditViewModels.Add(friendEditVm)
            friendEditVm.Load(friendId)
        End If
        SelectedFriendEditViewModel = friendEditVm
    End Sub

    Public Sub Load()
        NavigationViewModel.Load()
    End Sub

End Class
