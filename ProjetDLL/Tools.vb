Imports System.IO
Imports System.Security.AccessControl
Imports System.Security.Principal
Imports System.Text

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

End Class
