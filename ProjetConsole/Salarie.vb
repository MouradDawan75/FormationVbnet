Public Class Salarie
    Inherits Object

    Public Nom As String
    Public Prenom As String

    Public Sub New(nom As String, prenom As String)
        Me.Nom = nom
        Me.Prenom = prenom
    End Sub

    Public Sub New()
    End Sub

    Public Sub Identite()
        Console.WriteLine($"Nom: {Nom} - Prénom: {Prenom}")
    End Sub
End Class
