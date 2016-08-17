Class MainWindow
    Dim db As New Database
    'Dim Database_Location = db.Database.SqlQuery(Of String)("SELECT physical_name  FROM sys.database_files WHERE [type] = 0").First

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        Dim Activity As New Activity With {.Name = "Test"}
        db.Activities.Add(Activity)

        Dim Timeline As New Timeline With {.Time = DateTime.Now, .Activity = Activity}

        db.Timelines.Add(Timeline)
        db.SaveChanges()
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
        dgdTimeline.ItemsSource = db.Timelines.ToArray
        cbxActivities.ItemsSource = db.Activities.ToList
    End Sub
End Class
