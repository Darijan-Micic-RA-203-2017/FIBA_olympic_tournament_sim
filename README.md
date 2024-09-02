# FIBA_olympic_tournament_sim

## Tehnički podaci
Programer: Darijan Mićić, kandidat za poziciju "Backend Developer - C# / NodeJS" u kompaniji Codebehind d.o.o.
Početak razvoja: ponedeljak 26. avgust 2024. godine
Programski jezik: C#
Radni okvir: .NET 8
Razvojno okruženje: Microsoft Visual Studio 2022

## Opis
Ovaj projekat je simulacija FIBA Olimpijskog turnira, koji sadrži 3 grupe sa po 4 nacionalna tima u svakoj grupi. Ovaj oblik raspodele nacionalnih timova prisutan je od 2021. godine i Olimpijskih igara u Tokiju. U eliminacionu fazu (četvrtfinale) plasiraju se prva 2 tima iz svake grupe i 2 najbolja trećeplasirana tima. Timovi se rangiraju po pravilima FIBA (Međunarodnog košarkaškog saveza).

## Pokretanje
Da bi se pokrenula sama aplikacija, potrebno je u razvojnom okruženju Microsoft Visual Studio 2022 otvoriti Terminal (View -> Terminal). Nakon što se Developer PowerShell (podrazumevana terminalska aplikacija) pokrene, prvo treba uneti komandu `cd FIBA_OT_sim` kako bi se trenutni imenik terminala prebacio na imenik samog projekta. Zatim treba uneti komandu `dotnet run` i nakon građenja celokupnog rešenja, biće ispisane sledeće stavke:
1. grupna faza (utakmice po kolima i krajnji poredak u grupama);
2. timovi koji su se plasirali u eliminacionu fazu;
3. žreb za eliminacionu fazu;
4. eliminaciona faza (četvrtfinala, polufinala, utakmica za 3. mesto i finale);
5. osvajači medalja.

Da bi se pokrenuli jedinični testovi, potrebno je u Microsoft Visual Studio 2022 otvoriti Test Explorer (View -> Test Explorer) i nakon što se svi jedinični testovi otkriju, kliknuti na dugme "`Run All Test in View`" (prečica Ctrl + R, V). Celokupno rešenje će biti izgrađeno i biće prikazani rezultati svakog jediničnog testa.
