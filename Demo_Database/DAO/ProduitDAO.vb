Imports System.Data.SqlClient

Public Class ProduitDAO

    'CRUD: Create - Read - Update - Delete
    Public Sub Insert(p As Produit)
        'Connexion à la DB
        Dim cnx As SqlConnection = ConnexionBDD.GetConnexion()
        Dim sql As String = "insert into produits(description,prix,quantite) values (@description,@prix,@quantite)"
        Dim cmd As New SqlCommand(sql, cnx)
        cmd.Parameters.AddWithValue("@description", p.Description)
        cmd.Parameters.AddWithValue("@prix", p.Prix)
        cmd.Parameters.AddWithValue("@quantite", p.Quantite)
        cmd.ExecuteNonQuery()
        cnx.Close()

    End Sub

    Public Sub Update(p As Produit)
        'Connexion à la DB
        Dim cnx As SqlConnection = ConnexionBDD.GetConnexion()
        Dim sql As String = "update produits set description=@description,prix=@prix,quantite=@quantite where id=@id"
        Dim cmd As New SqlCommand(sql, cnx)
        cmd.Parameters.AddWithValue("@description", p.Description)
        cmd.Parameters.AddWithValue("@prix", p.Prix)
        cmd.Parameters.AddWithValue("@quantite", p.Quantite)
        cmd.Parameters.AddWithValue("@id", p.Id)
        cmd.ExecuteNonQuery()
        cnx.Close()

    End Sub

    Public Sub Delete(id As Integer)
        'Connexion à la DB
        Dim cnx As SqlConnection = ConnexionBDD.GetConnexion()
        Dim sql As String = "delete from produits where id=@id"
        Dim cmd As New SqlCommand(sql, cnx)
        cmd.Parameters.AddWithValue("@id", id)
        cmd.ExecuteNonQuery()
        cnx.Close()

    End Sub

    Public Function GetAll() As List(Of Produit)
        Dim lst As New List(Of Produit)

        Dim cnx As SqlConnection = ConnexionBDD.GetConnexion()
        Dim sql As String = "select * from produits" ' * pour prendre toutes les colonnes sinon: select id,prix from produits
        Dim cmd As New SqlCommand(sql, cnx)

        Dim reader As SqlDataReader = cmd.ExecuteReader()

        While reader.Read()

            Dim p As New Produit(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetInt32(0))
            lst.Add(p)

        End While

        reader.Close()
        cnx.Close()

        Return lst


    End Function

    Public Function GetById(id As Integer) As Produit
        Dim p As Produit = Nothing

        Dim cnx As SqlConnection = ConnexionBDD.GetConnexion()
        Dim sql As String = "select * from produits where id=@id" ' * pour prendre toutes les colonnes sinon: select id,prix from produits
        Dim cmd As New SqlCommand(sql, cnx)
        cmd.Parameters.AddWithValue("@id", id)

        Dim reader As SqlDataReader = cmd.ExecuteReader()

        If reader.Read() Then

            p = New Produit(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetInt32(0))

        End If

        reader.Close()
        cnx.Close()

        Return p


    End Function

    Public Function FindByKey(key As String) As List(Of Produit)
        Dim lst As New List(Of Produit)

        Dim cnx As SqlConnection = ConnexionBDD.GetConnexion()
        Dim sql As String = "select * from produits where description like @description" ' * pour prendre toutes les colonnes sinon: select id,prix from produits
        Dim cmd As New SqlCommand(sql, cnx)
        cmd.Parameters.AddWithValue("@description", "%" & key & "%") ' %p%

        Dim reader As SqlDataReader = cmd.ExecuteReader()

        While reader.Read()

            Dim p As New Produit(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetInt32(0))
            lst.Add(p)

        End While

        reader.Close()
        cnx.Close()

        Return lst


    End Function


End Class
