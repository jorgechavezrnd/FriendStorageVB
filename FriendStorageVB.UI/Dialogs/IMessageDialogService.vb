Public Interface IMessageDialogService

    Function ShowYesNoDialog(title As String, message As String) As MessageDialogResult

End Interface

Public Enum MessageDialogResult
    Yes
    No
End Enum
