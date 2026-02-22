Imports System.Runtime.InteropServices

''' <summary>
''' Diese Datei definiert alle verwendeten Strukturen.
''' </summary>
Module StructureDefs

    ''' <summary>
    ''' Ein LUID ist ein 64-Bit-Wert, der nur auf dem System eindeutig ist, auf dem er
    ''' erzeugt wurde.<br/>
    ''' Die Eindeutigkeit eines lokal eindeutigen Bezeichners (LUID) ist nur bis zum
    ''' Neustart des Systems garantiert.
    ''' </summary>
    <StructLayout(LayoutKind.Sequential, Pack:=1)>
    Friend Structure LUID

        ''' <summary>
        ''' Der niederwertige Teil des 64-Bit-Werts.
        ''' </summary>
        Public LowPart As Integer

        ''' <summary>
        ''' Der höherwertige Teil des 64-Bit-Werts.
        ''' </summary>
        Public HighPart As Integer

    End Structure

    ''' <summary>
    ''' Die Struktur LUID_AND_ATTRIBUTES stellt einen lokal eindeutigen Bezeichner (LUID) und seine Attribute dar.
    ''' </summary>
    <StructLayout(LayoutKind.Sequential, Pack:=1)>
    Friend Structure LUID_AND_ATTRIBUTES

        ''' <summary>
        ''' Gibt einen LUID-Wert an.
        ''' </summary>
        Public pLuid As LUID

        ''' <summary>
        ''' Gibt Attribute des LUID an.<br/>
        ''' Dieser Wert enthält bis zu 32 Ein-Bit-Flags.<br/>
        ''' Seine Bedeutung hängt von der Definition und Verwendung des LUID ab.
        ''' </summary>
        Public Attributes As Integer

    End Structure

    ''' <summary>
    ''' Die Struktur TOKEN_PRIVILEGES enthält Informationen über eine Menge von Privilegien für ein Zugriffstoken.
    ''' </summary>
    <StructLayout(LayoutKind.Sequential, Pack:=1)>
    Friend Structure TOKEN_PRIVILEGES

        ''' <summary>
        ''' Gibt die Anzahl der Einträge im Array Privileges an.
        ''' </summary>
        Public PrivilegeCount As Integer

        ''' <summary>
        ''' Gibt ein Array von LUID_AND_ATTRIBUTES-Strukturen an.<br/>
        ''' Jede Struktur enthält den LUID und die Attribute eines Privilegs.
        ''' </summary>
        Public Privileges As LUID_AND_ATTRIBUTES

    End Structure

End Module
