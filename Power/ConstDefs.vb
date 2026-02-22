
''' <summary>
''' Dieses Modul definiert die verwendeten Konstanten.
''' </summary>
Module ConstDefs

    ''' <summary>
    ''' Erforderlich, um die Berechtigungen in einem Zugriffstoken zu aktivieren oder zu deaktivieren.
    ''' </summary>
    Friend Const TOKEN_ADJUST_PRIVILEGES As Integer = &H20

    ''' <summary>
    ''' Erforderlich, um ein Zugriffstoken abzufragen.
    ''' </summary>
    Friend Const TOKEN_QUERY As Integer = &H8

    ''' <summary>
    ''' Die Berechtigung ist aktiviert.
    ''' </summary>
    Friend Const SE_PRIVILEGE_ENABLED As Integer = &H2

    ''' <summary>
    ''' Gibt an, dass die Funktion die Systemnachrichtentabellenressource(n) nach der angeforderten Nachricht durchsuchen soll.
    ''' </summary>
    Friend Const FORMAT_MESSAGE_FROM_SYSTEM As Integer = &H1000

    ''' <summary>
    ''' Erzwingt das Beenden von Prozessen.<br/>
    ''' Wenn dieses Flag gesetzt ist, sendet das System die Nachrichten
    ''' WM_QUERYENDSESSION und WM_ENDSESSION nicht.<br/>
    ''' Dadurch können Anwendungen Daten verlieren.<br/>
    ''' Daher sollte dieses Flag nur im Notfall verwendet werden.
    ''' </summary>
    Friend Const EWX_FORCE As Integer = 4

End Module
