<!--

author:   Volker Göhler
email:    volker.goehler@informatik.tu-freiberg.de
version:  0.0.1
language: de
narrator: Deutsch Female

edit: true
date: 2026-04-09

icon: img/TUBAF_Logo_blau.svg
logo: 

attribute: 

attribute: 

comment:  Übung Softwareentwicklung 00

link:   https://raw.githubusercontent.com/vgoehler/LiaScript_CSS_Provider/refs/heads/main/dist/university.css

tags: [ Sommersemester2026, Softwareentwicklung, Übung00]

-->

#  Aufgabe 00

Softwareentwicklung SoSe2026
============================

Sie sollen:

- den Umgang mit c#, Compiler und Infrastruktur Software kennenlernen und üben
- Erste Schritte mit Visual Studio Code und C#
- Erste Schritte mit Github und Github Classrooms

Bearbeitungszeitraum
====================

*20. April - 26. April 2026*

**Einleitung für die Aufgaben:**
============================

Willkommen an Bord deines interstellaren Raumschiffs! Deine Mission: die Erforschung und Katalogisierung von Himmelskörpern in einem bisher unerforschten Sternensystem. Als Teil der Crew bist du verantwortlich für die Entwicklung eines Programms, das die gesammelten astronomischen Daten strukturiert erfasst, validiert und ausgibt. Jeder Himmelskörper, egal ob Stern, Planet oder Mond, birgt wertvolle Informationen, die für den Erfolg der Mission entscheidend sind. Nutze dein Wissen über Datentypen, Eingabevalidierung und Fehlerbehandlung, um sicherzustellen, dass die Daten präzise und zuverlässig verarbeitet werden. Die Bodenstation verlässt sich auf deine Arbeit, also sei sorgfältig und kreativ bei der Umsetzung!

