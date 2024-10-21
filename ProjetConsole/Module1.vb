Imports System.Xml.Serialization
Imports ProjetDLL

Module Module1

    Enum EtatProduit
        NEUF = 1
        BON
        MAUVAIS
    End Enum

    ' On a la possibilité de modifier l'index des éléments d'une Enum -> par défaut l'index commence à 0
    Enum Erreur
        MINEURE = 100
        MAJEURE = 200
        CRITIQUE = 300
    End Enum

    Enum Profil
        ADMIN
        MANAGER
        RH
    End Enum

    Enum Autorisation
        LECTURE
        ECRITURE
        SUPPRESSION
        MODIFICATION
        TOUTES
    End Enum

    Class User
        Public Nom As String
        Public Profil As Profil
        Public Autorisations As New List(Of Autorisation)
    End Class

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

#Region "Conversions de types"

        Console.WriteLine(">>>> Conversion implicite:")
        'Concerne le passage d'un type inférieur à un type supérieur

        Dim myByte As Byte = 10
        Dim monInt As Integer = myByte

        Console.WriteLine(">>>> Conversion explicite:")
        'Concerne le passage d'un supérieur à un type inférieur
        ' La cast, la classe convert, la méthode Ctype
        Dim monLong As Long = 10
        Dim monShort As Short = CShort(monLong) 'risque de permet de donnée
        'Cast: CInt, CDouble......

        Dim monInt2 As Integer = Convert.ToInt32(monLong)

        'Méthode Ctype: 
        Dim myInt3 As Integer = CType("10", Integer)

        'IsNumeric:
        Console.WriteLine("IsNumeric: " & IsNumeric("10"))

        Dim c As String = "a"
        Dim monChar As Char = CChar(c)
        Dim monChar1 As Char = "a"c ' autre syntaxe de conversion de string en char


#End Region

#Region "Formattage de chaines"

        Console.WriteLine(">>>>> Formattage:")

        'Concaténation:
        Dim prenom As String = "Jean"
        Dim ages As Integer = 50

        Console.WriteLine("Prénom: " & prenom & " Age: " & ages)

        'Interpolation:
        'Version1:

        Console.WriteLine("Prénom: {0} Age: {1}", prenom, ages)

        'Version2: syntaxe simplifiée de version1:

        Console.WriteLine($"Prénom: {prenom} Age: {ages}")
        ' Entre accolades, on peut soit insérer des variables, soit des expressions

        Console.WriteLine($"Expression: {5 + 6}")


#End Region

#Region "Opérateurs"

        Console.WriteLine(">>>>>> Opérateurs:")
        'Opérateurs arithmétiques: + - * / Mod
        'Opérateurs combinés: += -= *= /= Mod= --> x += 1 équivalent x = x + 1
        'Opérateurs logiques: and or not xor -> renvoient un boolean
        'Opérateurs de comparaison: > >= < <= =(égalité) <> (différent) --> renvoient un boolean

        Console.WriteLine(5 = 10)

#End Region

#Region "Bloc conditionnel"

        Console.WriteLine(">>>>> Bloc conditionnel:")
        'Est un ensemble d'instructions qui ne s'exécute qui si une condition est vraie

        'if/elseif.../else

        If myInt > 0 Then
            Console.WriteLine("myInt positif")

        ElseIf myInt < 0 Then
            Console.WriteLine("myInt négatif")
        Else
            Console.WriteLine("myInt égale zéro")

        End If

        'Select case: est une variante du if/else qui permet de remplacer les elseif qui s'imbriquent

        Dim note As Integer = 8

        Select Case note
            Case 1 To 5
                Console.WriteLine("entre 1 et 5")

            Case 6, 7, 8
                Console.WriteLine("Egale a 6,7 ou 8")

            Case Else
                Console.WriteLine("Supérieure à 8")


        End Select

        'Opérateur ternaire: iif(condition, valeur si vraie, valeur si fausse): permet de faire 
        ' des affectations conditionnelles

        myInt = CInt(IIf(5 > 3, 3, 5))


