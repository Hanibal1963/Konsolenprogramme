' ****************************************************************************************************************
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
Option Strict On

Imports System.Reflection

Module Programm

	Private Const MaxTones As Integer = 99
	Private Const MinTones As Integer = 0
	Private name As String
	Private version As String
	Private copyright As String

	Sub Main(Args As String())

		'Anzahl der übergebenen Argumente prüfen
		If Args.Length = 0 Then

			'Fehlermeldung anzeigen wenn keine Argumente angegeben sind	und Ende
			ShowErrorMsg($"Es wurden keine Parameter angegeben!")
			Return
		End If

		'Wenn Argumente angegeben wurden -> 1. Argument einlesen
		Dim Arg As String = Args(0)

		'Fehlertest des eingelesenen Arguments
		If Arg.StartsWith("/n:", StringComparison.OrdinalIgnoreCase) Then

			' Wert des Arguments ermitteln
			Dim ArgWert As String = Arg.Substring(3)

			' Fehlertest des Argumentwertes
			Dim Wert As Integer
			If Integer.TryParse(ArgWert, Wert) Then

				' Argumentwert ist gültig -> Wert begrenzen
				Wert = Math.Max(MinTones, Math.Min(MaxTones, Wert))

				' Ausgabe der Töne
				For n As Integer = 0 To Wert
					Console.Beep()
				Next
			Else

				' Ungültiger Zahlenwert
				ShowErrorMsg($"Der angegebene Wert ist keine gültige Zahl.")
			End If
		Else

			' Argument ist fehlerhaft -> Fehlermeldung ausgeben
			ShowErrorMsg($"Das angegebene Argument ""{Arg}"" ist fehlerhaft!")
		End If
	End Sub

	Private Sub ShowErrorMsg(Message As String)
		' Programmheader anzeigen
		ShowAppHeader()
		Console.WriteLine($"Fehler!{vbCrLf}{Message}{vbCrLf}")
		ShowHelp()
	End Sub

	Private Sub ShowHelp()
		Console.WriteLine($"Verwendungsbeispiel:{vbCrLf}{name} /n:[NN]{vbCrLf}")
	End Sub

	Private Sub ShowAppHeader()
		'name = My.Application.Info.AssemblyName
		name = Assembly.GetExecutingAssembly().GetName().Name
		'version = My.Application.Info.Version.ToString
		version = Assembly.GetExecutingAssembly().GetName().Version.ToString()
		'copyright = My.Application.Info.Copyright
		copyright = GetAssemblyCopyright()
		Console.WriteLine($"{name} V{version}{vbCrLf}{copyright}{vbCrLf}")
	End Sub

	Private Function GetAssemblyCopyright() As String
		Dim assembly As Assembly = Assembly.GetExecutingAssembly()
		Dim attributes As Object() = assembly.GetCustomAttributes(GetType(AssemblyCopyrightAttribute), False)
		If attributes.Length > 0 Then
			Dim copyrightAttribute As AssemblyCopyrightAttribute = CType(attributes(0), AssemblyCopyrightAttribute)
			Return copyrightAttribute.Copyright
		End If
		Return String.Empty
	End Function

End Module
