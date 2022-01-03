Public Class YesNoDialog

    Sub New(title As String, message As String)
        InitializeComponent()
        Me.Title = title
        textBlock.Text = message
    End Sub

    Private Sub ButtonYes_Click(sender As Object, e As RoutedEventArgs)
        DialogResult = True
    End Sub

    Private Sub ButtonNo_Click(sender As Object, e As RoutedEventArgs)
        DialogResult = False
    End Sub

End Class
