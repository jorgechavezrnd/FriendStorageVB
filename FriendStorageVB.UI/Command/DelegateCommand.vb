Public Class DelegateCommand
    Implements ICommand

    Private ReadOnly m_execute As Action(Of Object)
    Private ReadOnly m_canExecute As Func(Of Object, Boolean)

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Sub New(execute As Action(Of Object), canExecute As Func(Of Object, Boolean))
        If execute Is Nothing Then
            Throw New ArgumentNullException(NameOf(execute))
        End If

        m_execute = execute
        m_canExecute = canExecute
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return m_canExecute Is Nothing OrElse m_canExecute(parameter)
    End Function

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        m_execute(parameter)
    End Sub

    Public Sub RaiseCanExecuteChanged()
        RaiseEvent CanExecuteChanged(Me, EventArgs.Empty)
    End Sub

End Class
