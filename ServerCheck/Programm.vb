' ****************************************************************************************************************
' Programm.vb
' © 2024 by Andreas Sauer
'
' Beschreibung:
' Konsolenprogramm zum feststellen ob ein Computer im lokalen Netzwerk erreichbar ist.
'
' Verwendung:
' ServerCheck Computername
'
' Ergebnis in der Errorlevel-Variable des Systems
' 0 = Computer ist erreichbar
' 1 = Computer ist nicht erreichbar
' 2 = fehlerhafte Kommandozeile
'
' ****************************************************************************************************************

Imports System.Net.NetworkInformation

Module Programm

	Private Const ERROR_SERVER_OK As Integer = 0        'Server läuft
	Private Const ERROR_SERVER_DOWN As Integer = 1      'Server läuft nicht
	Private Const ERROR_BAD_COMMANDLINE As Integer = 2  'Fehlerhafte Kommandozeile

	Private name As String
	Private version As String
	Private copyright As String

	Sub Main(Args As String())
		'Anzahl der übergebenen Argumente prüfen
		If Args.Length = 0 Then
			'Programmheader anzeigen
			ShowAppHeader()
			'Fehler -> Fehler in der Kommandozeile
			Console.WriteLine($"Fehler in der Kommandozeile!")
			Console.WriteLine($"Es wurde kein Computer angegeben.")
			ShowHelp()
			Environment.ExitCode = ERROR_BAD_COMMANDLINE
			Exit Sub
		Else
			'erstes Argument auslesen (Servername)
			Dim server As String = Args.First
			'Prüfen ob Server online ist
			Dim ping As New Ping
			If ping.Send(server).Status = IPStatus.Success Then
				'Server ist online ->
				Console.WriteLine($"{server} ist online.")
				Environment.ExitCode = ERROR_SERVER_OK
				Exit Sub
			Else
				'Server ist nicht online ->
				Console.WriteLine($"{server} ist nicht online.")
				Environment.ExitCode = ERROR_SERVER_DOWN
				Exit Sub
			End If
		End If
	End Sub

	Private Sub ShowHelp()
		Console.WriteLine($"")
		Console.WriteLine($"Verwendungsbeispiel:")
		Console.WriteLine($"{name} Computername")
		Console.WriteLine($"")
		Console.WriteLine($"Beendiggungscodes: 0,1 oder 2")
		Console.WriteLine($"ERRORLEVEL 0 -> Computer ist online")
		Console.WriteLine($"ERRORLEVEL 1 -> Computer ist offline")
		Console.WriteLine($"ERRORLEVEL 2 -> Fehlerhafte Kommandozeile")
	End Sub

	Private Sub ShowAppHeader()
		name = My.Application.Info.AssemblyName
		version = My.Application.Info.Version.ToString
		copyright = My.Application.Info.Copyright
		Console.WriteLine($"{name} V{version}{vbCrLf}{copyright}")
	End Sub

End Module
