# Abgabe-Checkliste

Diese Liste wird 1:1 bei der Bewertung verwendet.

---

## A) MVP & Spielbarkeit (MUSS)
- [ ] MVP ist im `docs/GDD.md` klar definiert.
- [ ] MVP ist vollständig umgesetzt (alle MVP-Checkboxen im GDD abgehakt).
- [ ] Das Spiel ist von Start bis Ende **spielbar** (ohne Dev-Tools).
- [ ] Es gibt eine klare Win/Lose Condition (oder klarer Endzustand).

---

## B) Build / Ausführbare Version (MUSS)
- [ ] Im Ordner `/builds` liegt ein Zip der Abgabeversion.
- [ ] Zip enthält nur das Spiel (keine Engine-Projektdateien).
- [ ] Das Spiel startet auf einem anderen PC (Test in der Klasse!).
- [ ] Steuerung ist im Build verständlich (z.B. im Startscreen oder README).

Empfohlener Dateiname:
- `YYYY-MM-DD_vX.Y_final_<Teamname>.zip`

---

## C) Repository (MUSS)
- [ ] `README.md` enthält:
  - [ ] Spielname + 2-Satz Pitch
  - [ ] Steuerung
  - [ ] Wie starten (Build / Link / Hinweise)
  - [ ] Teammitglieder + Rollen
- [ ] Repo-Struktur ist sauber (docs, builds, project).
- [ ] Keine privaten Daten / Passwörter / Keys im Repo.

---

## D) Dokumentation (MUSS)
- [ ] `docs/GDD.md` ist ausgefüllt:
  - [ ] High Concept
  - [ ] Core Gameplay Loop
  - [ ] MVP Must-Haves + Nice-to-Haves
  - [ ] Controls/Mechaniken
- [ ] `docs/DEVLOG.md` ist aktuell:
  - [ ] Jede Woche ein Eintrag
  - [ ] Pro Person ist ersichtlich, was gemacht wurde

---

## E) Credits & Lizenzen (MUSS)
- [ ] Alle fremden Assets sind aufgelistet (Grafik, Sound, Fonts).
- [ ] Lizenz ist dokumentiert (z.B. CC0 / CC-BY / Asset Store).
- [ ] Eigene Quellen sauber getrennt von Fremdquellen.

---

## F) Qualitätssicherung (Soll)
- [ ] “Frischer Test”: 5 Minuten Playtest durch jemanden, der das Spiel nicht gebaut hat.
- [ ] Keine roten Errors/Exceptions beim Start.
- [ ] Difficulty ist fair (nicht “unmöglich” in den ersten 30 Sekunden).
- [ ] Bekannte Bugs sind kurz notiert (im README oder Devlog).

---

## G) Finaler Git-Schritt (MUSS)
- [ ] Alle Feature-Branches sind gemerged.
- [ ] `main` ist aktuell und baubar.
- [ ] Tag gesetzt: `v1.0-final`
- [ ] Tag ist gepusht.

---

## H) Optional (Bonus)
- [ ] Kurzes Gameplay-Video (30–90 Sekunden).
- [ ] 3 Screenshots im README.
- [ ] Kurzer “Postmortem”-Abschnitt: Was lief gut, was nicht?
