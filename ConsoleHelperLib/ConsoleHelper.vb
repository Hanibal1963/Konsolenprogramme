
Imports Microsoft.VisualBasic.ApplicationServices

Public Class ConsoleHelper

    Public Shared Sub ShowErrorMsg(AppInfo As AssemblyInfo, ErrorMsg As String, HelpMsg As String)
        ' Programmheader anzeigen
        Dim name = AppInfo.AssemblyName
        Dim version = AppInfo.Version.ToString
        Dim copyright = AppInfo.Copyright
        Console.WriteLine($"{name} V{version}{vbCrLf}{copyright}{vbCrLf}")
        ' Fehlermeldung anzeigen
        Console.WriteLine($"{ErrorMsg}")
        ' Hilfemeldung anzeigen
        Console.WriteLine($"{HelpMsg}")
    End Sub

End Class
