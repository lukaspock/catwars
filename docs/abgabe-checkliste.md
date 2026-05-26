# Abgabe-Checkliste

Diese Liste wird 1:1 bei der Bewertung verwendet.

---

## A) MVP & Spielbarkeit (MUSS)
- [X] MVP ist im `docs/GDD.md` klar definiert.
- [X] MVP ist vollständig umgesetzt (alle MVP-Checkboxen im GDD abgehakt).
- [x] Das Spiel ist von Start bis Ende **spielbar** (ohne Dev-Tools).
- [x] Es gibt eine klare Win/Lose Condition (oder klarer Endzustand).

---

## B) Build / Ausführbare Version (MUSS)
- [X] Im Ordner `/builds` liegt ein Zip der Abgabeversion.
- [X] Zip enthält nur das Spiel (keine Engine-Projektdateien).
- [X] Das Spiel startet auf einem anderen PC (Test in der Klasse!).
- [X] Steuerung ist im Build verständlich (z.B. im Startscreen oder README).

Empfohlener Dateiname:
- `YYYY-MM-DD_vX.Y_final_<Teamname>.zip`

---

## C) Repository (MUSS)
- [X] `README.md` enthält:
  - [X] Spielname + 2-Satz Pitch
  - [X] Steuerung
  - [X] Wie starten (Build / Link / Hinweise)
  - [X] Teammitglieder + Rollen
- [X] Repo-Struktur ist sauber (docs, builds, project).
- [X] Keine privaten Daten / Passwörter / Keys im Repo.

---

## D) Dokumentation (MUSS)
- [X] `docs/GDD.md` ist ausgefüllt:
  - [X] High Concept
  - [X] Core Gameplay Loop
  - [X] MVP Must-Haves 
  - [2/3] Nice-to-Haves
  - [X] Controls/Mechaniken
- [X] `docs/DEVLOG.md` ist aktuell:
  - [X] Jede Woche ein Eintrag
  - [X] Pro Person ist ersichtlich, was gemacht wurde

---

## E) Credits & Lizenzen (MUSS)
- [X] Alle fremden Assets sind aufgelistet (Grafik, Sound, Fonts).
- [X] Lizenz ist dokumentiert (z.B. CC0 / CC-BY / Asset Store).
- [X] Eigene Quellen sauber getrennt von Fremdquellen.

---

## F) Qualitätssicherung (Soll)
- [X] “Frischer Test”: 5 Minuten Playtest durch jemanden, der das Spiel nicht gebaut hat.
- [X] Keine roten Errors/Exceptions beim Start.
- [X] Difficulty ist fair (nicht “unmöglich” in den ersten 30 Sekunden).
- [X] Bekannte Bugs sind kurz notiert (im README oder Devlog).

---

## G) Finaler Git-Schritt (MUSS)
- [X] Alle Feature-Branches sind gemerged.
- [X] `main` ist aktuell und baubar.
- [X] Tag gesetzt: `v1.0-final`
- [X] Tag ist gepusht.

---

## H) Optional (Bonus)
- [ ] Kurzes Gameplay-Video (30–90 Sekunden).
- [ ] 3 Screenshots im README.
- [ ] Kurzer “Postmortem”-Abschnitt: Was lief gut, was nicht?
