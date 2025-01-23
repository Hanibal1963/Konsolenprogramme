﻿' ****************************************************************************************************************
' Programm.vb
' © 2024 by Andreas Sauer
'
' Beschreibung: 
' Konsolenprogramm zum ausgeben von Signaltönen.
'
' Verwendung:
' Beep /n:[NN]
'
' Parameter NN:
' Anzahl der Töne (0-99)
'
' ****************************************************************************************************************
'

Module Programm

	Private name As String
	Private version As String
	Private copyright As String

	Sub Main(args As String())
		'Anzahl der übergebenen Argumente prüfen
		If args.Length = 0 Then
			'Programmheader anzeigen
			ShowAppHeader()
			'Fehlermeldung anzeigen
			Console.WriteLine($"Fehler in der Kommandozeile.")
			Console.WriteLine($"Es wurden keine Parameter angegeben")
			'Hilfe anzeigen
			ShowHelp()
		Else
			'wenn Argumente angegeben wurden -> 1. Argument einlesen
			Dim Arg As String = args(0)
			'Fehlertest des eingelesenen Arguments
			If InStr(Arg, "/n:", CompareMethod.Text) > 0 Then
				'Argument ist richtig -> Wert des Arguments ermitteln
				Dim ArgWert As String = Split(Arg, ":", -1, CompareMethod.Text)(1)
				'Fehlertest des Argumentwertes
				If ArgWert <> "" Then
					'Argumentwert ist nicht leer -> in Zahl wandeln
					Dim Wert As Integer = CInt(ArgWert)
					If Wert > 0 Then
						'Argumentwert ist > 0 ->  Test ob > 99
						If Wert > 99 Then
							'Wert ist > 99 -> auf 99 zurücksetzen
							Wert = 99
						End If
						'Ausgabe der Töne
						For n As Integer = 1 To Wert
							Console.Beep()
						Next
						'Programmende
						Exit Sub
					Else
						'Argumentwert ist 0 oder kleiner -> Programmende
						Exit Sub
					End If
				Else
					'Argumentwert ist leer -> Programmende
					Exit Sub
				End If
			Else
				'Programmheader anzeigen
				ShowAppHeader()
				'Argument ist fehlerhaft -> Fehlermeldung ausgeben
				Console.WriteLine($"Fehler !")
				Console.WriteLine($"Das angegebene Argument ""{Arg}"" ist fehlerhaft {vbCrLf}")
				'Hilfe anzeigen
				ShowHelp()
				'Programmende
				Exit Sub
			End If
		End If
	End Sub

	Private Sub ShowHelp()
		Console.WriteLine($"")
		Console.WriteLine($"Verwendungsbeispiel:")
		Console.WriteLine($"{name} /n:[NN]")
		Console.WriteLine("")
		Console.WriteLine()
	End Sub

	Private Sub ShowAppHeader()
		name = My.Application.Info.AssemblyName
		version = My.Application.Info.Version.ToString
		copyright = My.Application.Info.Copyright
		Console.WriteLine($"{name} V{version}{vbCrLf}{copyright}")
	End Sub

End Module
