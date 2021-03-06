﻿

Class MainWindow
    Public Property db As New Database

    ''TODO: Get Activities_Cache to use db.Activities.Local Somehow
    'Public Property Activities_Cache As ObjectModel.ObservableCollection(Of Activity) = db.Activities.Local

    Private Sub window_Loaded(sender As Object, e As RoutedEventArgs) Handles window.Loaded
        db.Database.CreateIfNotExists()
        db.Timelines.ToList() '<- This loads data into the Local property
        db.Activities.ToList()
        cbxActivities.ItemsSource = db.Activities.Local
    End Sub

    Private Sub btnSeed_Click(sender As Object, e As RoutedEventArgs) Handles btnSeed.Click
        Environment.GetEnvironmentVariable("DataDirectory")
        db.Database.Delete()
        db.Database.Create()
        Dim Database_Location = db.Database.SqlQuery(Of String)("SELECT physical_name  FROM sys.database_files WHERE [type] = 0").First

        db.Activities.AddRange({
            New Activity With {.Name = "Bed"},
            New Activity With {.Name = "Chat"},
            New Activity With {.Name = "Chatango", .Description = "Tasks, generally routine, that are unpleasant but necessary task and not categoried anywhere else"},
            New Activity With {.Name = "Chores"},
            New Activity With {.Name = "Food", .Description = "Eating food and dinning activities"},
            New Activity With {.Name = "Home", .Description = "This represents me arriving at home"},
            New Activity With {.Name = "Misc"},
            New Activity With {.Name = "Nap"},
            New Activity With {.Name = "Programming", .Description = "Doing any programming that is not considered work"},
            New Activity With {.Name = "Video Games"},
            New Activity With {.Name = "Videos", .Description = "Watching video/visual entertainment"},
            New Activity With {.Name = "Volunteering", .Description = "A person who voluntarily offers himself or herself for a service or undertaking"},
            New Activity With {.Name = "Woke Up"},
            New Activity With {.Name = "Work", .Description = "Represents me doing work for money (Unless otherwise stated)"}
        })

        db.SaveChanges()

        Dim Activities = db.Activities.ToList
        db.Timelines.AddRange({
            New Timeline With {.Time = New Date(2016, 8, 16, 7, 20, 0), .Activity = Activities.First(Function(x) x.Name = "Woke Up")},
            New Timeline With {.Time = New Date(2016, 8, 16, 7, 45, 0), .Activity = Activities.First(Function(x) x.Name = "Work")},
            New Timeline With {.Time = New Date(2016, 8, 16, 17, 45, 0), .Activity = Activities.First(Function(x) x.Name = "Home")}
        })

        db.SaveChanges()
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As RoutedEventArgs) Handles btnLoad.Click

    End Sub

    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs) Handles btnSave.Click
        db.SaveChanges()
    End Sub

    Private Sub dgdTimeline_InitializingNewItem(sender As Object, e As InitializingNewItemEventArgs) Handles dgdTimeline.InitializingNewItem
        CType(e.NewItem, Timeline).Time = Now
    End Sub

End Class
