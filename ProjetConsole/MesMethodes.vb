Imports System.CodeDom

Public Class MesMethodes

    ' Signature d'une méthode:
    ' Visibilité [Shared] Sub-Function NomMethode(paramétres) type-retour(si function)
    ' bloc d'instructions
    ' end sub-function

    ' une classe peut contenir 2 types de méthodes:
    ' - Méthode d'instance: accéssible à partir d'une instance de la classe
    ' - Méthode de classe (Shared): accéssible à partir de la classe

    ' Méthode d'instance
    Public Sub Afficher()
        Console.WriteLine("Méthode afficher......")
    End Sub

    ' Méthode de classe (Shared)
    ''' <summary>
    ''' Méthode qui calcule la somme de 2 entiers
    ''' </summary>
    ''' <param name="x">est un entier</param>
    ''' <param name="y">est un entier</param>
    ''' <returns>somme de x et y</returns>
    Public Shared Function Somme(x As Integer, y As Integer) As Integer
        Return x + y
    End Function

    ' Surcharge de méthode (overload): pouvoir définir la mm méthode dans la mm classe en modifiant simplement
    ' la liste des params soit en nombre, soit en type

    ' Surcharge en modifiant le nombre de params
    Public Shared Function Somme(x As Integer, y As Integer, z As Integer) As Integer
        Return x + y + z
    End Function

    ' Surcharge en modifiant le type de params
    Public Shared Function Somme(x As Double, y As Double) As Double
        Return x + y
    End Function

    ' méthode qui renvoie la somme des éléments d'un tableau d'entiers

    Public Shared Function SommeTableau(tab As Integer()) As Integer
        Dim s As Integer = 0

        For Each x As Integer In tab
            s += x
        Next

        Return s
    End Function

    ' méthode qui renvoie la moyenne des éléments d'un tableau d'entiers

    Public Shared Function MoyenneTableau(tab As Integer()) As Double
        Dim m As Double = 0
        Dim s As Integer = SommeTableau(tab)
        Dim nbElements As Integer = tab.Length
        m = s / nbElements
        Return m
    End Function

    ' méthode qui renvoie l'élément le plus petit d'un tableau d'entiers

    Public Shared Function MinTableau(tab As Integer()) As Integer
        Dim min As Integer = tab(0)
        For Index As Integer = 1 To tab.Length - 1

            If tab(Index) < min Then
                min = tab(Index)
            End If

        Next

        Return min
    End Function

    ' Méthode avec des params optionnels:

    Public Shared Sub MethodeOptionnelle(x As Integer,
                                         Optional alpha As Integer = 10,
                                         Optional beta As Integer = 15)

        Console.WriteLine($"x = {x} - alpha = {alpha} - beta = {beta}")

    End Sub

    Public Shared Function PrixTTC(prixHT As Double, Optional tva As Double = 0.2) As Double
        Return prixHT * (1 + tva)
    End Function

    ' Passage de paramètres par réferences: ne concerne que les types simples car les types complèxes
    ' par définition sont des types réferences
    ' C'est l'adresse de la variabe qui est fournie en paramètres
    Public Shared Sub Permuter(ByRef x As Integer, ByRef y As Integer)
        Dim tmp As Integer = x
        x = y
        y = tmp
    End Sub

    ' On peut utiliser le mot ByRef pour des variables en sortie
    ' Pratique pour définir des méthodes qui renvoient plusieurs résultats en sortie
    ''' <summary>
    ''' Méthode qui renvoie la somme de a et b et le produit de a et b dans
    ''' la variable en sortie prod
    ''' </summary>
    ''' <param name="a">est un entier</param>
    ''' <param name="b">est un entier</param>
    ''' <param name="prod">entier content le produit de a et b</param>
    ''' <returns>la somme de a et b</returns>
    Public Shared Function Calculs(a As Integer, b As Integer, ByRef prod As Integer) As Integer
        prod = a * b
        Return a + b
    End Function

    ' Méthode avec un nombre variable de paramètres

    'Public Shared Function Produit(x As Integer, y As Integer) As Integer
    '    Return x * y
    'End Function

    'Public Shared Function Produit(x As Integer, y As Integer, z As Integer) As Integer
    '    Return x * y * z
    'End Function

    ' Raccourcis clavier:
    ' Pour commenter des ignes sélectionnées: ctr + k + c
    ' Pour décommenter des ignes sélectionnées: ctr + k + u

    ' Intérêts: pour éviter de définir les différentes surcharges de la méthode
    Public Shared Function Produit(ParamArray tab As Integer()) As Integer
        'ParamArray: il s'agit d'un tableau à taile variable
        Dim p As Integer = 1
        For Each item As Integer In tab
            p *= item
        Next
        Return p

    End Function

    ''' <summary>
    ''' Méthode qui divise 10 par x
    ''' </summary>
    ''' <param name="x"></param>
    ''' <exception cref="Exception">Si x = 0, renvoie une exception</exception>
    Public Shared Sub Division(x As Integer)
        'Option1: la méthode gère sa propre exception
        'Try
        '    Console.WriteLine(10 \ x)
        'Catch ex As Exception
        '    Console.WriteLine("Exception gérée dans la méthode")
        'End Try

        'Option2: faire une remontée d'exception -> c'est l'appelant qui doit gérer l'exception
        If x <> 0 Then
            Console.WriteLine(10 \ x)
        Else
            'Throw permet de délencher une exception
            Throw New Exception("Attention! Division par 0")

        End If

    End Sub

    ' Méthode qui renvoie le nombre de mots qui composent une chaine

    ' Méthode qui renvoie le nombre d'occurrences d'un mot dans un paragarphe

    ' Méthode qui renvoie la chaine inversée

    ' Méthode qui vérifie si une chaine est un palindrôme: sms, sos....

End Class
