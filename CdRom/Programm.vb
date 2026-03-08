' --------------------------------------------------------------------------------------------------------
' Datei: Programm.vb
' Author: Andreas Sauer
' Datum: 07.03.2026
' Beschreibung:
' Kommandozeilentool mit Funktionen für CD-Laufwerke.
' Verwendung:
' CDRom /opt:[LW]
' [LW] ist der Laufwerksbuchstabe eines CD-Laufwerks (z.B. D, E, F, ...).
' /opt: kann einen der folgenden Werte haben:
' /exist: - Prüft ob ein CD-Laufwerk mit dem angegebenen Buchstaben existiert.
' /open: - Öffnet die Schublade des CD-Laufwerks mit dem angegebenen Buchstaben.
' /close: - Schließt die Schublade des CD-Laufwerks mit dem angegebenen Buchstaben.
' Es werden folgende ERRORLEVEL zurückgegeben:
' ERRORLEVEL 0: CD-Laufwerk existiert.
' ERRORLEVEL 1: CD-Laufwerk existiert nicht oder ungültiger Buchstabe.
' --------------------------------------------------------------------------------------------------------

Imports System.IO
Imports System.Runtime.InteropServices

Module Programm

    Private Const ERROR_CDROM_EXISTS As Integer = 0
    Private Const ERROR_CDROM_NOT_EXISTS As Integer = 1

    ''' <summary>
    ''' Sendet einen MCI-Befehlsstring an das Multimedia-Subsystem (winmm.dll).
    ''' </summary>
    ''' <param name="lpszCommand">
    ''' Der MCI-Befehlsstring, der gesendet werden soll.
    ''' </param>
    ''' <param name="lpszReturnString">
    ''' Ein <see cref="System.Text.StringBuilder"/>, der die Rückgabeinformationen aufnimmt. Kann <c>Nothing</c> sein, wenn keine Rückgabe benötigt wird.
    ''' </param>
    ''' <param name="cchReturn">
    ''' Die Größe des Puffers für <paramref name="lpszReturnString"/> in Zeichen.
    ''' </param>
    ''' <param name="hwndCallback">
    ''' Handle eines Fensters, das eine MM_MCINOTIFY-Nachricht empfängt. Kann <see cref="IntPtr.Zero"/> sein.
    ''' </param>
    ''' <returns>
    ''' Gibt 0 zurück, wenn der Befehl erfolgreich war, andernfalls einen Fehlercode.
    ''' </returns>
    <DllImport("winmm.dll", EntryPoint:="mciSendStringW", CharSet:=CharSet.Unicode)>
    Private Function mciSendString(lpszCommand As String, lpszReturnString As System.Text.StringBuilder, cchReturn As Integer, hwndCallback As IntPtr) As Integer
    End Function

    ''' <summary>
    ''' Ruft eine lesbare Fehlermeldung für einen MCI-Fehlercode ab (winmm.dll).
    ''' </summary>
    ''' <param name="fdwError">
    ''' Der von <see cref="mciSendString"/> zurückgegebene Fehlercode.
    ''' </param>
    ''' <param name="lpszErrorText">
    ''' Ein <see cref="System.Text.StringBuilder"/>, der die Fehlermeldung als Zeichenkette aufnimmt.
    ''' </param>
    ''' <param name="cchErrorText">
    ''' Die maximale Anzahl der Zeichen, die in <paramref name="lpszErrorText"/> geschrieben werden dürfen.
    ''' </param>
    ''' <returns>
    ''' <c>True</c> wenn die Fehlermeldung erfolgreich abgerufen wurde, andernfalls <c>False</c>.
    ''' </returns>
    <DllImport("winmm.dll", EntryPoint:="mciGetErrorStringW", CharSet:=CharSet.Unicode)>
    Private Function mciGetErrorString(fdwError As Integer, lpszErrorText As System.Text.StringBuilder, cchErrorText As Integer) As Boolean
    End Function

    Sub Main(Args As String())

        ' Anzahl der übergebenen Argumente prüfen
        If Args.Length = 0 Then
            ' Fehlermeldung anzeigen wenn keine Argumente angegeben sind	und Ende
            ConsoleHelper.ShowErrorMsg($"{My.Resources.ErrorMsg_01}", $"{My.Resources.HelpString}", My.Application.Info)
            Return
        ElseIf Args.Length = 1 Then
            ' Parameter prüfen
            ScanArgs(Args(0))
        ElseIf Args.Length > 1 Then
            ' Fehlermeldung anzeigen wenn zu viele Argumente angegeben sind	und Ende
            ConsoleHelper.ShowErrorMsg($"{My.Resources.ErrorMsg_05}", My.Resources.HelpString, My.Application.Info)
            Return
        End If

    End Sub

    Private Sub ScanArgs(Arg As String)

        Select Case True
            Case Arg.StartsWith("/exist:", StringComparison.OrdinalIgnoreCase)
                Dim driveLetter As String = Arg.Substring(7).Trim().ToUpper()
                If IsCdDvdDrive(driveLetter) Then
                    ConsoleHelper.ShowErrorMsg(My.Resources.Message_01)
                    Environment.ExitCode = ERROR_CDROM_EXISTS
                    End
                Else
                    ConsoleHelper.ShowErrorMsg(My.Resources.Message_02)
                    Environment.ExitCode = ERROR_CDROM_NOT_EXISTS
                    End
                End If
            Case Arg.StartsWith("/open:", StringComparison.OrdinalIgnoreCase)
                Dim driveLetter As String = Arg.Substring(6).Trim().ToUpper()
                If IsCdDvdDrive(driveLetter) Then
                    ConsoleHelper.ShowErrorMsg(My.Resources.Message_01)
                    OpenDrive(driveLetter)
                    Environment.ExitCode = ERROR_CDROM_EXISTS
                    End
                Else
                    ConsoleHelper.ShowErrorMsg(My.Resources.Message_02)
                    Environment.ExitCode = ERROR_CDROM_NOT_EXISTS
                    End
                End If
            Case Arg.StartsWith("/close:", StringComparison.OrdinalIgnoreCase)
                Dim driveLetter As String = Arg.Substring(7).Trim().ToUpper()
                If IsCdDvdDrive(driveLetter) Then
                    ConsoleHelper.ShowErrorMsg(My.Resources.Message_01)
                    CloseDrive(driveLetter)
                    Environment.ExitCode = ERROR_CDROM_EXISTS
                    End
                Else
                    ConsoleHelper.ShowErrorMsg(My.Resources.Message_02)
                    Environment.ExitCode = ERROR_CDROM_NOT_EXISTS
                    End
                End If
            Case Else
                ' Argument ist fehlerhaft -> Fehlermeldung ausgeben
                ConsoleHelper.ShowErrorMsg(My.Resources.ErrorMsg_06, My.Resources.HelpString, My.Application.Info)
                End
        End Select

    End Sub

    ''' <summary>
    ''' Prüft ob das angegebene Laufwerk ein CD/DVD-Laufwerk ist.
    ''' </summary>
    ''' <param name="DriveLetter">Laufwerksbuchstabe, z. B. "D"</param>
    ''' <returns>True wenn es ein CD/DVD-Laufwerk ist, sonst False</returns>
    Function IsCdDvdDrive(DriveLetter As String) As Boolean
        Try
            Dim drive As New DriveInfo(DriveLetter)
            Return drive.DriveType = DriveType.CDRom
        Catch ex As ArgumentException
            ConsoleHelper.ShowErrorMsg(My.Resources.ErrorMsg_02, My.Resources.HelpString, My.Application.Info)
            Return False
        Catch ex As Exception
            ConsoleHelper.ShowErrorMsg($"{My.Resources.ErrorMsg_03}{vbCrLf}{ex.Message}", My.Resources.HelpString, My.Application.Info)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Öffnet das Fach eines CD/DVD-Laufwerks.
    ''' </summary>
    ''' <param name="driveLetter">Laufwerksbuchstabe, z. B. "D"</param>
    Sub OpenDrive(driveLetter As String)
        If Not IsCdDvdDrive(driveLetter) Then
            ConsoleHelper.ShowErrorMsg(My.Resources.ErrorMsg_04, My.Resources.HelpString, My.Application.Info)
            Return
        End If
        Dim errorcode As Integer
        Dim [alias] As String = $"cdrom_{driveLetter}"
        errorcode = mciSendString($"open {driveLetter}: type cdaudio alias {[alias]}", Nothing, 0, IntPtr.Zero)
        errorcode = mciSendString($"set {[alias]} door open", Nothing, 0, IntPtr.Zero)
        errorcode = mciSendString($"close {[alias]}", Nothing, 0, IntPtr.Zero)
    End Sub

    ''' <summary>
    ''' Schließt das Fach eines CD/DVD-Laufwerks.
    ''' </summary>
    ''' <param name="driveLetter">Laufwerksbuchstabe, z. B. "D"</param>
    Sub CloseDrive(driveLetter As String)
        If Not IsCdDvdDrive(driveLetter) Then
            ConsoleHelper.ShowErrorMsg(My.Resources.ErrorMsg_04, My.Resources.HelpString, My.Application.Info)
            Return
        End If
        Dim errorcode As Integer
        Dim [alias] As String = $"cdrom_{driveLetter}"
        errorcode = mciSendString($"open {driveLetter}: type cdaudio alias {[alias]}", Nothing, 0, IntPtr.Zero)
        errorcode = mciSendString($"set {[alias]} door closed", Nothing, 0, IntPtr.Zero)
        errorcode = mciSendString($"close {[alias]}", Nothing, 0, IntPtr.Zero)
    End Sub

End Module
