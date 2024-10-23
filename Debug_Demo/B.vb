Public Class B

    Public a As Integer = 0

    Public Sub MethodB()

        Dim c As New C()
        a = 123
        For index = 0 To 200
            a += 1
        Next

        c.MethodeC(Me)

    End Sub

End Class
