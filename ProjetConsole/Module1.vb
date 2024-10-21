Imports ProjetDLL

Module Module1

    ' Ceci est un commentaire: ligne de code ignorée par e compilateur
    ' main: c'est le point d'entrée d'une application console
    Sub Main()

        'Appeler la méthode Afficher du projet dll
        Tools.Afficher()

#Region "Type de données"

        Console.WriteLine(">>>>>>>>>>>> Type de données:")
        ' Variable: zone mémoire (RAM) contenant une valeur typée
        ' Types de base (élémentaires - types valeurs): possèdent une prédéfinie
        ' Entiers: byte(1 octet), short (2 octets), Integer(4 octets), long (8 octets)
        ' Réels: single (4 o), double(8 o), decimal(16 o)
        ' Boolean: 1 octet
        ' Char: 2 octets

        ' En Vb.net, le typage est statique. On doit préciser le type d'une variabe dès sa déclaration

        Dim myInt As Integer = 15
        Dim myDouble As Double = 15.5
        Dim myChar As Char = "A"c

        'Inference de type: le compilateur détermine le type d'une variable selon la valeur
        'qu'on lui a affecter

        Dim x As Double = 10.5


        ' Types complèxes (types références): possèdent une taille variables
        Dim chaine As String = "ceci est une chaine"

        'Recommandations: dans les propriétés du projet:
        ' 1- Activer l'option strict
        ' 2- Désactiver l'option infer (inférence de type):pour pratiquer le typage statique

        ' Types nullables: pouvoir mentionner que la variable n'a pas de valeur (null)
        ' Par définition, les types de base (types valeurs) ne sont pas nullables

        Dim age? As Integer
        Dim age2 As Integer?

        If (age.HasValue) Then
            Console.WriteLine(age)
        Else
            Console.WriteLine("age est null")
        End If

        age = Nothing ' Nothong pour null

        ' Constante: est une variable dont on ne peut pas modifier e contenu
        Const MY_CONSTANTE As Double = 11.66

        'MY_CONSTANTE = 15.12 -> erreur de compilation
        'Conventions de nommage:
        'Constante: le nom d'une constante doit être en majuscules
        'PascalCase: MaClasse - méthodes
        'camelCase: myVariable: variables
        'snake_case: my_variable : convention utilisée par Python

        ' Valeurs aléatoires:
        Dim r As Random = New Random()
        Dim resultat As Integer = r.Next(1, 10) ' renvoie un entier aléatoire compris entre 1 et 10 (10 non compris)
        Console.WriteLine(resultat)

#End Region




        'Maintenir la console active
        Console.ReadLine()

    End Sub

End Module
