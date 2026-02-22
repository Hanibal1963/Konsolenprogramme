
Imports System.Runtime.InteropServices
Imports System.Text

''' <summary>
''' Implementiert Methoden zum Beenden von Windows.
''' </summary>
Friend Class WindowsController

    ''' <summary>
    ''' Beendet Windows (und versucht, erforderliche Zugriffsrechte zu aktivieren, falls
    ''' notwendig).
    ''' </summary>
    ''' <param name="how">Einer der RestartOptions-Werte, der angibt, wie Windows
    ''' beendet wird.</param>
    ''' <param name="force">True, wenn das Beenden erzwungen werden muss, andernfalls
    ''' false.</param>
    ''' <exception cref="PrivilegeException">Beim Anfordern einer erforderlichen
    ''' Berechtigung ist ein Fehler aufgetreten.</exception>
    ''' <exception cref="PlatformNotSupportedException">Die angeforderte
    ''' Beendigungsmethode wird auf dieser Plattform nicht unterstützt.</exception>
    Public Shared Sub ExitWindows(how As RestartOptions, force As Boolean)
        Select Case how
            Case RestartOptions.Suspend
                SuspendSystem(False, force)
            Case RestartOptions.Hibernate
                SuspendSystem(True, force)
            Case Else
                ExitWindows(CType(how, Integer), force)
        End Select
    End Sub

    ''' <summary>
    ''' Beendet Windows (und versucht, erforderliche Zugriffsrechte zu aktivieren, falls
    ''' notwendig).
    ''' </summary>
    ''' <remarks>
    ''' Diese Methode kann das System weder in den Ruhezustand noch in den Standby
    ''' versetzen.
    ''' </remarks>
    ''' <param name="how">Einer der RestartOptions-Werte, der angibt, wie Windows
    ''' beendet wird.</param>
    ''' <param name="force">True, wenn das Beenden erzwungen werden muss, andernfalls
    ''' false.</param>
    ''' <exception cref="PrivilegeException">Beim Anfordern einer erforderlichen
    ''' Berechtigung ist ein Fehler aufgetreten.</exception>
    Protected Shared Sub ExitWindows(how As Integer, force As Boolean)
        EnableToken("SeShutdownPrivilege")
        If force Then how = how Or EWX_FORCE
        If ExitWindowsEx(how, 0) = 0 Then Throw New PrivilegeException(FormatError(Marshal.GetLastWin32Error))
    End Sub

    ''' <summary>
    ''' Versucht, die angegebene Berechtigung zu aktivieren.
    ''' </summary>
    ''' <param name="privilege">Die zu aktivierende Berechtigung.</param>
    ''' <exception cref="PrivilegeException">Beim Anfordern einer erforderlichen
    ''' Berechtigung ist ein Fehler aufgetreten.</exception>
    Protected Shared Sub EnableToken(privilege As String)
        If (Environment.OSVersion.Platform <> PlatformID.Win32NT) OrElse (Not CheckEntryPoint("advapi32.dll", "AdjustTokenPrivileges")) Then Return
        Dim tokenHandle As IntPtr
        Dim privilegeLUID As LUID
        Dim newPrivileges As TOKEN_PRIVILEGES
        Dim tokenPrivileges As TOKEN_PRIVILEGES
        If OpenProcessToken(Process.GetCurrentProcess.Handle, TOKEN_ADJUST_PRIVILEGES Or TOKEN_QUERY, tokenHandle) = 0 Then Throw New PrivilegeException(FormatError(Marshal.GetLastWin32Error))
        If LookupPrivilegeValue("", privilege, privilegeLUID) = 0 Then Throw New PrivilegeException(FormatError(Marshal.GetLastWin32Error))
        tokenPrivileges.PrivilegeCount = 1
        tokenPrivileges.Privileges.Attributes = SE_PRIVILEGE_ENABLED
        tokenPrivileges.Privileges.pLuid = privilegeLUID
        If AdjustTokenPrivileges(tokenHandle, 0, tokenPrivileges, 4 + (12 * tokenPrivileges.PrivilegeCount), newPrivileges, 4 + (12 * newPrivileges.PrivilegeCount)) = 0 Then Throw New PrivilegeException(FormatError(Marshal.GetLastWin32Error))
    End Sub

    ''' <summary>
    ''' Versetzt das System in den Standby oder Ruhezustand.
    ''' </summary>
    ''' <param name="hibernate">True, wenn das System in den Ruhezustand versetzt werden
    ''' soll, false, wenn das System in den Standby versetzt werden soll.</param>
    ''' <param name="force">True, wenn das Beenden erzwungen werden muss, andernfalls
    ''' false.</param>
    ''' <exception cref="PlatformNotSupportedException">Die angeforderte
    ''' Beendigungsmethode wird auf dieser Plattform nicht unterstützt.</exception>
    Protected Shared Sub SuspendSystem(hibernate As Boolean, force As Boolean)
        If Not CheckEntryPoint("powrprof.dll", "SetSuspendState") Then Throw New PlatformNotSupportedException("The SetSuspendState method is not supported on this system!")
        SetSuspendState(CType(IIf(hibernate, 1, 0), Integer), CType(IIf(force, 1, 0), Integer), 0)
    End Sub

    ''' <summary>
    ''' Prüft, ob eine angegebene Methode auf dem lokalen Computer vorhanden ist.
    ''' </summary>
    ''' <param name="library">Die Bibliothek, die die Methode enthält.</param>
    ''' <param name="method">Der Einstiegspunkt der angeforderten Methode.</param>
    ''' <returns>
    ''' True, wenn die angegebene Methode vorhanden ist, andernfalls false.
    ''' </returns>
    Protected Shared Function CheckEntryPoint(library As String, method As String) As Boolean
        Dim libPtr As IntPtr = LoadLibrary(library)
        If Not libPtr.Equals(IntPtr.Zero) Then
            If Not GetProcAddress(libPtr, method).Equals(IntPtr.Zero) Then
                FreeLibrary(libPtr)
                Return True
            End If
            FreeLibrary(libPtr)
        End If
        Return False
    End Function

    ''' <summary>
    ''' Formatiert eine Fehlernummer in eine Fehlermeldung.
    ''' </summary>
    ''' <param name="number">Die zu konvertierende Fehlernummer.</param>
    ''' <returns>
    ''' Eine Zeichenfolgedarstellung der angegebenen Fehlernummer.
    ''' </returns>
    Protected Shared Function FormatError(number As Integer) As String
        Try
            Dim buffer As New StringBuilder(255)
            FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM, IntPtr.Zero, number, 0, buffer, buffer.Capacity, 0)
            Return buffer.ToString()
        Catch e As Exception
            Return "Unspecified error [" + number.ToString() + "]"
        End Try
    End Function

End Class
