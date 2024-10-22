Public Class Test
    'x est une variable de classe (variable globale), pas besoin de l'initialiser car elle possède une
    'valeur par défaut
    ' Types numériques = 0
    ' Type Boolean = False
    ' Type complèxe = Nothing
    Dim x As Integer

    Public Sub M1()
        ' y est une variable locale qui doit être initialisée
        Dim y As Integer = 0

    End Sub

    Public Shared Sub M2()

    End Sub

End Class
