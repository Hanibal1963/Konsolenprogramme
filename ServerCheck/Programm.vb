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

Imports System.Net.NetworkInformation
Imports System.Reflection

Module Programm

    ' Server läuft
    Private Const ERROR_SERVER_OK As Integer = 0
    ' Server läuft nicht
    Private Const ERROR_SERVER_DOWN As Integer = 1
    ' Fehlerhafte Kommandozeile
    Private Const ERROR_BAD_COMMANDLINE As Integer = 2

    Private name As String
    Private version As String
    Private copyright As String

    Sub Main(Args As String())
        'Anzahl der übergebenen Argumente prüfen
        If Args.Length = 0 Then
            'Programmheader anzeigen
            ShowAppHeader()
            'Fehler -> Fehler in der Kommandozeile
            Console.WriteLine($"Fehler in der Kommandozeile!")
            Console.WriteLine($"Es wurde kein Computer angegeben.")
            ShowHelp()
            Environment.ExitCode = ERROR_BAD_COMMANDLINE
            Exit Sub
        Else
            'erstes Argument auslesen (Servername)
            Dim server As String = Args.First
            'Prüfen ob Server online ist
            Dim ping As New Ping
            If ping.Send(server).Status = IPStatus.Success Then
                'Server ist online ->
                Console.WriteLine($"{server} ist online.")
                Environment.ExitCode = ERROR_SERVER_OK
                Exit Sub
            Else
                'Server ist nicht online ->
                Console.WriteLine($"{server} ist nicht online.")
                Environment.ExitCode = ERROR_SERVER_DOWN
                Exit Sub
            End If
        End If
    End Sub

    Private Sub ShowHelp()
        Console.WriteLine($"")
        Console.WriteLine($"Verwendungsbeispiel:")
        Console.WriteLine($"{name} Computername")
        Console.WriteLine($"")
        Console.WriteLine($"Beendiggungscodes: 0,1 oder 2")
        Console.WriteLine($"ERRORLEVEL 0 -> Computer ist online")
        Console.WriteLine($"ERRORLEVEL 1 -> Computer ist offline")
        Console.WriteLine($"ERRORLEVEL 2 -> Fehlerhafte Kommandozeile")
    End Sub

    Private Sub ShowAppHeader()
        'name = My.Application.Info.AssemblyName
        name = Assembly.GetExecutingAssembly().GetName().Name
        'version = My.Application.Info.Version.ToString
        version = Assembly.GetExecutingAssembly().GetName().Version.ToString()
        'copyright = My.Application.Info.Copyright
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
