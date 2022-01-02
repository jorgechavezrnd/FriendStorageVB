Imports Autofac
Imports FriendStorageVB.DataAccess

Public Class BootStrapper

    Public Function BootStrap() As IContainer
        Dim builder = New ContainerBuilder()

        builder.RegisterType(Of MainWindow).AsSelf()
        builder.RegisterType(Of MainViewModel).AsSelf()

        builder.RegisterType(Of NavigationViewModel) _
            .As(Of INavigationViewModel)()

        builder.RegisterType(Of NavigationDataProvider) _
            .As(Of INavigationDataProvider)()

        builder.RegisterType(Of FileDataService) _
            .As(Of IDataService)()

        Return builder.Build()
    End Function

End Class
