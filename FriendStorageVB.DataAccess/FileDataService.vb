Imports System.IO
Imports FriendStorageVB.Model
Imports Newtonsoft.Json

Public Class FileDataService
    Implements IDataService

    Private Const StorageFile As String = "Friends.json"

    Public Function GetFriendById(friendId As Integer) As [Friend] Implements IDataService.GetFriendById
        Dim friends = ReadFromFile()
        Return friends.Single(Function(f) f.Id = friendId)
    End Function

    Public Sub SaveFriend([friend] As [Friend]) Implements IDataService.SaveFriend
        If [friend].Id <= 0 Then
            InsertFriend([friend])
        Else
            UpdateFriend([friend])
        End If
    End Sub

    Public Sub DeleteFriend(friendId As Integer) Implements IDataService.DeleteFriend
        Dim friends = ReadFromFile()
        Dim existing = friends.Single(Function(f) f.Id = friendId)
        friends.Remove(existing)
        SaveToFile(friends)
    End Sub

    Public Function GetAllFriends() As IEnumerable(Of LookupItem) Implements IDataService.GetAllFriends
        Return ReadFromFile() _
            .Select(Function(f) New LookupItem With
            {
                .Id = f.Id,
                .DisplayMember = $"{f.FirstName} {f.LastName}"
            })
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Usually Service-Proxies are disposable. This method Is added as demo-purpose
        ' to show how to use an IDisposable in the client with a Func<T>. =>  Look for example at the FriendDataProvider-class
    End Sub

    Private Sub InsertFriend([friend] As [Friend])
        Dim friends = ReadFromFile()
        Dim maxFriendId = If(friends.Count = 0, 0, friends.Max(Function(f) f.Id))
        [friend].Id = maxFriendId + 1
        friends.Add([friend])
        SaveToFile(friends)
    End Sub

    Private Sub UpdateFriend([friend] As [Friend])
        Dim friends = ReadFromFile()
        Dim existing = friends.Single(Function(f) f.Id = [friend].Id)
        Dim indexOfExisting = friends.IndexOf(existing)
        friends.Insert(indexOfExisting, [friend])
        friends.Remove(existing)
        SaveToFile(friends)
    End Sub

    Private Sub SaveToFile(friendList As List(Of [Friend]))
        Dim json As String = JsonConvert.SerializeObject(friendList, Formatting.Indented)
        File.WriteAllText(StorageFile, json)
    End Sub

    Private Function ReadFromFile() As List(Of [Friend])
        If Not File.Exists(StorageFile) Then
            Return New List(Of [Friend]) From {
                New [Friend] With {
                    .Id = 1,
                    .FirstName = "Thomas",
                    .LastName = "Huber",
                    .Birthday = New DateTime(1980, 10, 28),
                    .IsDeveloper = True
                },
                New [Friend] With {
                    .Id = 2,
                    .FirstName = "Julia",
                    .LastName = "Huber",
                    .Birthday = New DateTime(1982, 10, 10)
                },
                New [Friend] With {
                    .Id = 3,
                    .FirstName = "Anna",
                    .LastName = "Huber",
                    .Birthday = New DateTime(2011, 5, 13)
                },
                New [Friend] With {
                    .Id = 4,
                    .FirstName = "Sara",
                    .LastName = "Huber",
                    .Birthday = New DateTime(2013, 2, 25)
                },
                New [Friend] With {
                    .Id = 5,
                    .FirstName = "Andreas",
                    .LastName = "Böhler",
                    .Birthday = New DateTime(1981, 1, 10),
                    .IsDeveloper = True
                },
                New [Friend] With {
                    .Id = 6,
                    .FirstName = "Urs",
                    .LastName = "Meier",
                    .Birthday = New DateTime(1970, 3, 5),
                    .IsDeveloper = True
                },
                New [Friend] With {
                    .Id = 7,
                    .FirstName = "Chrissi",
                    .LastName = "Heuberger",
                    .Birthday = New DateTime(1987, 7, 16)
                },
                New [Friend] With {
                    .Id = 8,
                    .FirstName = "Erkan",
                    .LastName = "Egin",
                    .Birthday = New DateTime(1983, 5, 23)
                }
            }
        End If

        Dim json As String = File.ReadAllText(StorageFile)
        Return JsonConvert.DeserializeObject(Of List(Of [Friend]))(json)
    End Function

End Class
