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




        'Maintenir la console active
        Console.ReadLine()

    End Sub

End Module
