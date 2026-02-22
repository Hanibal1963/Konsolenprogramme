' --------------------------------------------------------------------------------------------------------
' Datei: Programm.vb
' Author: Andreas Sauer
' Datum: 22.02.2026
' Beschreibung:
' Kommandozeilentool um die Batchverarbeitung eine bestimmte Anzahl von Sekunden anzuhalten.
' Verwendung: Wait /n:[NN]
' NN = Wartezeit in Sekunden (0-99).
' --------------------------------------------------------------------------------------------------------

Imports System.Timers

Module Programm

    Private Const MaxTime As Integer = 99
    Private Const MinTime As Integer = 0

    Private otimer As Timer
    Private timeout As Boolean

    Sub Main(Args As String())
        'Anzahl der übergebenen Argumente prüfen
        If Args.Length = 0 Then

            ' Fehlermeldung anzeigen wenn keine Argumente angegeben sind	und Ende
            ConsoleHelper.ShowErrorMsg(My.Application.Info, $"{My.Resources.ErrorMsg_01}", $"{My.Resources.HelpString}")
            Return

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
                        ' BUG: Überprüfung ob gültige Zahl
                        If Wert > MaxTime Then
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

                'Argument ist fehlerhaft -> Fehlermeldung ausgeben und Ende
                ConsoleHelper.ShowErrorMsg(My.Application.Info, $"{My.Resources.ErrorMsg_02}", $"{My.Resources.HelpString}")

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

End Module
