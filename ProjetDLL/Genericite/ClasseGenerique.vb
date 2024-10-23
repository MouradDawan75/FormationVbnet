Public Class ClasseGenerique(Of T)

    Public a As T
    Public b As T

    Public Sub Swap()
        Dim tmp As T = a
        a = b
        b = tmp
    End Sub

End Class
