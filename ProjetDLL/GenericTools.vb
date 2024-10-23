Imports System.IO
Imports System.Reflection
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization.Json
Imports System.Xml.Serialization

Public Class GenericTools

    Public Shared Sub ExportBin(Of T)(chemin As String, lst As List(Of T))

        'Stream est une classe abstraite (MustInherit) non instanciable. Pour l'instancier
        ' on doit utiliser une classe fille qui hérite de la classe abstraite
        ' Touche F1 pour consulter la doc de microsoft et identifier les classes filles
        Dim bin As New BinaryFormatter()

        Dim flux As Stream = New FileStream(chemin, FileMode.Create) ' Create: si fichier inexistant -> il est généré
        bin.Serialize(flux, lst)
        flux.Close()
    End Sub

    ' Méthode de désérialisation binaire
    Public Shared Function ImportBin(Of T)(chemin As String) As List(Of T)

        Dim lst As New List(Of T)
        Dim bin As New BinaryFormatter()
        Dim flux As Stream = New FileStream(chemin, FileMode.Open)
        lst = bin.Deserialize(flux)
        flux.Close()
        Return lst

    End Function

    'Méthode de sérialisation XML - XmlSerializer
    Public Shared Sub ExportXml(Of T)(chemin As String, lst As List(Of T))

        Dim xml As New XmlSerializer(lst.GetType())

        Dim flux As Stream = New FileStream(chemin, FileMode.Create) ' Create: si fichier inexistant -> il est généré
        xml.Serialize(flux, lst)
        flux.Close()
    End Sub

    'Méthode de désérialisation XML
    Public Shared Function ImportXml(Of T)(chemin As String) As List(Of T)

        Dim lst As New List(Of T)
        Dim xml As New XmlSerializer(GetType(List(Of T)))
        Dim flux As Stream = New FileStream(chemin, FileMode.Open)
        lst = xml.Deserialize(flux)
        flux.Close()
        Return lst

    End Function

    'Méthode de sérialisation JSON - DataContractJsonSerializer
    Public Shared Sub ExportJson(Of T)(chemin As String, lst As List(Of T))

        Dim json As New DataContractJsonSerializer(lst.GetType())

        Dim flux As Stream = New FileStream(chemin, FileMode.Create) ' Create: si fichier inexistant -> il est généré
        json.WriteObject(flux, lst)
        flux.Close()
    End Sub

    'Méthode de désérialisation JSON
    Public Shared Function ImportJson(Of T)(chemin As String) As List(Of T)

        Dim lst As New List(Of T)
        Dim json As New DataContractJsonSerializer(lst.GetType())
        Dim flux As Stream = New FileStream(chemin, FileMode.Open)
        lst = json.ReadObject(flux)
        flux.Close()
        Return lst

    End Function

    'Méthode de sérialisation csv
    Public Shared Sub ExportCsv(Of T)(chemin As String, lst As List(Of T), separateur As String)
        Dim sw As New StreamWriter(chemin)
        For Each obj As T In lst

            'Récupérer la liste des attributs
            Dim props = GetType(T).GetFields()

            For index = 0 To props.Length - 1

                Dim p As FieldInfo = props(index)
                sw.Write(p.GetValue(obj).ToString()) ' DUPONT  

                ' Vérifier qu'on a pas atteint la dernière propriété pour insérer le separateur
                If index < props.Length - 1 Then
                    sw.Write(separateur)
                End If

            Next
            sw.WriteLine()
        Next
        sw.Close()
    End Sub

    ' Méthode de désérialisation CSV
    Public Shared Function ImportCsv(Of T)(chemin As String, separateur As String) As List(Of T)
        Dim lst As New List(Of T)
        Dim sr As New StreamReader(chemin)

        While Not sr.EndOfStream
            ' Pour chaque ligne:
            ' - Créer un objet T
            ' - Renseigner ses attributs
            ' - L'ajouter dans la liste

            'lire la ligne en cours
            Dim ligne As String = sr.ReadLine()
            Dim tab As String() = ligne.Split(separateur)

            ' Instancier le type T
            Dim obj As T = Activator.CreateInstance(GetType(T))
            Dim props As FieldInfo() = GetType(T).GetFields()

            For index = 0 To tab.Length - 1
                props(index).SetValue(obj, Convert.ChangeType(tab(index), props(index).FieldType))
            Next

            lst.Add(obj)

        End While

        sr.Close()

        Return lst
    End Function

End Class
