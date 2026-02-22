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

Imports System.Reflection

Module Program

    Private name As String
    Private version As String
    Private copyright As String

    Sub Main(Args As String())

        ' Anzahl der übergebenen Argumente prüfen
        If Args.Length = 0 Then
            ' Fehlermeldung anzeigen wenn keine Argumente angegeben sind	und Ende
            ShowErrorMsg($"Es wurden keine Parameter angegeben!")
            Return
        ElseIf Args.Length = 1 Then
            ' Parameter prüfen
            ScanArgs(Args(0))
        ElseIf Args.Length > 1 Then
            ' Fehlermeldung anzeigen wenn zu viele Argumente angegeben sind	und Ende
            ShowErrorMsg($"Es wurden zu viele Parameter angegeben!")
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
                ShowErrorMsg($"Der angegebene Parameter '{Arg}' ist ungültig!")
                Return
        End Select
    End Sub

    Private Sub ShowErrorMsg(Message As String)
        ' Programmheader anzeigen
        ShowAppHeader()
        Console.WriteLine($"Fehler!{vbCrLf}{Message}{vbCrLf}")
        ShowHelp()
    End Sub

    Private Sub ShowHelp()
        Console.WriteLine($"Verwendungsbeispiel:{vbCrLf}{name} /opt{vbCrLf}")
        Console.WriteLine($"mögliche Werte für /opt sind:{vbCrLf}")
        Console.WriteLine($"/logoff -> Benutzer abmelden")
        Console.WriteLine($"/poweroff -> Herunterfahren und ausschalten")
        Console.WriteLine($"/reboot -> Herunterfahren und neu starten")
        Console.WriteLine($"/shutdown -> Herunterfahren und ausschalten")
        Console.WriteLine($"/suspend -> Energiesparmodus")
        Console.WriteLine($"/hibernate -> Ruhezustand")
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
