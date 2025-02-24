# DataStorage Assignment

## Beskrivning

Detta projekt är en uppgift inom kursen Datalagring där målet är att skapa en applikation med C# och .NET som kommunicerar med en databas. Du kan välja mellan olika applikationsformer, som Console, WPF, MAUI eller React. I detta projekt används en Console-applikation tillsammans med Entity Framework Core för att hantera data.

## Funktionalitet

Applikationen erbjuder följande funktioner:

- Visa en lista över alla projekt.
- Skapa ett nytt projekt.
- Redigera eller uppdatera befintliga projekt.
- CRUD-operationer för kunder, projekt och användare.

## Teknisk Information

- **Framework:** .NET
- **Databas:** LocalDB (MSSQL)
- **ORM:** Entity Framework Core
- **Designmönster:** SOLID-principerna (med fokus på Single Responsibility Principle)

## Installation och Körning

1. Klona repository:
```sh
git clone https://github.com/malson89s/DataStorage_Assignment.git
```

2. Öppna lösningen i Visual Studio.

3. Återskapa databasen:
```sh
cd Data
dotnet ef database update
```

4. Kör applikationen från Presentation_ConsoleApp-projektet.

## Användning av AI-genererad kod
En del av koden har genererats med hjälp av AI-verktyg (exempelvis ChatGPT) och har integrerats i projektet för att förbättra utvecklingsprocessen.

## Observera
Du behöver inte ladda upp din databas till GitHub enligt instruktionerna i uppgiften. Se till att din lokala databas är korrekt konfigurerad innan du kör applikationen.

## Kontakt
För frågor, kontakta Malin på GitHub: [malson89s](https://github.com/malson89s)
