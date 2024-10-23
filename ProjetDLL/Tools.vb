Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization.Json
Imports System.Security.AccessControl
Imports System.Security.Principal
Imports System.Text
Imports System.Xml.Serialization

Public Class Tools

    Public Shared Sub Afficher()
        Console.WriteLine("Méthode afficher du projet DLL...")
    End Sub

    ' Méthode de gestion des droits d'accès aux fichiers

    Public Shared Sub ControlAccess(chemin As String)

        Dim info As New FileInfo(chemin)

        Console.WriteLine("************* Contrôle d'accès pour le fichier: " & chemin)
        Dim security As FileSecurity = info.GetAccessControl()

        Dim rules = security.GetAccessRules(True, True, GetType(NTAccount))

        For Each rule As FileSystemAccessRule In rules
            Console.WriteLine("IdentityReference: " & rule.IdentityReference.ToString())
            Console.WriteLine("AccessControlType: " & rule.AccessControlType.ToString())
            Console.WriteLine("FileSystemRights: " & rule.FileSystemRights.ToString())
            Console.WriteLine("PropagationFlags: " & rule.PropagationFlags.ToString())
        Next

    End Sub

    Public Shared Sub AddFileSecurity(chemin As String, compte As String, regle As FileSystemRights, accessControl As AccessControlType)
        Dim info As New FileInfo(chemin)
        Dim security As FileSecurity = info.GetAccessControl()

        security.AddAccessRule(New FileSystemAccessRule(compte, regle, accessControl))
        info.SetAccessControl(security)

    End Sub

    Public Shared Sub RemoveFileSecurity(chemin As String, compte As String, regle As FileSystemRights, accessControl As AccessControlType)
        Dim info As New FileInfo(chemin)
        Dim security As FileSecurity = info.GetAccessControl()

        security.RemoveAccessRule(New FileSystemAccessRule(compte, regle, accessControl))
        info.SetAccessControl(security)

    End Sub

    'Méthode de lecture d'un fichier

    Public Shared Function LectureFichier(chemin As String) As String
        Dim sr As New StreamReader(chemin)
        Dim contenu As String = sr.ReadToEnd()
        sr.Close()
        Return contenu
    End Function

    'Méthode d'écriture dans un fichier

    Public Shared Sub EcritureFichier(chemin As String, contenu As String, Optional modeAjout As Boolean = False)

        Dim sw As New StreamWriter(chemin, append:=modeAjout)
        'Dim sb As New StringBuilder(contenu)
        'sb.AppendLine()
        If modeAjout = True Then
            sw.WriteLine()
        End If
        sw.Write(contenu)
        sw.Close()

    End Sub

    'Méthode qui récupère une précise à partir d'un fichier

    Public Shared Function LectureLigneFichier(chemin As String, numLigne As Integer) As String
        Dim contenu As String = ""
        Dim ligneEnCours = 0

        If numLigne < 0 Then
            Throw New Exception("Numéro de ligne doit être supérieur ou égale à 0...")
        End If

        If File.Exists(chemin) Then
            Dim sr As New StreamReader(chemin)

            While Not sr.EndOfStream() And ligneEnCours <= numLigne
                contenu = sr.ReadLine()
                ligneEnCours += 1
            End While
            If ligneEnCours < numLigne Then
                Throw New Exception($"La ligne {numLigne} n'existe pas dans le fichier ")
            End If


        Else
            Throw New Exception("Fichier introuvable...")
        End If


        Return contenu
    End Function

    'Méthode de sérialisation bainaire

    Public Shared Sub ExportBin(chemin As String, lst As List(Of CompteBancaire))

        'Stream est une classe abstraite (MustInherit) non instanciable. Pour l'instancier
        ' on doit utiliser une classe fille qui hérite de la classe abstraite
        ' Touche F1 pour consulter la doc de microsoft et identifier les classes filles
        Dim bin As New BinaryFormatter()

        Dim flux As Stream = New FileStream(chemin, FileMode.Create) ' Create: si fichier inexistant -> il est généré
        bin.Serialize(flux, lst)
        flux.Close()
    End Sub

    ' Méthode de désérialisation binaire

    Public Shared Function ImportBin(chemin As String) As List(Of CompteBancaire)

        Dim lst As New List(Of CompteBancaire)
        Dim bin As New BinaryFormatter()
        Dim flux As Stream = New FileStream(chemin, FileMode.Open)
        lst = bin.Deserialize(flux)
        flux.Close()
        Return lst

    End Function

    'Méthode de sérialisation XML - XmlSerializer
    Public Shared Sub ExportXml(chemin As String, lst As List(Of CompteBancaire))

        Dim xml As New XmlSerializer(lst.GetType())

        Dim flux As Stream = New FileStream(chemin, FileMode.Create) ' Create: si fichier inexistant -> il est généré
        xml.Serialize(flux, lst)
        flux.Close()
    End Sub


    'Méthode de désérialisation XML

    Public Shared Function ImportXml(chemin As String) As List(Of CompteBancaire)

        Dim lst As New List(Of CompteBancaire)
        Dim xml As New XmlSerializer(GetType(List(Of CompteBancaire)))
        Dim flux As Stream = New FileStream(chemin, FileMode.Open)
        lst = xml.Deserialize(flux)
        flux.Close()
        Return lst

    End Function

    'Méthode de sérialisation JSON - DataContractJsonSerializer

    Public Shared Sub ExportJson(chemin As String, lst As List(Of CompteBancaire))

        Dim json As New DataContractJsonSerializer(lst.GetType())

        Dim flux As Stream = New FileStream(chemin, FileMode.Create) ' Create: si fichier inexistant -> il est généré
        json.WriteObject(flux, lst)
        flux.Close()
    End Sub

    'Méthode de désérialisation JSON

    Public Shared Function ImportJson(chemin As String) As List(Of CompteBancaire)

        Dim lst As New List(Of CompteBancaire)
        Dim json As New DataContractJsonSerializer(lst.GetType())
        Dim flux As Stream = New FileStream(chemin, FileMode.Open)
        lst = json.ReadObject(flux)
        flux.Close()
        Return lst

    End Function

    'Méthode de sérialisation csv
    Public Shared Sub ExportCsv(chemin As String, lst As List(Of CompteBancaire), separateur As String)
        Dim sr As New StreamWriter(chemin)
        For Each cpt As CompteBancaire In lst
            sr.WriteLine(cpt.Numero & separateur & cpt.Solde)
        Next
        sr.Close()
    End Sub

    ' Méthode de désérialisation CSV
    Public Shared Function ImportCsv(chemin As String, separateur As String) As List(Of CompteBancaire)
        Dim lst As New List(Of CompteBancaire)
        Dim sr As New StreamReader(chemin)

        While Not sr.EndOfStream

            'lire la ligne en cours
            Dim ligne As String = sr.ReadLine()
            Dim tab As String() = ligne.Split(separateur)
            Dim cpt As New CompteBancaire(tab(0), Convert.ToDouble(tab(1)))
            lst.Add(cpt)

        End While

        sr.Close()

        Return lst
    End Function

End Class
