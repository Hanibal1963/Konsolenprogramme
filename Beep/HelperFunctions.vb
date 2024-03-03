' ****************************************************************************************************************
' HelperFunctions.vb
' © 2024 by Andreas Sauer
' ****************************************************************************************************************
'

Imports System.Reflection

Module HelperFunctions

    Private name As String
    Private version As String
    Private copyright As String

    Friend Sub ShowHelp()

        Console.WriteLine($"")
        Console.WriteLine($"Verwendungsbeispiel:")
        Console.WriteLine($"{name} /n:[NN]")
        Console.WriteLine("")
        Console.WriteLine()

    End Sub

    Friend Sub ShowAppHeader()

        name = My.Application.Info.AssemblyName
        version = My.Application.Info.Version.ToString
        copyright = My.Application.Info.Copyright
        Console.WriteLine($"{name} V{version}{vbCrLf}{copyright}")

    End Sub

End Module
