Public Class Activity
    Public Property id As Integer

    <ComponentModel.DataAnnotations.Required>
    Public Property Name As String
    Public Property Description As String
    Public Property Misc As String

    Public Property Timelines As New ObjectModel.ObservableCollection(Of Timeline)
End Class
