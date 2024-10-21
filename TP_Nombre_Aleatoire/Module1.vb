Module Module1

    Sub Main()
        ' Le programme choisit un nombre aléatoire compris entre 1 et 100
        ' Demandez à l'utilisateur de deviner ce nombre aléatoire
        ' - Nombre de tentatives max est de 6
        ' - Le programme doit gérer le cas d'une valeur saisie non numérique
        ' - Le programme indiquera à l'utilisateur si le nombre aléatoire est sup. ou inf. au nombre saisi

        Dim r As Random = New Random()
        Dim aleatoire As Integer = r.Next(1, 101) ' s'arrête à n - 1
        Const TENTATIVES_MAX As Integer = 6
        Dim compteur As Integer = 0

        While True

            Dim nombre As Integer = 0
            Console.WriteLine("Votre nombre: ")
            Dim saisie As String = Console.ReadLine()

            If IsNumeric(saisie) Then
                nombre = CInt(saisie)
                compteur += 1
            Else
                Console.WriteLine("Nombre invalide")
                ' Continue: force le passage à l'itération suivante -> la suite de la boucle n'est pas exécutée
                Continue While
            End If

            If nombre = aleatoire Then
                Console.WriteLine($"Trouvé. en {compteur} tentatives. Aléatoire = {aleatoire}")
                Exit While
            End If

            If compteur = TENTATIVES_MAX Then
                Console.WriteLine($"Perdu! Aléatoire = {aleatoire}")
                Exit While
            End If

            If aleatoire > nombre Then
                Console.WriteLine("Supérieur")
            Else
                Console.WriteLine("Inférieur")
            End If


        End While


        'Maintenir la console active
        Console.ReadLine()

    End Sub

End Module
