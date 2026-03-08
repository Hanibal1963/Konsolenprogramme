' --------------------------------------------------------------------------------------------------------
' Datei: ConsoleHelper.vb
' Author: Andreas Sauer
' Datum: 08.03.2026
' Beschreibung:
' Hilfsfunktionen für die Ausgabe von Fehlermeldungen, Hilfemeldungen und Programmheader in der Konsole.
' --------------------------------------------------------------------------------------------------------

Imports Microsoft.VisualBasic.ApplicationServices

''' <summary>
''' Diese Klasse definiert Hilfsfunktionen für die Ausgabe von Fehlermeldungen,
''' <br/>
''' Hilfemeldungen und Programmheader in der Konsole.
''' </summary>
Public Class ConsoleHelper

    ''' <summary>
    ''' Zeigt den Programmheader, eine Fehlermeldung und eine Hilfemeldung in der
    ''' Konsole an.
    ''' </summary>
    ''' <param name="ErrorMsg">Die anzuzeigende Fehlermeldung.</param>
    ''' <param name="HelpMsg">Die anzuzeigende Hilfemeldung.</param>
    ''' <param name="AppInfo">Die Assembly-Informationen der Anwendung.</param>
    Public Shared Sub ShowErrorMsg(ErrorMsg As String, HelpMsg As String, AppInfo As AssemblyInfo)
        ShowAppInfo(AppInfo) ' Programmheader anzeigen
        ShowErrorMsg(ErrorMsg) ' Fehlermeldung anzeigen
        ShowHelpMsg(HelpMsg)        ' Hilfemeldung anzeigen
    End Sub

    ''' <summary>
    ''' Zeigt eine Fehlermeldung und eine Hilfemeldung in der Konsole an.
    ''' </summary>
    ''' <param name="ErrorMsg">Die anzuzeigende Fehlermeldung.</param>
    ''' <param name="HelpMsg">Die anzuzeigende Hilfemeldung.</param>
    Public Shared Sub ShowErrorMsg(ErrorMsg As String, HelpMsg As String)
        ShowErrorMsg(ErrorMsg)
        ShowHelpMsg(HelpMsg)
    End Sub

    ''' <summary>
    ''' Zeigt eine Fehlermeldung und den Programmheader in der Konsole an.
    ''' </summary>
    ''' <param name="ErrorMsg">Die anzuzeigende Fehlermeldung.</param>
    ''' <param name="AppInfo">Die Assembly-Informationen der Anwendung.</param>
    Public Shared Sub ShowErrorMsg(ErrorMsg As String, AppInfo As AssemblyInfo)
        ShowErrorMsg(ErrorMsg)
        ShowAppInfo(AppInfo)
    End Sub

    ''' <summary>
    ''' Zeigt eine Fehlermeldung in der Konsole an.
    ''' </summary>
    ''' <param name="ErrorMsg">Die anzuzeigende Fehlermeldung.</param>
    Public Shared Sub ShowErrorMsg(ErrorMsg As String)
        Console.WriteLine($"{ErrorMsg}")
    End Sub

    ''' <summary>
    ''' Zeigt eine Hilfemeldung in der Konsole an.
    ''' </summary>
    ''' <param name="HelpMsg">Die anzuzeigende Hilfemeldung.</param>
    Public Shared Sub ShowHelpMsg(HelpMsg As String)
        Console.WriteLine($"{HelpMsg}")
    End Sub

    ''' <summary>
    ''' Zeigt den Programmheader mit Name, Version und Copyright-Informationen in der
    ''' Konsole an.
    ''' </summary>
    ''' <param name="AppInfo">Die Assembly-Informationen der Anwendung.</param>
    Public Shared Sub ShowAppInfo(AppInfo As AssemblyInfo)
        Dim name = AppInfo.AssemblyName
        Dim version = AppInfo.Version.ToString
        Dim copyright = AppInfo.Copyright
        Console.WriteLine($"{name} V{version}{vbCrLf}{copyright}{vbCrLf}")
    End Sub

End Class
