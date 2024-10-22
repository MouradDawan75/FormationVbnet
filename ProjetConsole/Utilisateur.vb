Public Class Utilisateur
    Inherits Object

#Region "Attributs - Propriétés"

    'Attributs d'instance propres à chaque utilisateur

    Public Nom As String
    Public Prenom As String
    Public Age As Integer

    ' Attributs partagés par tous les utilisateurs - sont indépendants des utilisateurs 

    Public Shared Profil As String = "admin"


#End Region

#Region "Constructeurs"

    Public Sub New(nom As String, prenom As String, age As Integer)
        'Me: mot clé qui pointe vers l'objet en cours d'utilisation
        Me.Nom = nom
        Me.Prenom = prenom
        Me.Age = age
    End Sub

    Public Sub New()
    End Sub



#End Region

#Region "Méthodes"

    ' Une méthode d'instance est une méthode qui concerne une instance particulière
    Public Sub AfficherNom()
        Console.WriteLine(Me.Nom)
    End Sub

    ' Overrides (Redéfinition de méthode) définies dans la classe mère
    ' Permet de personnaliser l'affichage d'un objet: choisir les attributs à afficher
    Public Overrides Function ToString() As String
        Return $"Nom : {Me.Nom} - Prénom: {Me.Prenom} - Age: {Me.Age}"
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Dim utilisateur As Utilisateur = TryCast(obj, Utilisateur)
        Return utilisateur IsNot Nothing AndAlso
               Nom = utilisateur.Nom AndAlso
               Prenom = utilisateur.Prenom
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return (Nom, Prenom).GetHashCode()
    End Function


    Public Shared Sub ChangerProfil(newProfil As String)
        Profil = newProfil
    End Sub




#End Region

End Class
