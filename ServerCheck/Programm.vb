' --------------------------------------------------------------------------------------------------------
' Datei: Programm.vb
' Author: Andreas Sauer
' Datum: 22.02.2026
' Beschreibung:
' Kommandozeilentool um das vorhandensein eines Computeres im lokalen Netzwerk festzustellen.
' Verwendung: ServerCheck Computername
' Beendiggungscodes: 0,1 oder 2
' ERRORLEVEL 0 -> Computer ist online
' ERRORLEVEL 1 -> Computer ist offline
' ERRORLEVEL 2 -> Fehlerhafte Kommandozeile
' --------------------------------------------------------------------------------------------------------

Module Programm

    Private Const ERROR_SERVER_OK As Integer = 0 ' Server läuft
    Private Const ERROR_SERVER_DOWN As Integer = 1 ' Server läuft nicht
    Private Const ERROR_BAD_COMMANDLINE As Integer = 2 ' Fehlerhafte Kommandozeile

    Sub Main(Args As String())

        'Anzahl der übergebenen Argumente prüfen
        If Args.Length = 0 Then

            ConsoleHelper.ShowErrorMsg(My.Application.Info, $"{My.Resources.ErrorMsg_01}", $"{My.Resources.HelpMsg}")
            Environment.ExitCode = ERROR_BAD_COMMANDLINE
            Exit Sub

        Else

            Dim server As String = Args.First ' erstes Argument auslesen (Servername)
            Dim ping As New System.Net.NetworkInformation.Ping ' Prüfen ob Server online ist

            If ping.Send(server).Status = System.Net.NetworkInformation.IPStatus.Success Then

                ' Server ist online ->
                Console.WriteLine($"{server} ist online.")
                Environment.ExitCode = ERROR_SERVER_OK
                Exit Sub

            Else

                ' Server ist nicht online ->
                Console.WriteLine($"{server} ist nicht online.")
                Environment.ExitCode = ERROR_SERVER_DOWN
                Exit Sub

            End If

        End If

    End Sub

End Module
