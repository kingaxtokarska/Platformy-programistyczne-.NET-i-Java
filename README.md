# SzczygiApp

## Spis Treści
* [Opis](#opis)
* [Podstawowe encje w bazach danych](#podstawowe-encje-w-bazach-danych)
* [Aplikaja w częściach](#aplikacja-w-częściach)
* [Funkcje](#funkcje)
* [Bezpieczeństwo](#bezpieczeństwo)
* [Wykorzystane technologie](#wykorzystane-technologie)
* [Uruchomienie](#uruchomienie)
* [Status](#status)

## Opis 
SzczygiApp to aplikacja webowa, stworzona dla wszystkich pracowników firmy SzczygiMeble. Dostarcza ona zarówno prezesowi firmy takie możliwości jak dodawanie, wyszukiwanie, edytowanie, usuwanie pracowników, działów, stanowisk, pełen wgląd do wszystkich godzin pracy oraz innych detali dotyczących pracy firmy, jak i zwykłemu pracownikowi uzupenianie swoich godzin pracy poprzez zalogowanie do niej. Aplikacja wykorzystuje komunikację z bazą danych oraz posiada przejrzysty interfejs użytkownika.

## Podstawowe encje w bazach danych
* Pracownik

Tabela Pracownik służy do przechowywania danych wszystkich pracowników zatrudnionych w firmie. Dostępne pola zawierają dane osobowe pracownika takie jak imię, nazwisko, pesel. Ponadto istnieje kolumna zawierająca datę zatrudnienia, będącą datą wprowadzenia pracownika do systemu, a także kolumna zawierająca status zatrudnienia, mówiąca o tym czy pracownik powinien pojawiać się na terenie zakładu w wyznaczonych godzinach pracy działu, na którym jest zatrudniony czy też znajduje się aktualnie na urlopie lub zwolnieniu i powinien być nieobecny. Dodatkowo do każdego pracownika przypisany jest jego unikatowy numer ID oraz stanowisko, na którym jest on zatrudniony.
* Stanowisko

Stanowisko to tabela opisująca wszystkie możliwe stanowiska obejmowane przez pracowników firmy. Rozróżnia się je przez unikalne numery ID. W tabeli podana jest również nazwa stanowiska, wynagrodzenie godzinowe, jakie jest wypłacane pracownikowi na danym stanowisku oraz ID działu, do którego przypisane jest dane stanowisko. Do stanowiska może być przypisany jeden lub wielu pracowników, ale stanowisko może też przez pewien czas pozostawać nieobsadzone. 
* Dział

Dział to tabela zawierająca informację o działach firmy. Podobnie jak stanowiska, działy mają swoje unikalne numery ID. Istnieje również kolumna z nazwami działów.
* Godziny pracy

Tabela zawiera informację o godzinach pracy poszczególnych działów w różne dni tygodnia. Zawiera cztery kolumny: numer ID działu, którego dotyczy kolumna, nazwa dnia tygodnia, godzina rozpoczęcia pracy i godzina zakończenia pracy.
* Wejścia

Wejścia to tabela przechowująca dane o wejściach na zakład pracowników. Można w niej znaleźć informację o pracowniku, który wchodzi na teren zakładu, to znaczy jego numer ID, 
a także datę i godzinę wejścia na zakład.
* Wyjścia

Wyjścia to tabela analogiczna do tabeli Wejścia. Przechowuje ona dane o wyjściach z terenu zakładu. Można w niej znaleźć informację o pracowniku, który opuszcza zakład, to znaczy jego numer ID, a także datę i godzinę opuszczania zakładu.

## Aplikacja w częściach
* Komunikacja z bazą danych
* Modele: Pracownik, Stanowisko, Dział, Godziny pracy, Wejście, Wyjście z odpowiednimi polami dostarczającymi informacje z baz danych
* Kontrolery realizujące funkcje: wyświetlanie, segregowanie, wyszukiwanie, dodawanie, edytowanie, usuwanie danych w tabelach: Pracownik, Stanoiwsko, Dział, Godziny pracy, Wejścia i Wyjścia, wypisywanie spóźnień pracowników w danym dniu, podliczanie przepracowanych godzin i nadgodzin oraz wypłat w danym miesiącu
* Widoki umożliwiające wykorzystywanie zaimplementowanych funkcjonalności

## Funkcje
#### Aplikacja umożliwia następujące interakcje z bazą:
* Zarządzanie wejściami i wyjściami

Aplikacja umożliwi zarządzanie wejściami i wyjściami pracowników. Każdy pracownik jest zobowiązany rejestrować każde swoje wejście na teren firmy oraz każde opuszczenie terenu firmy. W przypadku rozpoczęcia dnia pracy bez wprowadzenia do systemu danych o dacie i godzinie wejścia na teren zakładu, przepracowane godziny nie zostaną podliczone, co jest równoznaczne z nieotrzymaniem przez pracownika zapłaty za dany dzień. 
Specjalista do spraw zatrudnienia będzie miał możliwość przeglądania i wyszukiwania zarejestrowanego wejścia lub wyjścia. Nie będzie mógł jednak dodawać wejść pracowników, edytować ich ani usuwać.
Prezes firmy podobnie jak specjalista do spraw zatrudnienia będzie miał możliwość przeglądania i wyszukiwania zarejestrowanego wejścia lub wyjścia. Będzie on mógł także edytować lub usuwać zarejestrowane wejścia lub wyjścia w przypadku ustalenia pomyłki lub oszustwa ze strony pracownika.
* Zarządzanie danymi pracowników

W bazie przechowywane będą dane wszystkich pracowników firmy. Pracownicy nie mają dostępu do swoich danych, nie mogą ich przeglądać ani samodzielnie edytować. Specjalista do spraw zatrudnienia będzie miał możliwość wyszukiwania, dodawania (w momencie zatrudnienia nowego pracownika) oraz edycji (w momencie zmiany danych osobowych przez pracownika, wyrobienia nowego dowodu osobistego, zawarcia związku małżeńskiego skutkującego zmianą nazwiska, awansu na wyższe lub degradacji na niższe stanowisko, rozpoczęcia/zakończenia urlopu, dostarczenia zwolnienia lekarskiego, rozpoczęcia okresu wypowiedzenia) danych osobowych pracowników. Jego obowiązkiem jest dbanie o porządek w bazie danych i systematyczne aktualizowanie informacji o pracownikach.
Możliwość usunięcia danego pracownika z bazy w momencie zwolnienia dyscyplinarnego lub zakończenia okresu wypowiedzenia równoznacznego ze zwolnieniem z firmy jest dostępna jedynie dla prezesa firmy.
* Zarządzanie stanowiskami i działami

Prezes firmy będzie zajmował się kontrolą danych dotyczących działów i stanowisk funkcjonujących w firmie. Będzie miał możliwość wyszukania informacji o dziale/stanowisku, dodania nowego działu/stanowiska, modyfikacja działu/stanowiska (na przykład zmiana stawki godzinowej obowiązującej na danym stanowisku), usunięcie działu/stanowiska.
Dostęp o danych dotyczących działów i stanowisk ma także specjalista do spraw zatrudnienia. Może on wyszukiwać pożądane informacje, ale nie ma prawa ich dodawania, modyfikowania ani usuwania.
Pracownicy nie mają dostępu do informacji dotyczących działów i stanowisk. 
* Zarządzanie godzinami pracy

Obowiązkiem prezesa firmy jest także ustalenie godzin pracy obowiązujących w danym dniu tygodnia w danym dziale. Dla każdego dnia tygodnia i każdego działu powinien być ustalony przedział godzin, w których pracownicy powinni być obecni na terenie zakładu. Prezes może dodawać nowe rekordy (na przykład ustanowienie soboty dniem pracującym dla konkretnego działu), modyfikować (na przykład skrócenie/wydłużenie godzin pracy w piątki dla konkretnego działu) i usuwać istniejące (na przykład ustanowienie poniedziałków dniem wolnym dla konkretnego działu).
Dostęp o danych dotyczących godzin pracy ma także specjalista do spraw zatrudnienia. Może on wyszukiwać pożądane informacje, ale nie ma prawa ich dodawania, modyfikowania ani usuwania.
Pracownicy nie mają dostępu do informacji dotyczących godzin pracy.
* Dodatkowe funkcjonalności

Specjalista do spraw zatrudnienia i prezes mają także dostęp do dodatkowych funkcjonalności bazy takich jak spóźnienia oraz posumowanie miesięczne. Mogą oni kontrolować punktualność pracowników, korzystając ze specjalnie przygotowanej tabeli spóźnień. Tabela ta zestawia dane z tabeli wejść i tabeli godzin pracy, a następnie wyświetla wszystkie spóźnienia pracowników w wybranym dniu. Podsumowanie miesięczne pozwala na podliczenie przepracowanych godzin oraz ewentualnej realizacji nadgodzin przez poszczególnych pracowników, a nawet wyliczenie wysokości wynagrodzenia dla każdego pracownika. Stawka godzinowa przypisana jest do stanowiska. Za pracę w godzinach nadliczbowych przysługuje dodatek w wysokości 50% stawki godzinowej. Wynagrodzenie wypłacane jest z dołu, do 10 dnia każdego miesiąca, a jego wysokość obliczana jest na podstawie wzoru: wynagrodzenie = ilość przepracowanych godzin*stawka godzinowa + ilość nadgodzin*stawka godzinowa*150%. Wysokość wynagrodzenia przeliczana jest także na walutę euro, dzięki wykorzystaniu publicznego Web API umożliwiającego klientom wykonywanie zapytań na poniższych zbiorach danych publikowanych przez Narodowy Bank Polski.

## Bezpieczeństwo
Aplikacja zapewnia autoryzację oraz panel logowania do niej, dzięki któremy w zależności kto się zaloguje dostaje odpowiedni widok z odpowiednimi funkcjami.
* Widok prezesa:

(screen) 

* Widok specjalisty do spraw zaturdniania

(screen)

* Widok pozostałych pracowników

(screen)


## Wykorzystane technologie
* User Interface
* Log
* LINQ
* testy jednostkowe
* Entity Framework
* Wielowątkowość/asynchroniczność
* Komunikacja z zewnętrznym api (komunikacja z przelicznikiem walut)
* NuGety:
  * EntityFramework 6.4.0
  * Microsoft.AspNet.WebApi.Client 5.2.7
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

## Uruchomienie


## Przykłady kodu


## Status

