Public Class Produit

    Public Id As Integer
    Public Description As String
    Public Prix As Double
    Public Quantite As Integer

    Public Sub New(id As Integer, description As String, prix As Double, quantite As Integer)
        Me.Id = id
        Me.Description = description
        Me.Prix = prix
        Me.Quantite = quantite
    End Sub

    Public Sub New()
    End Sub

    Public Overrides Function ToString() As String
        Return $"Id: {Id} - Description: {Description} - Prix: {Prix} - Quantité: {Quantite}"
    End Function
End Class
