# Konsolenprogramme

Dieses Projekt enthält verschiedene Konsolenprogramme die ich für
private Zwecke erstellt habe.

---

## Beep

Konsolenprogramm zum ausgeben von Signaltönen.

```
Verwendung:
Beep /n:NN

Parameter NN:
Anzahl der Töne (0-99)
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

Konsolenprogramm welches die Abarbeitung einer Batch Datei für eine festgelegte Zeit anhält.

```
Verwendung:
Wait /n:NN

Parameter NN:
Wartezei in Sekunden (0-99)
```

---

## geplante Änderungen

- alle Projekte auf NET 8.0 portieren
