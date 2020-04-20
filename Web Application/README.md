# SzczygiApp

## Spis Treści
* [Wprowadzenie](#wprowadzenie)
* [Encje w bazie danych](#encje-w-bazie-danych)
* [Polityka bezpieczeństwa](#polityka-bezpieczeństwa)
* [Funkcjonalności](#funkcjonalności)
* [Technologie](#technologie)

## Wprowadzenie 
SzczygiApp to aplikacja webowa umożliwiająca prowadzenie ewidencji czasu pracy dla wszystkich zatrudnionych pracowników firmy. Składa się z bazy danych, umożliwiającej przechowywanie najważniejszych danych o działach, stanowiskach i pracownikach i umożliwająca szybki dostęp do nich oraz graficznego interfejsu udostępniającemu użytkownikowi zestaw podstawowych funkcji związanych z przechowywaniem danych i operacjami na przechowywanych danych.

## Encje w bazie danych
* Pracownik

Dane wszystkich pracowników zatrudnionych w firmie: ID, imię, nazwisko, pesel, data zatrudnienia (wprowadzenia pracownika do systemu), status zatrudnienia (zatrudniony/urlop/L4/wypowiedzenie), ID stanowiska, na którym jest zatrudniony pracownik.

* Stanowisko

Dane wszystkich stanowisk obejmowanych przez pracowników firmy. ID, nazwa stanowiska, wynagrodzenie godzinowe, ID działu, do którego należy stanowisko.

* Dział

Dane wszystkich działów w firmie. ID, nazwa działu.

* Godziny pracy

Godziny pracy poszczególnych działów w poszczególne dni tygodnia. ID, dzień tygodnia, ID działu, którego dotyczy kolumna, godzina rozpoczęcia pracy i godzina zakończenia pracy.

* Wejścia

Dane o wejściach pracowników na teren zakład. ID, Id pracowika, który wchodzi na teren zakładu, data i godzina wejścia na zakład (data i godzina wprowadzenia danych do systemu).

* Wyjścia

Dane o wyjściach pracowników z terenu zakładu. ID, Id pracowika, który opuszcza teren zakładu, data i godzina wyjścia na zakład (data i godzina wprowadzenia danych do systemu).


## Polityka bezpieczeństwa
Aplikacja wykorzystuje mechanizmy autoryzacji i autentykacji użytkowników. Dostęp do bazy możliwy jest tylko i wyłącznie dla posiadaczy konta. Utworzone zostały trzy role: pracownik, specjalista do spraw zatrudnienia i prezes. Wprowadzone zostały ograniczenia w wykonywaniu operacji dla poszczególnych ról. 

## Funkcjonalności
#### Aplikacja umożliwia następujące interakcje z bazą:
* Zarządzanie wejściami i wyjściami

Pracownik może dodawać wejście i wyjście.
Specjalista do spraw zatrudnienia ma możliwość przeglądania i wyszukiwania zarejestrowanego wejścia lub wyjścia.
Prezes ma możliwość przeglądania, wyszukiwania edytowania i usuwania zarejestrowanego wejścia lub wyjścia.

* Zarządzanie danymi pracowników

Pracownik nie ma dostępu do danych swoich i innych pracowników.
Specjalista do spraw zatrudnienia ma możliwość przeglądania, wyszukiwania, dodawania i edycji danych pracowników. 
Prezes ma możliwość przeglądania, wyszukiwania, dodawania, edycji i usuwania danych pracowników.

* Zarządzanie stanowiskami i działami

Pracownik nie ma dostępu do danych działów i stanowisk.
Specjalista do spraw zatrudnienia ma możliwość przeglądania i wyszukiwania danych działów i stanowisk. 
Prezes ma możliwość przeglądania, wyszukiwania, dodawania, edycji i usuwania danych działów i stanowisk.

* Zarządzanie godzinami pracy

Pracownik nie ma dostępu do danych dotyczących godzin pracy.
Specjalista do spraw zatrudnienia ma możliwość przeglądania i wyszukiwania godzin pracy działów.
Prezes ma możliwość przeglądania, wyszukiwania, dodawania, edycji i usuwania godzin pracy działów.

* Dodatkowe funkcjonalności

Specjalista do spraw zatrudnienia i prezes mają także dostęp do dodatkowych funkcjonalności bazy takich jak spóźnienia oraz posumowanie miesięczne. Mogą oni kontrolować punktualność pracowników, korzystając ze specjalnie przygotowanej tabeli spóźnień. Tabela ta zestawia dane z tabeli wejść i tabeli godzin pracy, a następnie wyświetla wszystkie spóźnienia pracowników w wybranym dniu.
Podsumowanie miesięczne pozwala na podliczenie przepracowanych godzin oraz ewentualnej realizacji nadgodzin przez poszczególnych pracowników, a nawet wyliczenie wysokości wynagrodzenia dla każdego pracownika. Stawka godzinowa przypisana jest do stanowiska. Za pracę w godzinach nadliczbowych przysługuje dodatek w wysokości 50% stawki godzinowej. Wysokość wynagrodzenia przeliczana jest także na walutę euro, dzięki wykorzystaniu publicznego Web API umożliwiającego klientom wykonywanie zapytań na poniższych zbiorach danych publikowanych przez Narodowy Bank Polski.


## Technologie
* .NET Core 3.1
* Komunikacja z bazą danych (Entity Framework)
* LINQ (zadawanie pytań na kolekcjach obiektów o składni podobnej do SQL)
* Komunikacja z zewnętrznym API (wykorzystanie formatu JSON)
* User Interface (komunikacja z użytkownikiem)
* Log (obsługa dziennika zdarzeń)
* Obsługa wielowątkowości (asynchroniczność)
* Testowanie zamierzonej funkcjonalności (testy jednostkowe)
* Wykorzystanie zewnętrznych bibliotek:
  * Microsoft.AspNet.Identity.Core 2.2.3
  * Microsoft.AspNet.WebApi.Client 5.2.7
  * Microsoft.AspNet.WebApi.Core 5.2.7
  * Microsoft.EntityFrameworkCore 3.1.3
  * Microsoft.EntityFrameworkCore.Relational 3.1.3
  * Microsoft.EntityFrameworkCore.SqlServer 3.1.3
  * Microsoft.EntityFrameworkCore.Tools 3.1.3
  * Microsoft.VisualStudio.Web.CodeGeneration.Design 3.1.1
  * MySql.Data.EntityFrameworkCore 8.0.19
  * Pomelo.EntityFrameworkCore.MySql 3.1.1
  * Pomelo.EntityFrameworkCore.MySql.Design 1.1.2
  * Serilog 2.9.0"
  * Serilog.Sinks.Console 3.1.1
  * Serilog.Sinks.File 4.1.0
