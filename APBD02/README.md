## Opis projektu
Aplikacja w języku C# służąca do zarządzania wypożyczalnią sprzętu (w tym przypadku dla studentów i pracowników)

## Decyzje projektowe
W projekcie zastosowano podział na warstwy w celu zwiększenia czytelności i prostszego rozwoju projektu
**Models**: Zawiera klasy domenowe, w tym klasę abstrakcyjną dla sprzętu, co pozwala na uniknięcie duplikacji kodu
**Services**: Klasa RentalService skupia całą logikę
**Exceptions**: Przechowuje autorskie wyjątki

## Kohezja i Odpowiedzialności
Kohezja została zadbno poprzez nadanie każdej klasie jednej, ale jasnej odpowiedzialności
* Klasa User przechowuje wyłącznie ogólne dane o użytkowniku
* Klasa RentalService odpowiada za przebieg wypożyczania/zwrotów

## Coupling
W celu uzyskania niskiego sprzężenia, logika biznesowa została całkowicie oddzielona od interfejsu użytkownika w Program.cs, dzięki czemu serwis nie wie, w jaki sposób dane są wyświetlane w konsoli.

## Instrukcja uruchomienia:
1. Sklonowanie repozytorium
2. Otworzenie pliku .sln w odpowiednim środowisku programistycznym
3. Zbuduj projekt
4. Uruchom aplikację w klasie Program.cs