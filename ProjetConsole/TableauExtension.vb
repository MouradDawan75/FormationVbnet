Imports System.Runtime.CompilerServices

Module TableauExtension

    <Extension>
    Public Sub Replace(tab As Integer(), index As Integer, value As Integer)
        tab(index) = value
    End Sub

    <Extension>
    Public Sub AfficherTableau(tab As Integer())
        For Each x As Integer In tab
            Console.WriteLine(x)
        Next
    End Sub

    <Extension>
    Public Sub Imprimer(c As String)
        Console.WriteLine(c)
    End Sub

End Module
