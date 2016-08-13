Public Class Timeline
    Public Property id As Integer
    Public Property Time As Date
    Public Property Comments As String
    Public Property Flag As Boolean
    Public Property MetaData_Primary As String
    Public Property MetaData_Secondary As String

    Public Property Activities As New HashSet(Of Activity)
    Public Property MetaData As New HashSet(Of MetaData)


End Class
