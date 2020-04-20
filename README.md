# NAZWA NASZEJ APLIKACJI



## Spis Treści
* [Opis](#opis)
* [Co zostało zrobione?](#co-zostało-zrobione?)
* [Screenshots](#screenshots)
* [Wykorzystane technologie](#wykorzystane-technologie)
* [Uruchomienie](#uruchomienie)
* [Funkcje](#funkcje)
* [Status](#status)

## Opis (informacje o aplikacji)

## Co zostało zrobione?

Zapewniono komunikację z bazą danych.
Utworzono modele: Pracownik, Stanowisko, Dział, Godziny pracy, Wejście i Wyjście z odpowiednimi polami.
Utworzono kontrolery realizujące funkcje: wyświetlanie, segregowanie, wyszukiwanie, dodawanie, edytowanie, usuwanie danych w tabelach: Pracownik, Stanoiwsko, Dział, Godziny pracy, Wejścia i Wyjścia, wypisywanie spóźnień pracowników w danym dniu, podliczanie przepracowanych godzin i nadgodzin oraz wypłat w danym miesiącu.
Utworzono widoki umożliwiające wykorzystywanie zaimplementowanych funkcjonalności.

## Screenshots


## Wykorzystane technologie
* User Interface
* Log
* LINQ
* Entity Framework
* Wielowątkowość/asynchroniczność
* NuGety:
Microsoft.EntityFrameworkCore.SqlServer 3.1.3
Microsoft.VisualStudio.Web.CodeGeneration.Design 3.1.1
MySql.Data.EntityFrameworkCore 8.0.19
Pomelo.EntityFrameworkCore.MySql 3.1.1
Pomelo.EntityFrameworkCore.MySql.Design 1.1.2
Serilog 2.9.0"
Serilog.Sinks.Console 3.1.1
Serilog.Sinks.File 4.1.0"

## Uruchomienie

## Przykłady kodu


## Funkcje


Do zrobienia:
* Autoryzacja pracowników
* Komunikacja z zewnętrznym api (komunikacja z przelicznikiem walut, zostanie wykorzystana w celu przeliczania wypłat pracowników na inne waluty)
* Testy jednostkowe

Komplikacje:
* Usuwanie rekordów z tabel, z którymi skojarzone są inne tabele.
* Wyświetlanie nazwy dnia tygodnia na podstawie daty (funkcja DateTime.Date.DayOfWeek)

## Status

