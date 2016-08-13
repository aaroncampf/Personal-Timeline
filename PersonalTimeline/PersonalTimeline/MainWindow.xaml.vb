Class MainWindow
    Dim db As New Database
    'Dim Database_Location = db.Database.SqlQuery(Of String)("SELECT physical_name  FROM sys.database_files WHERE [type] = 0").First

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Environment.GetEnvironmentVariable("DataDirectory")


        db.Database.Delete()
        db.Database.Create()







        Dim Database_Location = db.Database.SqlQuery(Of String)("SELECT physical_name  FROM sys.database_files WHERE [type] = 0").First
    End Sub

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        Dim Activity As New Activity With {.Name = "Test"}
        db.Activities.Add(Activity)

        Dim Timeline As New Timeline With {.Time = DateTime.Now}
        Timeline.Activities.Add(Activity)

        db.Timelines.Add(Timeline)
        db.SaveChanges()
    End Sub
End Class
