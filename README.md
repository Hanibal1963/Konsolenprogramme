# Konsolenprogramme

Dieses Projekt enth�lt verschiedene Konsolenprogramme die ich f�r
private Zwecke erstellt habe.

---

## Beep

Konsolenprogramm zum ausgeben von Signalt�nen.

```
Verwendung:
Beep /n:NN

Parameter NN:
Anzahl der T�ne (0-99)
```

---

## ServerCheck

Konsolenprogramm zum feststellen ob ein Computer im lokalen Netzwerk 
erreichbar ist.

```
Verwendung:
ServerCheck Computername

Ergebnis in der Errorlevel-Variable des Systems
0 = Computer ist erreichbar
1 = Computer ist nicht erreichbar
2 = fehlerhafte Kommandozeile
```

---

## Wait

Konsolenprogramm welches die Abarbeitung einer Batch Datei f�r eine festgelegte Zeit anh�lt.

```
Verwendung:
Wait /n:NN

Parameter NN:
Wartezei in Sekunden (0-99)
```

---

## geplante �nderungen

- alle Projekte auf NET 8.0 portieren
