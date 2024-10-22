Public Class CompteBancaire

#Region "Attributs"

    Public Numero As String
    Public Solde As Double
    Public Shared Banque As String = "BNP"

#End Region

#Region "Constructeurs"

    Public Sub New(numero As String, solde As Double)
        Me.Numero = numero
        Me.Solde = solde
    End Sub

    Public Sub New()
    End Sub


#End Region

#Region "Méthodes"

    Public Sub Depot(montant As Double)
        Me.Solde += montant
    End Sub

    ''' <summary>
    ''' Méthode de retait d'un montant à partir d'un compte
    ''' </summary>
    ''' <param name="montant">montant à retirer</param>
    ''' <exception cref="Exception">Si solde inférieur au montant la méthode génère une exception</exception>
    Public Sub Retrait(montant As Double)
        If Me.Solde >= montant Then
            Me.Solde -= montant
        Else
            Throw New Exception("Solde insuffisant......")
        End If
    End Sub

    Public Overrides Function ToString() As String
        Return $"Numéro: {Me.Numero} - Solde: {Me.Solde}"
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Dim bancaire = TryCast(obj, CompteBancaire)
        Return bancaire IsNot Nothing AndAlso
               Numero = bancaire.Numero
    End Function

    Public Overrides Function GetHashCode() As Integer
        Dim hashCode As Long = -1608181971
        hashCode = (hashCode * -1521134295 + EqualityComparer(Of String).Default.GetHashCode(Numero)).GetHashCode()
        Return hashCode
    End Function

    Public Shared Sub ChangerBanque(nomBanque As String)
        Banque = nomBanque
    End Sub

#End Region

End Class
