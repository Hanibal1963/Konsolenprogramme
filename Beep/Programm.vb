' --------------------------------------------------------------------------------------------------------
' Datei: Programm.vb
' Author: Andreas Sauer
' Datum: 22.02.2026
' Beschreibung:
' Kommandozeilentool um eine bestimmte Anzahl Töne auszugeben.
' Verwendung: Beep /n:[NN]
' NN = Anzahl der Töne (0-99).
' --------------------------------------------------------------------------------------------------------

Module Programm

    Private Const MaxTones As Integer = 99
    Private Const MinTones As Integer = 0

    Sub Main(Args As String())

        ' Anzahl der übergebenen Argumente prüfen
        If Args.Length = 0 Then

            ' Fehlermeldung anzeigen wenn keine Argumente angegeben sind	und Ende
            ConsoleHelper.ShowErrorMsg(My.Application.Info, $"{My.Resources.ErrorMsg_01}", $"{My.Resources.HelpString}")
            Return

        End If

        ' Wenn Argumente angegeben wurden -> 1. Argument einlesen
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

                ' Ungültiger Zahlenwert -> Fehlermeldung ausgeben
                ConsoleHelper.ShowErrorMsg(My.Application.Info, $"{My.Resources.ErrorMsg_02}", $"{My.Resources.HelpString}")

            End If

        Else

            ' Argument ist fehlerhaft -> Fehlermeldung ausgeben
            ConsoleHelper.ShowErrorMsg(My.Application.Info, $"{My.Resources.ErrorMsg_03}", $"{My.Resources.HelpString}")

        End If

    End Sub

End Module
