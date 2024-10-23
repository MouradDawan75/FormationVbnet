Module Module1

    Sub Main()

        Dim b As New B()
        b.a = 321
        b.MethodB()

        Console.WriteLine(b.a)

        'Maintenir la console active
        Console.ReadLine()

    End Sub

End Module
