' ****************************************************************************************************************
' Programm.vb
' © 2024 by Andreas Sauer
'
'Beschreibung:
'Konsolenprogramm zum feststellen ob ein Computer im lokalen Netzwerk erreichbar ist.
'
'Verwendung:
'ServerCheck Computername
'
'Ergebnis in der Errorlevel-Variable des Systems
'0 = Computer ist erreichbar
'1 = Computer ist nicht erreichbar
'2 = fehlerhafte Kommandozeile
'
' ****************************************************************************************************************

Imports System.Net.NetworkInformation

Module Programm

	Sub Main(args As String())

		'Programmheader anzeigen
		ShowAppHeader()

		'Anzahl der übergebenen Argumente prüfen
		If args.Length = 0 Then

			'Fehler -> Fehler in der Kommandozeile
			Console.WriteLine($"Fehler in der Kommandozeile!")
			Console.WriteLine($"Es wurde kein Computer angegeben.")
			ShowHelp()
			Environment.ExitCode = ERROR_BAD_COMMANDLINE
			Exit Sub

		Else

			'erstes Argument auslesen (Servername)
			Dim server As String = args.First

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

End Module
