' ****************************************************************************************************************
' Programm.vb
' � 2025 by Andreas Sauer
'
' Beschreibung: 
' Konsolenprogramm zum ausgeben von Signalt�nen.
'
' Verwendung:
' Beep /n:[NN]
'
' Parameter NN:
' Anzahl der T�ne (0-99)
'
' ****************************************************************************************************************
'

Imports System.Reflection

Module Programm

	Private Const MaxTones As Integer = 99
	Private Const MinTones As Integer = 0
	Private name As String
	Private version As String
	Private copyright As String

	Sub Main(Args As String())
		'Anzahl der �bergebenen Argumente pr�fen
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
			Dim ArgWert As String = Split(Arg, ":", -1, CompareMethod.Text)(1)
			' Fehlertest des Argumentwertes
			Dim Wert As Integer
			If Integer.TryParse(ArgWert, Wert) Then
				' Argumentwert ist g�ltig -> Wert begrenzen
				Wert = Math.Max(MinTones, Math.Min(MaxTones, Wert))
				' Ausgabe der T�ne
				For n As Integer = 0 To Wert
					Console.Beep()
				Next
			Else
				' Ung�ltiger Zahlenwert
				ShowErrorMsg($"Der angegebene Wert ist keine g�ltige Zahl.")
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
		name = Assembly.GetExecutingAssembly().GetName().Name
		version = Assembly.GetExecutingAssembly().GetName().Version.ToString()
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
