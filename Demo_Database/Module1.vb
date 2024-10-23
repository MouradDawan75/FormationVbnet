Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes
Imports ProjetDLL

Module Module1

    Sub Main()

        Dim dao As New ProduitDAO()

        ' Affichage d'un menu:

        While True

            Console.WriteLine(">>>> Choisir une opération:")
            Console.WriteLine("1- Afficher le liste des produits")
            Console.WriteLine("2- Ajouter un produit")
            Console.WriteLine("3- Modifier un produit")
            Console.WriteLine("4- Supprimer un produit")
            Console.WriteLine("5- Rechercher un produit par son id")
            Console.WriteLine("6- Rechercher des produit par mot clé")
            Console.WriteLine("7- Exporter la liste des produits en JSON")
            Console.WriteLine("8- Quitter")

            Dim choix = Console.ReadLine()

            If choix.Equals("8") Then
                Console.WriteLine(">>>>>>>>>>>>> Fin du programme..........")
                Exit While
            End If

            Select Case choix
                Case "1"
                    Dim lst = dao.GetAll()
                    If lst.Count = 0 Then
                        Console.WriteLine("Aucun produit trouvé")
                    Else
                        Console.WriteLine($"{lst.Count} produits trouvés:")
                        For Each p In lst
                            Console.WriteLine(p)
                        Next
                    End If


                Case "2"
                    Console.WriteLine("Description: ")
                    Dim descrpition = Console.ReadLine()

                    Console.WriteLine("Prix: ")
                    Dim prix = Convert.ToDouble(Console.ReadLine())

                    Console.WriteLine("Quantité: ")
                    Dim quantite = Convert.ToInt32(Console.ReadLine())

                    dao.Insert(New Produit(0, descrpition, prix, quantite))
                    Console.WriteLine("Produit inséré.....")

                Case "3"
                    Console.WriteLine("ID: ")
                    Dim id = Convert.ToInt32(Console.ReadLine())

                    If dao.GetById(id) IsNot Nothing Then

                        Console.WriteLine("Description: ")
                        Dim descrpition1 = Console.ReadLine()

                        Console.WriteLine("Prix: ")
                        Dim prix1 = Convert.ToDouble(Console.ReadLine())

                        Console.WriteLine("Quantité: ")
                        Dim quantite1 = Convert.ToInt32(Console.ReadLine())

                        dao.Update(New Produit(id, descrpition1, prix1, quantite1))
                        Console.WriteLine("Produit MAJ......")

                    Else
                        Console.WriteLine("Id introuvable....")

                    End If

                Case "4"
                    Console.WriteLine("ID: ")
                    Dim id = Convert.ToInt32(Console.ReadLine())

                    If dao.GetById(id) IsNot Nothing Then
                        dao.Delete(id)
                        Console.WriteLine("Produit Supprimé......")

                    Else
                        Console.WriteLine("Produit introuvable....")

                    End If

                Case "5"
                    Console.WriteLine("ID: ")
                    Dim id = Convert.ToInt32(Console.ReadLine())

                    Dim p = dao.GetById(id)

                    If p IsNot Nothing Then

                        Console.WriteLine(p)

                    Else
                        Console.WriteLine("Produit introuvable....")

                    End If


                Case "6"
                    Console.WriteLine("Mot clé: ")
                    Dim key = Console.ReadLine()

                    Dim lst = dao.FindByKey(key)

                    If lst.Count = 0 Then
                        Console.WriteLine("Aucun produit trouvé.")
                    Else

                        Console.WriteLine($"{lst.Count} produits trouvés")
                        For Each p In lst
                            Console.WriteLine(p)
                        Next

                    End If

                Case "7"
                    GenericTools.ExportJson(Of Produit)("C:\test\produits.json", dao.GetAll())
                    Console.WriteLine("Export JSON Ok")

                Case Else
                    Console.WriteLine("Choix invalide.....")


            End Select



        End While




        'Maintenir la console active
        Console.ReadLine()

    End Sub

End Module
