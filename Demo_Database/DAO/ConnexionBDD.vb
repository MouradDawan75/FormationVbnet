Imports System.Data.SqlClient

Public Class ConnexionBDD

    Public Shared Function GetConnexion() As SqlConnection

        ' https://www.connectionstrings.com/: pour récupérer les chaines de connexion
        Dim chaine As String = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=vbnet;Integrated Security=True"
        Dim cnx As New SqlConnection(chaine)
        cnx.Open()
        Return cnx

    End Function

End Class
