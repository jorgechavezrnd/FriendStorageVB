Imports System.Collections.ObjectModel
Imports FriendStorageVB.Model
Imports Prism.Events

Public Interface INavigationViewModel

    Sub Load()

End Interface

Public Class NavigationViewModel
    Inherits ViewModelBase
    Implements INavigationViewModel

    Public ReadOnly Property Friends As ObservableCollection(Of NavigationItemViewModel)

    Private ReadOnly m_dataProvider As INavigationDataProvider
    Private ReadOnly m_eventAggregator As IEventAggregator

    Sub New(dataProvider As INavigationDataProvider, eventAggregator As IEventAggregator)
        Friends = New ObservableCollection(Of NavigationItemViewModel)()
        m_dataProvider = dataProvider
        m_eventAggregator = eventAggregator
        m_eventAggregator.GetEvent(Of FriendSavedEvent).Subscribe(Sub([friend]) OnFriendSaved([friend]))
    End Sub

    Private Sub OnFriendSaved([friend] As [Friend])
        Dim displayMember = $"{[friend].FirstName} {[friend].LastName}"
        Dim navigationItem = Friends.SingleOrDefault(Function(n) n.Id = [friend].Id)
        If navigationItem IsNot Nothing Then
            navigationItem.DisplayMember = displayMember
        Else
            navigationItem = New NavigationItemViewModel([friend].Id, displayMember, m_eventAggregator)
            Friends.Add(navigationItem)
        End If
    End Sub

    Public Sub Load() Implements INavigationViewModel.Load
        Friends.Clear()
        For Each lookupItem In m_dataProvider.GetAllFriends()
            Friends.Add(New NavigationItemViewModel(lookupItem.Id, lookupItem.DisplayMember, m_eventAggregator))
        Next
    End Sub

End Class
