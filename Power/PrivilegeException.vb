''' <summary>
''' Die Ausnahme, die ausgelöst wird, wenn beim Anfordern einer bestimmten Berechtigung ein Fehler auftritt.
''' </summary>
Public Class PrivilegeException : Inherits Exception

    ''' <summary>
    ''' Initialisiert eine neue Instanz der `PrivilegeException`-Klasse.
    ''' </summary>
    Public Sub New()
        MyBase.New()
    End Sub

    ''' <summary>
    ''' Initialisiert eine neue Instanz der `PrivilegeException`-Klasse mit einer angegebenen Fehlermeldung.
    ''' </summary>
    ''' <param name="message">
    ''' Die Nachricht, die den Fehler beschreibt.
    ''' </param>
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub

End Class
