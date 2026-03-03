# Git Workflow

Ziel: Ihr arbeitet strukturiert, verliert keine Dateien und könnt jederzeit eine spielbare Version abgeben.

---

## 1) Grundregeln (Pflicht)
- `main` ist **immer** stabil und baubar (keine kaputten Commits).
- Jedes neue Feature/Problem bekommt **einen Issue** und **einen Branch**.
- Keine großen Binärdateien in Git, wenn es vermeidbar ist (z.B. rohe Videos).
- Committe **klein und oft** (nicht 1 Mega-Commit pro Woche).
- Wenn ihr im Team seid: Änderungen gehen über Merge Request / Pull Request (MR/PR).

---

## 2) Branch-Namen (Konvention)
- `feature/<kurzbeschreibung>` z.B. `feature/player-movement`
- `fix/<kurzbeschreibung>` z.B. `fix/jump-buffer`
- `docs/<kurzbeschreibung>` z.B. `docs/update-gdd`

---

## 3) Commit Messages (Konvention)
Format:
- `Add: ...`
- `Fix: ...`
- `Refactor: ...`
- `Docs: ...`

Beispiele:
- `Add: Basic player movement (left/right + jump)`
- `Fix: Player sometimes falls through platform edges`
- `Docs: Define MVP and controls`

No-Gos:
- `fix`
- `update`
- `lol`
- `aaaa`

---

## 4) Tagesablauf / Prozess (empfohlen)
### Start einer Session (jeder im Team)
1. Pull auf den neuesten Stand:
   - `git checkout main`
   - `git pull`
2. Eigenen Feature-Branch erstellen:
   - `git checkout -b feature/<name>`

### Während dem Arbeiten
- Alle 15–60 Minuten: committen (wenn etwas logisch abgeschlossen ist)
  - `git add .`
  - `git commit -m "Add: ..."`

### Am Ende der Session
1. Push:
   - `git push -u origin feature/<name>`
2. MR/PR erstellen:
   - Beschreibung: Was wurde gemacht? Was muss getestet werden?
   - Linke Hand: Screenshots oder kurzes Video, wenn sinnvoll.

---

## 5) Merge Request / Pull Request (Team)
### Checklist für MR/PR (Pflicht)
- [ ] Spiel startet (keine Crash-Errors).
- [ ] Feature entspricht dem Issue-Ziel.
- [ ] Keine ungenutzten Test-Dateien im Repo.
- [ ] Scenes/Prefabs funktionieren nach Pull (nicht nur lokal).

### Review-Regel (einfach)
- Mindestens 1 Teammitglied testet kurz.
- Erst dann wird gemerged.

---

## 6) Konflikte (Merge Conflicts) – Mini-Regelwerk
- Ruhig bleiben: Konflikte sind normal.
- Niemals “einfach irgendwas” anklicken.
- Vorgehen:
  1. Konfliktdatei öffnen.
  2. Verstehen, welche Version richtig ist.
  3. Konfliktmarker entfernen.
  4. Spiel starten und testen.
  5. Commit: `Fix: Resolve merge conflict in <file>`

---

## 7) Releases / Abgabe-Versionen (Tags)
Für Abgaben wird ein Git-Tag gesetzt, damit klar ist, welche Version bewertet wird.

Beispiel:
- `v0.1-mvp`
- `v1.0-final`

Befehle:
- `git tag v0.1-mvp`
- `git push origin v0.1-mvp`

---

## 8) Builds im Repo
- Spielbare Builds kommen in `/builds`.
- Pro Build ein Zip:
  - `builds/2026-01-13_v0.1-mvp_Windows.zip`
- Keine riesigen Ordner ungezippt ablegen.

---

## 9) MVP-Schutz gegen Feature Creep (Regel)
Bis das MVP abgenommen ist:
- Keine neuen Features ohne Issue + Teacher OK.
- Bugs im MVP haben Priorität vor “coolen Ideen”.

Wenn ihr eine neue Idee habt:
1. Als Issue anlegen.
2. In `Nice-to-Have` im GDD eintragen.
3. Erst nach MVP-Freigabe beginnen.