#End Region

#Region "Blocs itératifs: boucles"

        Console.WriteLine(">>>> Boucles:")
        'for: si nombre d'itérations connues
        'for each: permet de parcourir tous les éléments d'une collection
        'while - Do Loop While - Do Loop Until: boucles conditionnelles


        'For:

        For Index As Integer = 1 To 5
            Console.WriteLine($"Passage: {Index}")
            If Index = 3 Then
                Exit For

            End If
        Next

        ' For Each:

        Dim tab As Integer() = {1, 2, 3, 4}

        For Each item As Integer In tab
            Console.WriteLine(item)
            If item = 2 Then
                Exit For

            End If
        Next

        'while:

        Dim valeur As Integer = 1

        While valeur < 5
            Console.WriteLine($"Valeur = {valeur}")
            valeur += 1
            If valeur = 3 Then
                Exit While
            End If

        End While

        ' Do loop while

        Do
            Console.WriteLine($"Valeur = {valeur}")
            valeur += 1
            If valeur = 8 Then
                Exit Do
            End If

        Loop While valeur < 10 ' Fait tant que la condition est vraie

        ' Do Loop Until

        Do
            Console.WriteLine($"Valeur = {valeur}")
            valeur += 1
        Loop Until valeur > 15 ' Fait tant que condition est fausse


#End Region

#Region "Tableaux"

        Console.WriteLine(">>>>>> Tableaux:")
        ' 1 dimension
        Dim t1(2) As Integer ' tableau de cases (index commence à 0)
        t1(0) = 10
        t1(1) = 20
        t1(2) = 30

        ' Si le contenu du tableau est connu d'avance, on peut faire:
        Dim t2() As Integer = {10, 20, 30}

        ' On peut redimensionner le tableau en preservant son contenu
        ReDim Preserve t2(4)
        t2(3) = 40
        t2(4) = 40

        Console.WriteLine($"Taille de t2: {t2.Length}")

        ' Parcourir t2

        'For Each:
        Console.WriteLine(">>>> For Each <<<<")
        For Each i As Integer In t2
            Console.WriteLine(i)
        Next

        ' For
        Console.WriteLine(">>>> For <<<<")
        For Index As Integer = 0 To t2.Length - 1
            Console.WriteLine(t2(Index))
        Next

        ' While

        Console.WriteLine(">>>> While <<<<")

        Dim cpt As Integer = 0

        While cpt < t2.Length
            Console.WriteLine(t2(cpt))
            cpt += 1

        End While

        ' 2 dimensions:
        Dim matrice(,) As Double = {{3.5, 4.5}, {5.6, 4.6}}
        Dim nbLignes As Integer = matrice.GetLength(0)
        Dim nbColonnes As Integer = matrice.GetLength(1)
        Dim nbDimensions As Integer = matrice.Rank

        ' Parcourir la matrice:

        ' Fixer les lignes
        For ligne As Integer = 0 To matrice.GetLength(0) - 1

            ' Fixer les colonnes
            For colonne As Integer = 0 To matrice.GetLength(1) - 1

                Console.WriteLine(matrice(ligne, colonne))

            Next

        Next

        ' Plusieurs dimensions
        Dim cube(4, 4, 4) As Integer
        cube(0, 0, 0) = 10
        cube(0, 0, 1) = 10



#End Region

