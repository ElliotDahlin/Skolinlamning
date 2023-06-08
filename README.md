# Skolinlämning

Detta är en README-fil som beskriver hur man kan ladda ner och köra applikationen.

## Krav

För att kunna köra applikationen behöver du följande:

- .NET SDK (version 7.0.5): Ladda ner och installera .NET SDK från [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download).

## Installation

Följ stegen nedan för att ladda ner och installera applikationen:

1. Klona projektet från GitHub-repositoriet:
2. Navigera till projektmappen:
4. Installera Nugetspaket: Microsoft.AspNet.WebApi.Client, Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore,
Microsoft.AspNetCore.Identity.EntityFrameworkCore, Microsoft.AspNetCore.Identity.UI, Microsoft.EntityFrameworkCore.SqlServer, 
Microsoft.EntityFrameworkCore.Tools, Microsoft.VisualStudio.Web.CodeGeneration.Design
3. Uppdatera databasen:

Detta kommer att skapa den nödvändiga databasen för applikationen.

## Starta applikationen

För att starta applikationen, följ dessa steg:

1. Navigera till projektmappen:
2. Kör applikationen med Visual Studio 2020:


Applikationen kommer att startas och vara tillgänglig på [http://localhost:7052](http://localhost:7052).

## Användning

För att använda applikationen måste du registrera ett konto. Det kan du göra på 'Register'. OBS! Glöm inte att godkänna din e-mailadress. När det är klart kan du se våra vyer som 'Blog', 'Driver' och 'Race Schedule'.
I 'Blog'-vyn kan du kommentera de senaste tävlingarna genom att lägga ut inlägg. Där andra användare kan se dina inlägg och du kan se deras. Du kan även söka efter förare i sökrutan. Du hittar dina förare antingen genom att söka efter förnamn, efternamn eller nationalitet.
I 'Driver'-vyn kan du se en lista på alla förare som har deltagit i tävlingar under detta år.
I 'Race Schedule'-vyn hittar du alla senaste race, samt plats, tid och deltagare.

## Bidrag

Om du vill bidra till detta projekt, var vänlig och följ följande steg:

1. Forka projektet
2. Skapa en ny gren (`git checkout -b feature/ny-funktion`)
3. Gör dina ändringar
4. Commita ändringarna (`git commit -am 'Lägg till ny funktion'`)
5. Pusha till grenen (`git push origin feature/ny-funktion`)
6. Öppna en pull request

## Licens

Beskriv licensen för projektet här, t.ex. MIT, Apache, eller annan vald licens.

