Public Class MessageDialogService
    Implements IMessageDialogService

    Public Function ShowYesNoDialog(title As String, message As String) As MessageDialogResult Implements IMessageDialogService.ShowYesNoDialog
        Return If(New YesNoDialog(title, message) With
            {
                .WindowStartupLocation = WindowStartupLocation.CenterOwner,
                .Owner = Application.Current.MainWindow
            }.ShowDialog().GetValueOrDefault(),
            MessageDialogResult.Yes,
            MessageDialogResult.No)
    End Function

End Class
