Public Class Timeline
    Public Property id As Integer

    <ComponentModel.DataAnnotations.Required>
    Public Property Time As Date
    Public Property Comments As String
    Public Property Flag As Boolean
    Public Property MetaData_Primary As String
    Public Property MetaData_Secondary As String

    <ComponentModel.DataAnnotations.Required>
    Public Property Activity As Activity
    Public Property MetaData As New HashSet(Of MetaData)
End Class
