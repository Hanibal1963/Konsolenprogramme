' ****************************************************************************************************************
' Programm.vb
' © 2025 by Andreas Sauer
'
' Beschreibung:
' Konsolenprogramm welches die Abarbeitung einer Batch Datei für eine festgelegte Zeit anhält.
'
' Verwendung:
' Wait /n:[NN]
'
' Parameter NN:
' Wartezei in Sekunden (0-99)
'
' ****************************************************************************************************************
'

Imports System.Timers
Imports System.Reflection

Module Programm

	Private name As String
	Private version As String
	Private copyright As String
	Private otimer As Timer
	Private timeout As Boolean

	Sub Main(Args As String())
		'Anzahl der übergebenen Argumente prüfen
		If Args.Length = 0 Then
			'Programmheader anzeigen
			ShowAppHeader()
			'Fehlermeldung anzeigen
			Console.WriteLine($"Fehler in der Kommandozeile.")
			Console.WriteLine($"Es wurden keine Parameter angegeben")
			'Hilfe anzeigen
			ShowHelp()
		Else
			'wenn Argumente angegeben wurden -> 1. Argument einlesen
			Dim Arg As String = Args(0)
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
						'Timer setzen
						SetTimer(Wert)
						'auf Timeout warten
						timeout = False
						Do Until timeout = True
						Loop
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

	Private Sub SetTimer(Wert As Integer)
		'neuen Timer erstellen
		otimer = New Timer(Wert * 1000)
		'Eventbearbeitung setzen
		AddHandler otimer.Elapsed, AddressOf OnTimerEvent
		'Timer starten
		otimer.Enabled = True
	End Sub

	Private Sub OnTimerEvent(sender As Object, e As ElapsedEventArgs)
		'Zeit abgelaufen
		timeout = True
	End Sub

	Private Sub ShowHelp()
		Console.WriteLine($"")
		Console.WriteLine($"Verwendungsbeispiel:")
		Console.WriteLine($"{name} /n:[NN]")
		Console.WriteLine("")
		Console.WriteLine()
	End Sub

	Private Sub ShowAppHeader()
		name = Assembly.GetExecutingAssembly().GetName().Name
		version = Assembly.GetExecutingAssembly().GetName().Version.ToString()
		copyright = GetAssemblyCopyright()
		Console.WriteLine($"{name} V{version}{vbCrLf}{copyright}")
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
