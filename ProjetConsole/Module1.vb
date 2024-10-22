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

#Region "Exceptions"

        Console.WriteLine(">>>>>> Exceptions:")
        ' Il existe 3 types d'erreurs possibles dans un code:
        ' - Erreurs de compilation (syntaxe): sont détectées automatiquement par l'IDE
        ' - Exception: sont des erreurs qui provoquent l'arrêt de l'application
        ' - Code fonctionnel qui renvoie un résultat inattendu (faire de debuggage)

        ' Pour éviter l'arrêt de l'application, on doit gérer l'exception
        ' Pour gérer une exception, on utilise le bloc try/catch
        ' Il existe plusieurs types d'exceptions, chacune d'elles porte le nom de l'erreur qu'elle génère.
        ' Il existe aussi le type générique (anonyme) Exception

        Dim n As Integer = 10

        Console.WriteLine("Votre nombre: ")


        Try
            Dim nb As Integer = CInt(Console.ReadLine())
            Console.WriteLine(n \ 0)

        Catch ex As DivideByZeroException
            Console.WriteLine("Exception gérée.....")

        Catch ex1 As InvalidCastException
            Console.WriteLine(ex1.Message)
        End Try


        Console.WriteLine(">> Type générique d'exception:")
        'Obligation: une ressource (fichier, base de données....) doit être libérée à la fin de son 
        ' utilisation

        'Bonne pratique: prévoir un try/catch lors de la minipulation des ressources


        Try
            ' Ouverture d'un fichier en lecture
            Console.WriteLine(n \ 1)
            Dim nb As Integer = CInt(Console.ReadLine())


        Catch ex As Exception
            Console.WriteLine("Exception gérée.....")
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)


        Finally
            'Bloc optionnel qui s'exécute dans tous les cas exception ou pas
            Console.WriteLine("Bloc finally.....")
            ' Fermeture du fichier
            ' Sert dans la pratique à libérer les ressources utilisées dans le try

        End Try

        Try
            MesMethodes.Division(0)
        Catch ex As Exception
            ' Garder une trace dans fichier de logs
            ' Garder une trace dans une table
        End Try


        Console.WriteLine("suite de l'application......")

#End Region

#Region "Les classes"

        Console.WriteLine(">>>>> Les classes:")
        ' - Approche procédurale: repose sur l'utilisation de paramètres et de fonctions
        ' - Approche objets: repose sur l'utilisation de classes et de modules
        '  est une approche de résolution algorithmétique de problèmes permettant de produire des 
        ' programmes modulaires.
        ' Objectifs:
        ' - Developper une partie de l'application sans qu'il soit nécessaire de connaitre les détails des autres
        ' parties de l'application
        ' - Apporter des modifications à un module sans que cla n'affècte le reste du programme
        ' - Réutilisation des modules dans un autre cadre
        ' Une classe est un type de donnée. Elle a pour tâche principale de décrire la structure d'un objet
        ' Elle définie une sorte de template à partir duquel on crée nos objets.
        ' Elle contient généralement, 3 choses:
        ' - Attributs - Propriétés: représentent l'état de l'objet
        ' - Méthodes: représentent le comprtement de l'objet
        ' - Méthode spéciale publique qui porte le nom de la classe appelée constructeur permettant
        ' d'instancier la classe en question.
        ' Le rôle d'un constructeur est d'initialiser tous les attributs de l'objet

        Dim u1 As Utilisateur = New Utilisateur() ' Nom = Nothing    Prenom = Nothing  Age = 0
        Console.WriteLine($"Nom: {u1.Nom}")
        Console.WriteLine($"Prénom: {u1.Prenom}")
        Console.WriteLine($"Age: {u1.Age}")
        Dim u2 As New Utilisateur("DUPONT", "Jean", 60)

        u1.AfficherNom()
        u2.AfficherNom()

        Console.WriteLine(u2)

        Dim u3 As New Utilisateur("DURAND", "Marie", 35)
        Dim u4 As New Utilisateur("DURAND", "Marie", 45)

        Console.WriteLine(u3.Equals(u4))

        Console.WriteLine(Utilisateur.Profil)

        Utilisateur.ChangerProfil("RH")

        Dim cpte As New CompteBancaire("sdsq15", 1000)
        cpte.Depot(500)
        Try
            cpte.Retrait(5550)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try


        Console.WriteLine(cpte)

        Dim cpte1 As New CompteBancaire("145ddd", 500)
        Dim cpte2 As New CompteBancaire("145ddd", 2500)

        Console.WriteLine(cpte1.Equals(cpte2))







#End Region

#Region "Classe String"

        Console.WriteLine(">>>>> Classe String:")
        Dim st As String = "test"
        'on peut instancier la classe String sans faire appel au constructeur - via une chaine littérale

        st = st.ToUpper()
        Console.WriteLine(st) ' les objets de type String sont immuables

        Console.WriteLine(">>> Quelques méthodes de la classe String:")

        Dim texte As String = " ceci est une chaine "

        Console.WriteLine("texte contient ceci ? " & texte.Contains("ceci"))
        Console.WriteLine("Remplacer une chaine par un texte: " & texte.Replace("une chaine", "un texte"))
        Console.WriteLine("Majuscules: " & texte.ToUpper())
        Console.WriteLine("Miniscules: " & texte.ToLower())
        Console.WriteLine("Suppression des espaces de début et de fin de chaine: " & texte.Trim())
        Console.WriteLine("texte commence par ceci ? " & texte.StartsWith("ceci"))
        Console.WriteLine("texte se termine par chaine ? " & texte.EndsWith("chaine "))
        Console.WriteLine("Premier char de texte: " & texte.ElementAt(0)) ' espace
        Console.WriteLine("Premier char de texte: " & texte(0)) ' par définition, une chaine est un tableau de caractères
        Console.WriteLine("Taille de texte: " & texte.Count())

        Console.WriteLine("Sous chaine1 : " & texte.Substring(2))
        Console.WriteLine("Sous chaine1 : " & texte.Substring(1, 4))

        Console.WriteLine("Découpage d'une chaine:")

        Dim chaineCSV As String = "toto;tata titi,tutu"

        Dim mots() As String = chaineCSV.Split(";"c, " "c, ","c)
        For Each mt As String In mots
            Console.WriteLine(mt)
        Next

        Console.WriteLine("Join:")

        Console.WriteLine(String.Join(" ", "Il", "est", 10, ":", 41))



#End Region


        'Maintenir la console active
        Console.ReadLine()

    End Sub

End Module
