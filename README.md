# Konsolenprogramme

Dieses Projekt enthält verschiedene Konsolenprogramme die ich für private Zwecke erstellt habe.

---

## Beep

Konsolenprogramm zum ausgeben von Signaltönen.

```text
Verwendung:
Beep /n:NN

Parameter NN:
Anzahl der Töne (0-99)
```

---

## ServerCheck

Konsolenprogramm zum feststellen ob ein Computer im lokalen Netzwerk erreichbar ist.

```text
Verwendung:
ServerCheck Computername

Ergebnis in der Errorlevel-Variable des Systems
0 = Computer ist erreichbar
1 = Computer ist nicht erreichbar
2 = fehlerhafte Kommandozeile
```

---

## Wait

Konsolenprogramm welches die Abarbeitung einer Batchdatei für eine festgelegte Zeit anhält.

```text
Verwendung:
Wait /n:NN

Parameter NN:
Wartezeit in Sekunden (0-99)
```

---

## Power

Kommandozeilentool um den PC in die verschiedenen Energiezustände zu versetzen.

```Text
Verwendung:
Power /opt

/Opt kann einen der folgenden Werte haben:
/logfoff - > Benutzer abmelden
/poweroff -> Herunterfahren und ausschalten
/reboot -> Herunterfahren und neu starten
/shutdown -> Herunterfahren und ausschalten
/suspend -> Energiesparmodus
/hibernate -> Ruhezustand
```

## CdRom

Kommandozeilentool mit Funktionen für CD-Laufwerke.

```Text
Verwendung:
CdRom /opt:[LW]
[LW] ist der Laufwerksbuchstabe eines CD-Laufwerks (z.B. D, E, F, ...).
/opt kann einen der folgenden Werte haben:
/exist -> Prüft ob ein CD-Laufwerk mit dem angegebenen Buchstaben existiert.
/open -> Öffnet die Schublade des CD-Laufwerks mit dem angegebenen Buchstaben.
/close -> Schließt die Schublade des CD-Laufwerks mit dem angegebenen Buchstaben.
Es werden folgende ERRORLEVEL zurückgegeben:
ERRORLEVEL 0 -> CD-Laufwerk existiert.
ERRORLEVEL 1 -> CD-Laufwerk existiert nicht oder ungültiger Buchstabe.
```

## geplante Änderungen

- z.Zt. keine