![Artemis I Launch (NHQ202211160017), Joel Kowsky, Public domain, via Wikimedia Commons](https://upload.wikimedia.org/wikipedia/commons/b/b9/Artemis_I_Launch_%28NHQ202211160017%29.jpg)

## **Aufgabe 1: Mission Vorbereitung – Entwicklungsumgebung einrichten**

**Zeitaufwand: 30 Minuten**

*Die erste Phase deiner Mission: Richte deine Entwicklungsumgebung ein, um für die Herausforderungen des Weltraums gewappnet zu sein.*

- Installiere **Visual Studio Code** mit der **C#-Dev-Erweiterung**.
- Installiere die **.NET SDKs** für die Entwicklung von C#-Anwendungen.
- Erstelle ein **"Hello World"**-Projekt `ConsoleApp`, um die Systeme zu testen.
- Schreibe, kompiliere und führe den Code in der integrierten Konsole und IDE aus.
- Probiere den **Debug-Modus** aus, um potenzielle Fehler in deiner Raumschiff-Software zu identifizieren.


<!-- class="lia-callout--note" -->
> **Hinweis:**
> Auf den Poolrechner der TU Bergakademie Freiberg ist Visual Studio Code bereits installiert und konfiguriert.
> Überprüfe die Settings, um sicherzustellen, dass die C#-Erweiterung aktiviert ist und die .NET SDKs korrekt erkannt werden.

**Coding Help -- Main Function**<!-- class="head" -->

```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Mission startet...");
    }
}
```


## **Aufgabe 2: Katalogisierung von Himmelskörpern für die interstellare Mission**

**Zeitaufwand: 150 Minuten**<!-- class="subhead" -->

*Dein Raumschiff hat verschiedene Himmelskörper in einem unbekannten Sternensystem entdeckt. Entwickle ein Programm, um deren astronomische Daten zu erfassen, zu validieren und auszugeben.*

**Unteraufgaben:**

1. **Dateninitialisierung**
2. **Daten von der Kommandozeile einlesen**
3. **Interaktive Dateneingabe**
4. **Datenausgabe**
5. **Datenvalidierung**

### 1. **Dateninitialisierung**

   - Initialisiere Variablen mit passenden Konstanten für:

     - **Name des Himmelskörpers** (Zeichenkette, z. B. "Proxima Centauri b" oder "Mond Phobos")
     - **Katalog-Nummer** (5-stellige ganze Zahl, z. B. 12345)
     - **Typ** (Enum: Stern, Planet, Mond)
     - **Spektralklasse** (Buchstabe O, B, A, F, G, K, M; nur relevant für Sterne)
     - **Scheinbare Helligkeit** (Gleitkommazahl mit 2 Nachkommastellen, z. B. 11.13; nur relevant für Sterne)
     - **Umlaufzeit** (Gleitkommazahl in Erdjahren, z. B. 0.618 für Planeten/Monde)
     - **Zentralkörper-Katalog-Nummer** (5-stellige ganze Zahl, z. B. 67890 für den Stern/Planeten, um den der Himmelskörper kreist)

<!-- class="lia-callout--note" -->
> **Hinweis:**
> Nutzen Sie eine Datenklasse zur Kapselung der Variablen, z. B.: `Himmelskoerper`.
> Die Main function soll in einer anderen Klasse enthalten sein, um die Daten zu initialisieren und zu verarbeiten.
> Ein `?` hinter dem Datentyp bedeutet, dass die Variable null sein kann, z. B. `char?` für die Spektralklasse, da sie nur für Sterne relevant ist.

### 2. **Daten von der Kommandozeile einlesen**

   - Lies die Werte von der Kommandozeile ein und speichere sie in den Variablen.
   - Dies soll in einer dedizierten Methode erfolgen, z. B. `LeseDatenEin()`.
   - Nutze `args[]` in der `Main`-Methode, um die Eingaben zu verarbeiten. Übergib die Variablen mit einer festen Reihenfolge, z. B.:

     - `dotnet datei.cs "Proxima Centauri b" 12345 Stern M 11.13 0.618 67890`

   - nutze casts um Strings in die entsprechenden Datentypen umzuwandeln, z. B. `int.Parse(args[1])` für die Katalog-Nummer.

### 3. **Interaktive Dateneingabe**

   - Erweitere das Programm, sodass die Werte über die Tastatur eingegeben werden können.
   - Nutze `Console.ReadLine()` und `Console.WriteLine()` für die Interaktion mit dem Benutzer.
   - Nutze die Funktion `LeseDatenEin()` auch für die interaktive Eingabe, um Code-Duplikation zu vermeiden.

4. **Datenausgabe**

   - Gib die eingegebenen Daten formatiert aus, z. B.:

     - Für Sterne: *"Himmelskörper: Proxima Centauri, Katalog-Nummer: 12345, Typ: Stern, Spektralklasse: M, Scheinbare Helligkeit: 11.13"*
     - Für Planeten/Monde: *"Himmelskörper: Mars, Katalog-Nummer: 23456, Typ: Planet, Umlaufzeit: 1.88 Erdjahre, Zentralkörper-Katalog-Nummer: 10001"*

5. **Datenvalidierung**

   - Stelle sicher, dass die Eingaben den astronomischen Anforderungen entsprechen:

     - Katalog-Nummer muss 5-stellig sein.
     - Typ muss Stern, Planet oder Mond sein.
     - Spektralklasse muss einer der gültigen Klassen (O, B, A, F, G, K, M) entsprechen (nur für Sterne).
     - Scheinbare Helligkeit muss eine positive Gleitkommazahl sein (nur für Sterne).
     - Umlaufzeit muss eine positive Gleitkommazahl sein (nur für Planeten/Monde).
     - Zentralkörper-Katalog-Nummer muss 5-stellig sein (nur für Planeten/Monde).


## 2. Bonus

### 1. Fehlerbehandlung

- nutze `try-catch` Blöcke, um ungültige Eingaben abzufangen und benutzerfreundliche Fehlermeldungen auszugeben.
- Mit throw kannst du eigene Fehler auslösen, z. B. wenn die Katalog-Nummer nicht 5-stellig ist oder der Typ ungültig ist.
- mit `finally` kannst du sicherstellen, dass bestimmte Aktionen immer ausgeführt werden, z. B. das Schließen von Ressourcen oder das Bereinigen von Daten.

```csharp
try
{
    // Code, der potenziell eine Ausnahme auslösen könnte
}
catch (FormatException ex)
{
    Console.WriteLine("Ungültiges Format: " + ex.Message);
}
catch (ArgumentException ex)
{
    Console.WriteLine("Ungültiges Argument: " + ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine("Ein unerwarteter Fehler ist aufgetreten: " + ex.Message);
}
finally
{
    // Code, der immer ausgeführt wird, z. B. Ressourcen freigeben
}
```
