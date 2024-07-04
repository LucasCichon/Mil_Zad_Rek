Onośnie ostatniej części drugiego zadania. Postanowiłem stworzyć szkielet aplikacji MVC. System, służący do flagowania produktów pobranych z plików dostawców, zapisujący oflagowane dane w osobnej bazie/pliku.
Aplikacja jest podzielona na poszczególne warstwy:
1. Warstwa Infrastruktury zawierająca Repozyrotia wyciągające dane z plików/bazy. Konvertery, które rzutują te dane na DTO, ponieważ dane (przynajmniej te od dostawców) pochodzą z plików xml.
2. Warstwa Domeny zawiera te obiekty, oraz obiekt finalProduct, który będzie używany jako główny obiekt domenowy. Do niego będziemy convertować wszystkie obiekty DTO pochodzące od różnych dostawców.
3. Warstwa Aplikacji, czyli logiki biznesowej. Tutaj odbywa się logika, związana z przekonvertowaniem obiektów DTO na finalProduct, powiązaniem produktów z już oflagowanymi i wyświetleniem ich użytkownikowi.
4. UI. W niej znajdują się Kontrolery i widoki aplikacji.

![image](https://github.com/LucasCichon/Mil_Zad_Rek/assets/50384668/b14d119a-0872-48d5-9967-437e41970175)
