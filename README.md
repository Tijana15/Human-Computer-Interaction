# 🎉 Projekat B – Kviz

## 🧠 Opis

Projekat B – Kviz je desktop WPF aplikacija koja korisnicima omogućava da igraju zabavno-edukativni kviz iz različitih oblasti. Korisnik bira da li želi da igra kviz sa 10 ili 20 pitanja. Svako pitanje ima tri ponuđena odgovora, od kojih je jedan tačan.

## 🔧 Tehnologije
- C#
- WPF (.NET)
- XAML

## 🚀 Pokretanje aplikacije

1. Pokrenuti rješenje u Visual Studio okruženju.
2. Provjeriti da fajl `questions.txt` postoji unutar projekta.
3. Kliknuti na `Start Quiz` nakon izbora težine kviza.
4. Odgovarati na pitanja klikom na jedno od ponuđenih dugmadi.

## 📂 Struktura pitanja (questions.txt)

Svako pitanje se unosi u jednom redu u sljedećem formatu:
Pitanje,Odgovor1,Odgovor2,Odgovor3,TačanOdgovor

Primjer:
Koji je glavni grad Francuske?,Berlin,Madrid,Pariz,Pariz

## 🎯 Pravila igre

- Svaki tačan odgovor donosi **10 poena**.
- Na kraju kviza se prikazuje:
  - Ukupan broj poena
  - Broj tačnih odgovora
  - Procenat tačnosti
  - Motivaciona poruka

## 🛠️ Funkcionalnosti

- Prikaz pitanja i odgovora
- Automatsko preračunavanje rezultata
- Vizuelni feedback za tačne i netačne odgovore
- Restart igre i izlazak iz aplikacije
- Help sekcija sa uputstvima

## 📋 Kontrole

- `Start Quiz` – pokreće kviz
- `End Game` – zatvara aplikaciju
- `Restart Game` – resetuje kviz i vraća na početak
- `Help` – prikazuje uputstvo za korišćenje

## ✨ Autor

Studentski projekat iz predmeta **Interakcija čovjek-računar (Human-Computer Interaction)**



