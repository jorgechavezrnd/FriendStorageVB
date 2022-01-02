Imports Prism.Events

Public Class NavigationItemViewModel

    Sub New(id As Integer, displayMember As String, eventAggregator As IEventAggregator)
        Me.Id = id
        Me.DisplayMember = displayMember
        OpenFriendEditViewCommand = New DelegateCommand(Sub(obj) OnFriendEditViewExecute(obj))
        m_eventAggregator = eventAggregator
    End Sub

    Private Sub OnFriendEditViewExecute(obj As Object)
        m_eventAggregator.GetEvent(Of OpenFriendEditViewEvent) _
            .Publish(Id)
    End Sub

    Public ReadOnly Property Id As Integer
    Public ReadOnly Property DisplayMember As String
    Public ReadOnly Property OpenFriendEditViewCommand As ICommand

    Private ReadOnly m_eventAggregator As IEventAggregator

End Class
