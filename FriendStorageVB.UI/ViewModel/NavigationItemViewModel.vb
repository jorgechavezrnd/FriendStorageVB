Imports Prism.Events

Public Class NavigationItemViewModel
    Inherits ViewModelBase

    Private m_displayMember As String
    Private ReadOnly m_eventAggregator As IEventAggregator

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
    Public ReadOnly Property OpenFriendEditViewCommand As ICommand

    Public Property DisplayMember As String
        Get
            Return m_displayMember
        End Get
        Set(value As String)
            m_displayMember = value
            OnPropertyChanged()
        End Set
    End Property

End Class
