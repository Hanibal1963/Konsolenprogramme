' ****************************************************************************************************************
' Programm.vb
' © 2024 by Andreas Sauer
'
' Beschreibung: 
' Konsolenprogramm zum ausgeben von Signaltönen
'
' Verwendung:
' Beep /n:[NN]
'
' Parameter NN: 0-99
'
' ****************************************************************************************************************
'

Module Programm

	Sub Main(args As String())

		'Programmheader anzeigen
		ShowAppHeader()

		'Anzahl der übergebenen Argumente prüfen
		If args.Length = 0 Then

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

				'Argument ist fehlerhaft -> Fehlermeldung ausgeben
				Console.WriteLine($"Fehler !")
				Console.WriteLine($"Das angegebene Argument ""{Arg}"" ist fehlerhaft {vbCrLf}")

				'Hilfe
				ShowHelp()

				'Programmende
				Exit Sub

			End If

		End If









		'	End If
		'End If

	End Sub

End Module
