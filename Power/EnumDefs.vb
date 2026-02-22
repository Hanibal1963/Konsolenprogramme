
''' <summary>
''' Dieses Modul definiert die verwendeten Aufzählungen.
''' </summary>
Module EnumDefs

    ''' <summary>
    ''' Gibt den Typ der Neustartoptionen an, die eine Anwendung verwenden kann.
    ''' </summary>
    Friend Enum RestartOptions

        ''' <summary>
        ''' Beendet alle Prozesse, die im Sicherheitskontext des Prozesses laufen, der die
        ''' Funktion ExitWindowsEx aufgerufen hat.<br/>
        ''' Danach wird der Benutzer abgemeldet.
        ''' </summary>
        LogOff = 0

        ''' <summary>
        ''' Fährt das System herunter und schaltet die Stromversorgung aus.<br/>
        ''' Das System muss die Abschaltfunktion unterstützen.
        ''' </summary>
        PowerOff = 8

        ''' <summary>
        ''' Fährt das System herunter und startet es anschließend neu.
        ''' </summary>
        Reboot = 2

        ''' <summary>
        ''' Fährt das System bis zu einem Punkt herunter, an dem es sicher ist, die
        ''' Stromversorgung auszuschalten.<br/>
        ''' Alle Dateipuffer wurden auf den Datenträger geschrieben und alle laufenden
        ''' Prozesse wurden beendet.<br/>
        ''' Wenn das System die Abschaltfunktion unterstützt, wird die Stromversorgung
        ''' ebenfalls ausgeschaltet.
        ''' </summary>
        ShutDown = 1

        ''' <summary>
        ''' Versetzt das System in den Energiesparmodus.
        ''' </summary>
        Suspend = -1

        ''' <summary>
        ''' Versetzt das System in den Ruhezustand.
        ''' </summary>
        Hibernate = -2

    End Enum

End Module