#Region "Enumération"

        Console.WriteLine(">>>> Les enums:")
        ' Enum: est une liste de constantes (valeurs connues d'avance)

        Dim etat As EtatProduit = EtatProduit.NEUF
        Console.WriteLine(etat) ' renvoie l'index de l'élément dans l'enum
        Console.WriteLine(etat.ToString())

        Console.WriteLine("Code de votre erreur (100,200 ou 300): ")
        Dim code As Integer = CInt(Console.ReadLine())

        Dim erreur As Erreur = CType(code, Erreur)
        Console.WriteLine("Votre erreur est: " & erreur.ToString())

        Dim u As New User()
        u.Nom = "DUPONT"
        u.Profil = Profil.RH
        u.Autorisations.Add(Autorisation.LECTURE)
        u.Autorisations.Add(Autorisation.ECRITURE)
        u.Autorisations.Add(Autorisation.SUPPRESSION)

        If u.Autorisations.Contains(Autorisation.SUPPRESSION) Then
            Console.WriteLine("Suppression OK....")
        Else
            Console.WriteLine("Action interdite....")
        End If



#End Region

#Region "Méthodes"

        Console.WriteLine(">>>>>>>>>>> Méthodes:")
        'Méthode: est un ensemble d'instructions réutilisable
        ' 2 types de méthodes:
        ' Procédure: méthode qui ne renvoie aucun résultat
        ' Fonction: méthode qui renvoie un résultat

        Dim m As New MesMethodes()
        m.Afficher()

        Dim result As Integer = MesMethodes.Somme(10, 20)
        Console.WriteLine(result)

        Dim tableau As Integer() = {1, 5, 10, 3, 7}

        Console.WriteLine($"Somme tableau = {MesMethodes.SommeTableau(tableau)}")
        Console.WriteLine($"Moyenne tableau = {MesMethodes.MoyenneTableau(tableau)}")
        Console.WriteLine($"Min tableau = {MesMethodes.MinTableau(tableau)}")



        'Appel de a méthode avec des params optionnels:
        ' Les params optionnels d'une méthode possèdent une valeur par défaut et sont définis après les params
        ' obligatoires

        MesMethodes.MethodeOptionnelle(99) ' la méthode utilise les valeurs par défaut des params optionnels
        MesMethodes.MethodeOptionnelle(99, 11, 35) ' On peut aussi modifier les valeurs des params optionnels en cas de besoin

        MesMethodes.MethodeOptionnelle(99,, 115) ' valide sytaxiquement, mais non lisible

        ' Appel d'une méthode avec des params nommés sans tenir compte de leur position

        MesMethodes.MethodeOptionnelle(beta:=115, x:=99)

        Console.WriteLine(MesMethodes.PrixTTC(80))
        Console.WriteLine(MesMethodes.PrixTTC(80, tva:=0.35))
        ' Si tva change -> pas besoin de modifier la méthode définie précedemment, il suffit de la rappeler avec
        ' la nouvelle valeur de tva -> code facile à étendre qui ne nécessite pas de modifications

        Dim val1 As Integer = 10
        Dim val2 As Integer = 15

        Console.WriteLine($"Avant permutation: val1 = {val1} - val2 = {val2}")

        MesMethodes.Permuter(val1, val2)

        Console.WriteLine($"Après permutation: val1 = {val1} - val2 = {val2}")

        Dim prod As Integer = 0
        Dim sm As Integer = MesMethodes.Calculs(10, 15, prod)

        Console.WriteLine($"Somme = {sm} - Produit = {prod}")

        'Appel de la méthode avec un nombre variable de paramètres:
        Console.WriteLine(MesMethodes.Produit(10, 20))
        Console.WriteLine(MesMethodes.Produit(10, 20, 30))
        Console.WriteLine(MesMethodes.Produit(10, 20, 30, 40))

        Dim s As String = "test"

        ' Pour définir des fonction s d'extension d'un type (d'une classe)
        ' Créer un nouveau module
        ' Définir des méthodes avec comme premier paramètre le type à étendre
        ' Appliquer <Extension> sur les différentes méthodes

        tableau.Replace(0, 99)
        tableau.AfficherTableau()

        s.Imprimer()




#End Region




        'Maintenir la console active
        Console.ReadLine()

    End Sub

End Module
