' ****************************************************************************************************************
' HelperFunctions.vb
' © 2024 by Andreas Sauer
' ****************************************************************************************************************
'

Imports System.Reflection

Module HelperFunctions

	'Private assembly As Assembly
	Private name As String
	Private version As String
	Private copyright As String

	Friend Sub ShowHelp()

		Console.WriteLine($"")
		Console.WriteLine($"Verwendungsbeispiel:")
		Console.WriteLine($"{name} Computername")
		Console.WriteLine($"")
		Console.WriteLine($"Beendiggungscodes: 0,1 oder 2")
		Console.WriteLine($"ERRORLEVEL 0 -> Computer ist online")
		Console.WriteLine($"ERRORLEVEL 1 -> Computer ist offline")
		Console.WriteLine($"ERRORLEVEL 2 -> Fehlerhafte Kommandozeile")

	End Sub

	Friend Sub ShowAppHeader()

		name = My.Application.Info.AssemblyName
		version = My.Application.Info.Version.ToString
		copyright = My.Application.Info.Copyright
		Console.WriteLine($"{name} V{version}{vbCrLf}{copyright}")

	End Sub

End Module
