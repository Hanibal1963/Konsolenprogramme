
Imports System.Text

''' <summary>
''' Dieses Modul definiert die Verwendeten API - Funktionen.
''' </summary>
Module ApiDefs

    ''' <summary>
    ''' Die Funktion LoadLibrary ordnet das angegebene ausführbare Modul dem Adressraum
    ''' des aufrufenden Prozesses zu.
    ''' </summary>
    ''' <param name="lpLibFileName"><para>Zeiger auf eine nullterminierte Zeichenfolge,
    ''' die das ausführbare Modul (entweder eine .dll- oder .exe-Datei) benennt. </para>
    ''' <para>Der angegebene Name ist der Dateiname des Moduls und steht nicht in
    ''' Beziehung zu dem im Bibliotheksmodul selbst gespeicherten Namen,</para>
    ''' <para>wie im LIBRARY-Schlüsselwort der Moduldefinitionsdatei (.def)
    ''' angegeben.</para></param>
    ''' <returns>
    ''' <para>Wenn die Funktion erfolgreich ist, ist der Rückgabewert ein Handle auf das
    ''' Modul.</para>
    ''' <para>Wenn die Funktion fehlschlägt, ist der Rückgabewert NULL.</para>
    ''' <para>Um erweiterte Fehlerinformationen zu erhalten, rufen Sie
    ''' Marshal.GetLastWin32Error auf.</para>
    ''' </returns>
    Friend Declare Ansi Function LoadLibrary Lib "kernel32" Alias "LoadLibraryA" (lpLibFileName As String) As IntPtr

    ''' <summary>
    ''' <para>Die Funktion FreeLibrary dekrementiert die Referenzanzahl der geladenen
    ''' Dynamic-Link Library (DLL).</para>
    ''' <para>Wenn die Referenzanzahl null erreicht, wird das Modul aus dem Adressraum
    ''' des aufrufenden Prozesses entfernt und das Handle ist nicht mehr gültig.</para>
    ''' </summary>
    ''' <param name="hLibModule"><para>Handle auf das geladene DLL-Modul.</para>
    ''' <para>Die Funktionen LoadLibrary oder GetModuleHandle geben dieses Handle
    ''' zurück.</para></param>
    ''' <returns>
    ''' <para>Wenn die Funktion erfolgreich ist, ist der Rückgabewert ungleich
    ''' null.</para>
    ''' <para>Wenn die Funktion fehlschlägt, ist der Rückgabewert null.</para>
    ''' <para>Um erweiterte Fehlerinformationen zu erhalten, rufen Sie
    ''' Marshal.GetLastWin32Error auf.</para>
    ''' </returns>
    Friend Declare Ansi Function FreeLibrary Lib "kernel32" (hLibModule As IntPtr) As Integer

    ''' <summary>
    ''' Die Funktion GetProcAddress ruft die Adresse einer exportierten Funktion oder
    ''' Variablen aus der angegebenen Dynamic-Link Library (DLL) ab.
    ''' </summary>
    ''' <param name="hModule"><para>Handle auf das DLL-Modul, das die Funktion oder
    ''' Variable enthält.</para>
    ''' <para>Die Funktionen LoadLibrary oder GetModuleHandle geben dieses Handle
    ''' zurück.</para></param>
    ''' <param name="lpProcName"><para>Zeiger auf eine nullterminierte Zeichenfolge, die
    ''' den Funktions- oder Variablennamen enthält, oder auf den Ordinalwert der
    ''' Funktion.</para>
    ''' <para>Wenn dieser Parameter ein Ordinalwert ist, muss er im niederwertigen Wort
    ''' stehen; das höherwertige Wort muss null sein.</para></param>
    ''' <returns>
    ''' <para>Wenn die Funktion erfolgreich ist, ist der Rückgabewert die Adresse der
    ''' exportierten Funktion oder Variable.</para>
    ''' <para>Wenn die Funktion fehlschlägt, ist der Rückgabewert NULL.</para>
    ''' <para>Um erweiterte Fehlerinformationen zu erhalten, rufen Sie
    ''' Marshal.GetLastWin32Error auf.</para>
    ''' </returns>
    Friend Declare Ansi Function GetProcAddress Lib "kernel32" (hModule As IntPtr, lpProcName As String) As IntPtr

    ''' <summary>
    ''' <para>Die Funktion SetSuspendState versetzt das System durch Ausschalten der
    ''' Stromversorgung in den Ruhezustand.</para>
    ''' <para>Abhängig vom Hibernate-Parameter wechselt das System entweder in den
    ''' Standby- (Sleep-)Zustand oder in den Ruhezustand (S4).</para>
    ''' <para>Wenn der ForceFlag-Parameter TRUE ist, wird der Betrieb sofort angehalten;
    ''' ist er FALSE, fordert das System vorher die Zustimmung aller Anwendungen und
    ''' Gerätetreiber an.</para>
    ''' </summary>
    ''' <param name="Hibernate"><para>Gibt den Zustand des Systems an.</para>
    ''' <para>Wenn TRUE, geht das System in den Ruhezustand.</para>
    ''' <para>Wenn FALSE, wird das System angehalten.</para></param>
    ''' <param name="ForceCritical"><para>Erzwungenes Anhalten.</para>
    ''' <para>Wenn TRUE, sendet die Funktion ein PBT_APMSUSPEND-Ereignis an jede
    ''' Anwendung und jeden Treiber und hält den Betrieb sofort an.</para>
    ''' <para>Wenn FALSE, sendet die Funktion ein PBT_APMQUERYSUSPEND-Ereignis an jede
    ''' Anwendung, um die Zustimmung zum Anhalten des Betriebs
    ''' anzufordern.</para></param>
    ''' <param name="DisableWakeEvent"><para>Wenn TRUE, deaktiviert das System alle
    ''' Weckereignisse.</para>
    ''' <para>Wenn FALSE, bleiben alle Weckereignisse des Systems
    ''' aktiviert.</para></param>
    ''' <returns>
    ''' <para>Wenn die Funktion erfolgreich ist, ist der Rückgabewert ungleich
    ''' null.</para>
    ''' <para>Wenn die Funktion fehlschlägt, ist der Rückgabewert null.</para>
    ''' <para>Um erweiterte Fehlerinformationen zu erhalten, rufen Sie
    ''' Marshal.GetLastWin32Error auf.<br/>
    ''' </para>
    ''' </returns>
    Friend Declare Ansi Function SetSuspendState Lib "powrprof" (Hibernate As Integer, ForceCritical As Integer, DisableWakeEvent As Integer) As Integer

    ''' <summary>
    ''' Die Funktion OpenProcessToken öffnet das dem Prozess zugeordnete Zugriffstoken.
    ''' </summary>
    ''' <param name="ProcessHandle">Handle auf den Prozess, dessen Zugriffstoken
    ''' geöffnet wird.</param>
    ''' <param name="DesiredAccess"><para>Gibt eine Zugriffsmaske an, die die
    ''' angeforderten Zugriffstypen auf das Zugriffstoken festlegt.</para>
    ''' <para>Diese angeforderten Zugriffstypen werden mit der Discretionary
    ''' Access-Control List (DACL) des Tokens verglichen, um zu bestimmen, welche
    ''' Zugriffe gewährt oder verweigert werden.</para></param>
    ''' <param name="TokenHandle">Zeiger auf ein Handle, das beim Rückkehr der Funktion
    ''' das neu geöffnete Zugriffstoken identifiziert.</param>
    ''' <returns>
    ''' <para>Wenn die Funktion erfolgreich ist, ist der Rückgabewert ungleich
    ''' null.</para>
    ''' <para>Wenn die Funktion fehlschlägt, ist der Rückgabewert null.</para>
    ''' <para>Um erweiterte Fehlerinformationen zu erhalten, rufen Sie
    ''' Marshal.GetLastWin32Error auf.<br/>
    ''' </para>
    ''' </returns>
    Friend Declare Ansi Function OpenProcessToken Lib "advapi32" (ProcessHandle As IntPtr, DesiredAccess As Integer, ByRef TokenHandle As IntPtr) As Integer

    ''' <summary>
    ''' Die Funktion LookupPrivilegeValue ruft die lokal eindeutige Kennung (LUID) ab,
    ''' die auf einem angegebenen System verwendet wird, um den angegebenen
    ''' Berechtigungsnamen lokal zu repräsentieren.
    ''' </summary>
    ''' <param name="lpSystemName"><para>Zeiger auf eine nullterminierte Zeichenfolge,
    ''' die den Namen des Systems angibt, auf dem der Berechtigungsname nachgeschlagen
    ''' wird.</para>
    ''' <para>Wenn eine leere Zeichenfolge angegeben wird, versucht die Funktion, den
    ''' Berechtigungsnamen auf dem lokalen System zu finden.</para></param>
    ''' <param name="lpName"><para>Zeiger auf eine nullterminierte Zeichenfolge, die den
    ''' Namen der Berechtigung angibt, wie in der Headerdatei Winnt.h definiert.</para>
    ''' <para>Beispielsweise kann dieser Parameter die Konstante SE_SECURITY_NAME oder
    ''' die entsprechende Zeichenfolge "SeSecurityPrivilege" angeben.</para></param>
    ''' <param name="lpLuid">Zeiger auf eine Variable, die die lokal eindeutige Kennung
    ''' erhält, unter der die Berechtigung auf dem durch lpSystemName angegebenen System
    ''' bekannt ist.</param>
    ''' <returns>
    ''' <para>Wenn die Funktion erfolgreich ist, ist der Rückgabewert ungleich
    ''' null.</para>
    ''' <para>Wenn die Funktion fehlschlägt, ist der Rückgabewert null.</para>
    ''' <para>Um erweiterte Fehlerinformationen zu erhalten, rufen Sie
    ''' Marshal.GetLastWin32Error auf.<br/>
    ''' </para>
    ''' </returns>
    Friend Declare Ansi Function LookupPrivilegeValue Lib "advapi32" Alias "LookupPrivilegeValueA" (lpSystemName As String, lpName As String, ByRef lpLuid As LUID) As Integer

    ''' <summary>
    ''' <para>Die Funktion AdjustTokenPrivileges aktiviert oder deaktiviert
    ''' Berechtigungen im angegebenen Zugriffstoken.</para>
    ''' <para>Das Aktivieren oder Deaktivieren von Berechtigungen in einem Zugriffstoken
    ''' erfordert TOKEN_ADJUST_PRIVILEGES-Zugriff.</para>
    ''' </summary>
    ''' <param name="TokenHandle"><para>Handle auf das Zugriffstoken, das die zu
    ''' ändernden Berechtigungen enthält.</para>
    ''' <para>Das Handle muss TOKEN_ADJUST_PRIVILEGES-Zugriff auf das Token
    ''' besitzen.</para>
    ''' <para>Wenn der PreviousState-Parameter nicht NULL ist, muss das Handle außerdem
    ''' TOKEN_QUERY-Zugriff besitzen.</para></param>
    ''' <param name="DisableAllPrivileges"><para>Gibt an, ob die Funktion alle
    ''' Berechtigungen des Tokens deaktiviert.</para>
    ''' <para>Wenn dieser Wert TRUE ist, deaktiviert die Funktion alle Berechtigungen
    ''' und ignoriert den NewState-Parameter.</para>
    ''' <para>Ist er FALSE, ändert die Funktion Berechtigungen basierend auf den
    ''' Informationen, auf die NewState zeigt.</para></param>
    ''' <param name="NewState"><para>Zeiger auf eine TOKEN_PRIVILEGES-Struktur, die ein
    ''' Array von Berechtigungen und deren Attribute angibt.</para>
    ''' <para>Wenn DisableAllPrivileges FALSE ist, aktiviert oder deaktiviert
    ''' AdjustTokenPrivileges diese Berechtigungen für das Token.</para>
    ''' <para>Wenn Sie das Attribut SE_PRIVILEGE_ENABLED für eine Berechtigung setzen,
    ''' aktiviert die Funktion diese Berechtigung; andernfalls deaktiviert sie
    ''' sie.</para>
    ''' <para>Wenn DisableAllPrivileges TRUE ist, ignoriert die Funktion diesen
    ''' Parameter.</para></param>
    ''' <param name="BufferLength"><para>Gibt die Größe in Bytes des Puffers an, auf den
    ''' PreviousState zeigt.</para>
    ''' <para>Dieser Parameter kann null sein, wenn PreviousState NULL
    ''' ist.</para></param>
    ''' <param name="PreviousState"><para>Zeiger auf einen Puffer, den die Funktion mit
    ''' einer TOKEN_PRIVILEGES-Struktur füllt, die den vorherigen Zustand der von der
    ''' Funktion geänderten Berechtigungen enthält.</para>
    ''' <para>Dieser Parameter kann NULL sein.</para></param>
    ''' <param name="ReturnLength"><para>Zeiger auf eine Variable, die die erforderliche
    ''' Größe in Bytes des Puffers erhält, auf den PreviousState zeigt.</para>
    ''' <para>Dieser Parameter kann NULL sein, wenn PreviousState NULL
    ''' ist.</para></param>
    ''' <returns>
    ''' <para>Wenn die Funktion erfolgreich ist, ist der Rückgabewert ungleich
    ''' null.</para>
    ''' <para>Um festzustellen, ob die Funktion alle angegebenen Berechtigungen
    ''' angepasst hat, rufen Sie Marshal.GetLastWin32Error auf.</para>
    ''' </returns>
    Friend Declare Ansi Function AdjustTokenPrivileges Lib "advapi32" (TokenHandle As IntPtr, DisableAllPrivileges As Integer, ByRef NewState As TOKEN_PRIVILEGES, BufferLength As Integer, ByRef PreviousState As TOKEN_PRIVILEGES, ByRef ReturnLength As Integer) As Integer

    ''' <summary>
    ''' <para>Die Funktion ExitWindowsEx meldet den aktuellen Benutzer ab, fährt das
    ''' System herunter oder fährt das System herunter und startet es neu.</para>
    ''' <para>Sie sendet die WM_QUERYENDSESSION-Nachricht an alle Anwendungen, um zu
    ''' bestimmen, ob sie beendet werden können.</para>
    ''' </summary>
    ''' <param name="uFlags">Gibt die Art des Herunterfahrens an.</param>
    ''' <param name="dwReserved">Dieser Parameter wird ignoriert.</param>
    ''' <returns>
    ''' <para>Wenn die Funktion erfolgreich ist, ist der Rückgabewert ungleich
    ''' null.</para>
    ''' <para>Wenn die Funktion fehlschlägt, ist der Rückgabewert null.</para>
    ''' <para>Um erweiterte Fehlerinformationen zu erhalten, rufen Sie
    ''' Marshal.GetLastWin32Error auf.<br/>
    ''' </para>
    ''' </returns>
    Friend Declare Ansi Function ExitWindowsEx Lib "user32" (uFlags As Integer, dwReserved As Integer) As Integer

    ''' <summary>
    ''' <para>Die Funktion FormatMessage formatiert eine Meldungszeichenfolge.</para>
    ''' <para>Die Funktion erfordert eine Meldungsdefinition als Eingabe.</para>
    ''' <para>Die Meldungsdefinition kann aus einem an die Funktion übergebenen Puffer
    ''' stammen.</para>
    ''' <para>Sie kann aus einer Meldungstabellenressource in einem bereits geladenen
    ''' Modul stammen<br/>
    ''' oder der Aufrufer kann die Funktion anweisen, die Meldungstabellenressource(n)
    ''' des Systems nach der Meldungsdefinition zu durchsuchen.</para>
    ''' <para>Die Funktion findet die Meldungsdefinition in einer
    ''' Meldungstabellenressource basierend auf einer Meldungskennung und einer
    ''' Sprachkennung.</para>
    ''' <para>Die Funktion kopiert den formatierten Meldungstext in einen Ausgabepuffer
    ''' und verarbeitet auf Wunsch eingebettete Einfügefolgen.</para>
    ''' </summary>
    ''' <param name="dwFlags"><para>Gibt Aspekte des Formatierungsprozesses und an, wie
    ''' der Parameter lpSource zu interpretieren ist.</para>
    ''' <para>Das niederwertige Byte von dwFlags gibt an, wie die Funktion
    ''' Zeilenumbrüche im Ausgabepuffer behandelt.</para>
    ''' <para>Das niederwertige Byte kann außerdem die maximale Breite einer
    ''' formatierten Ausgabeleiste angeben.</para></param>
    ''' <param name="lpSource"><para>Gibt die Position der Meldungsdefinition an.</para>
    ''' <para>Der Typ dieses Parameters hängt von den Einstellungen im Parameter dwFlags
    ''' ab.</para></param>
    ''' <param name="dwMessageId"><para>Gibt die Meldungskennung der angeforderten
    ''' Meldung an.</para>
    ''' <para>Dieser Parameter wird ignoriert, wenn dwFlags FORMAT_MESSAGE_FROM_STRING
    ''' enthält.</para></param>
    ''' <param name="dwLanguageId"><para>Gibt die Sprachkennung der angeforderten
    ''' Meldung an.</para>
    ''' <para>Dieser Parameter wird ignoriert, wenn dwFlags FORMAT_MESSAGE_FROM_STRING
    ''' enthält.</para></param>
    ''' <param name="lpBuffer"><para>Zeiger auf einen Puffer für die formatierte (und
    ''' nullterminierte) Meldung.</para>
    ''' <para>Wenn dwFlags FORMAT_MESSAGE_ALLOCATE_BUFFER enthält, allokiert die
    ''' Funktion einen Puffer mit der Funktion LocalAlloc<br/>
    ''' und legt den Zeiger auf den Puffer an der in lpBuffer angegebenen Adresse
    ''' ab.</para></param>
    ''' <param name="nSize"><para>Wenn das Flag FORMAT_MESSAGE_ALLOCATE_BUFFER nicht
    ''' gesetzt ist, gibt dieser Parameter die maximale Anzahl von TCHARs an,<br/>
    ''' die im Ausgabepuffer gespeichert werden können.</para>
    ''' <para>Wenn FORMAT_MESSAGE_ALLOCATE_BUFFER gesetzt ist, gibt dieser Parameter die
    ''' minimale Anzahl von TCHARs an, die für einen Ausgabepuffer zu allokieren
    ''' ist.</para>
    ''' <para>Für ANSI-Text entspricht dies der Anzahl der Bytes; für Unicode-Text der
    ''' Anzahl der Zeichen.</para></param>
    ''' <param name="Arguments"><para>Zeiger auf ein Array von Werten, die als
    ''' Einfügewerte in der formatierten Meldung verwendet werden.</para>
    ''' <para>Ein %1 in der Formatzeichenfolge steht für den ersten Wert im
    ''' Arguments-Array; ein %2 für das zweite Argument; und so weiter.</para></param>
    ''' <returns>
    ''' <para>Wenn die Funktion erfolgreich ist, ist der Rückgabewert die Anzahl der im
    ''' Ausgabepuffer gespeicherten TCHARs, ohne das abschließende Nullzeichen.</para>
    ''' <para>Wenn die Funktion fehlschlägt, ist der Rückgabewert null.</para>
    ''' <para>Um erweiterte Fehlerinformationen zu erhalten, rufen Sie
    ''' Marshal.GetLastWin32Error auf.<br/>
    ''' </para>
    ''' </returns>
    Friend Declare Ansi Function FormatMessage Lib "kernel32" Alias "FormatMessageA" (dwFlags As Integer, lpSource As IntPtr, dwMessageId As Integer, dwLanguageId As Integer, lpBuffer As StringBuilder, nSize As Integer, Arguments As Integer) As Integer

End Module
