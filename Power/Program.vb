' --------------------------------------------------------------------------------------------------------
' Datei: Program.vb
' Author: Andreas Sauer
' Datum: 22.02.2026
' Beschreibung:
' Kommandozeilentool um den PC in die verschiedenen Energiezustände zu versetzen.
' Verwendung: Power /opt
' /opt kann einen der folgenden Werte haben:
' - /logfoff - > Benutzer abmelden
' - /poweroff -> Herunterfahren und ausschalten
' - /reboot -> Herunterfahren und neu starten
' - /shutdown -> Herunterfahren und ausschalten
' - /suspend -> Energiesparmodus
' - /hibernate -> Ruhezustand
' --------------------------------------------------------------------------------------------------------

Module Program

    Sub Main(Args As String())

        ' Anzahl der übergebenen Argumente prüfen
        If Args.Length = 0 Then
            ' Fehlermeldung anzeigen wenn keine Argumente angegeben sind	und Ende
            ConsoleHelper.ShowErrorMsg(My.Application.Info, $"{My.Resources.ErrorMsg_01}", $"{My.Resources.HelpMsg}")
            Return

        ElseIf Args.Length = 1 Then
            ' Parameter prüfen
            ScanArgs(Args(0))

        ElseIf Args.Length > 1 Then
            ' Fehlermeldung anzeigen wenn zu viele Argumente angegeben sind	und Ende
            ConsoleHelper.ShowErrorMsg(My.Application.Info, $"{My.Resources.ErrorMsg_02}", $"{My.Resources.HelpMsg}")
            Return

        End If

    End Sub

    Private Sub ScanArgs(Arg As String)

        Select Case Arg.ToLower()

            Case "/logoff"
                ' Benutzer abmelden
                WindowsController.ExitWindows(RestartOptions.LogOff, False)

            Case "/poweroff"
                ' Herunterfahren und ausschalten
                WindowsController.ExitWindows(RestartOptions.PowerOff, False)

            Case "/shutdown"
                ' Herunterfahren und ausschalten
                WindowsController.ExitWindows(RestartOptions.ShutDown, False)

            Case "/reboot"
                ' Herunterfahren und neu starten
                WindowsController.ExitWindows(RestartOptions.Reboot, False)

            Case "/suspend"
                ' Energiesparmodus
                WindowsController.ExitWindows(RestartOptions.Suspend, False)

            Case "/hibernate"
                ' Ruhezustand
                WindowsController.ExitWindows(RestartOptions.Hibernate, False)

            Case Else
                ' Fehlermeldung anzeigen wenn ungültiger Parameter angegeben ist	und Ende
                ConsoleHelper.ShowErrorMsg(My.Application.Info, $"{My.Resources.ErrorMsg_03}", $"{My.Resources.HelpMsg}")
                Return

        End Select
    End Sub

End Module
