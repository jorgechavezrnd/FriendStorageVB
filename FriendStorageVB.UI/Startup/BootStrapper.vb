Imports Autofac
Imports FriendStorageVB.DataAccess
Imports Prism.Events

Public Class BootStrapper

    Public Function BootStrap() As IContainer
        Dim builder = New ContainerBuilder()

        builder.RegisterType(Of EventAggregator) _
            .As(Of IEventAggregator).SingleInstance()

        builder.RegisterType(Of MessageDialogService) _
            .As(Of IMessageDialogService)()

        builder.RegisterType(Of MainWindow).AsSelf()
        builder.RegisterType(Of MainViewModel).AsSelf()

        builder.RegisterType(Of FriendEditViewModel) _
            .As(Of IFriendEditViewModel)()

        builder.RegisterType(Of NavigationViewModel) _
            .As(Of INavigationViewModel)()

        builder.RegisterType(Of FriendDataProvider) _
            .As(Of IFriendDataProvider)()

        builder.RegisterType(Of NavigationDataProvider) _
            .As(Of INavigationDataProvider)()

        builder.RegisterType(Of FileDataService) _
            .As(Of IDataService)()

        Return builder.Build()
    End Function

End Class
