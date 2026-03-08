
Imports Microsoft.VisualBasic.ApplicationServices

Public Class ConsoleHelper

    Public Shared Sub ShowErrorMsg(ErrorMsg As String, HelpMsg As String, AppInfo As AssemblyInfo)
        '' Programmheader anzeigen
        'Dim name = AppInfo.AssemblyName
        'Dim version = AppInfo.Version.ToString
        'Dim copyright = AppInfo.Copyright

        'Console.WriteLine($"{name} V{version}{vbCrLf}{copyright}{vbCrLf}")

        ShowAppInfo(AppInfo)

        '' Fehlermeldung anzeigen
        'Console.WriteLine($"{ErrorMsg}")
        ShowErrorMsg(ErrorMsg)

        '' Hilfemeldung anzeigen
        'Console.WriteLine($"{HelpMsg}")

        ShowHelpMsg(HelpMsg)

    End Sub

    Public Shared Sub ShowErrorMsg(ErrorMsg As String, HelpMsg As String)
        ShowErrorMsg(ErrorMsg)
        ShowHelpMsg(HelpMsg)
    End Sub

    Public Shared Sub ShowErrorMsg(ErrorMsg As String, AppInfo As AssemblyInfo)
        ShowErrorMsg(ErrorMsg)
        ShowAppInfo(AppInfo)
    End Sub

    Public Shared Sub ShowErrorMsg(ErrorMsg As String)
        Console.WriteLine($"{ErrorMsg}")
    End Sub

    Public Shared Sub ShowHelpMsg(HelpMsg As String)
        Console.WriteLine($"{HelpMsg}")
    End Sub

    Public Shared Sub ShowAppInfo(AppInfo As AssemblyInfo)
        Dim name = AppInfo.AssemblyName
        Dim version = AppInfo.Version.ToString
        Dim copyright = AppInfo.Copyright
        Console.WriteLine($"{name} V{version}{vbCrLf}{copyright}{vbCrLf}")
    End Sub

End Class
