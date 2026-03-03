# 🎮 Semesterprojekt: Game Development

> **WICHTIGSTE REGEL:**
> Ein Spiel, das schlecht aussieht aber funktioniert, ist eine **1**.
> Ein Spiel, das fantastisch aussieht aber nicht läuft, ist eine **5**.

## 1. Das Eiserne Gesetz: MVP first!
Wir vermeiden **"Feature Creep"** (das ständige Hinzufügen neuer Ideen) um jeden Preis. Euer erstes Ziel ist das **MVP (Minimum Viable Product)**.

### Was ist ein MVP?
Das MVP ist die absolut kleinste Version eures Spiels, die **spielbar** ist und **Spaß macht**.
*   Es hat keine Menüs (Startknopf reicht).
*   Es hat keine High-End Grafiken (graue Boxen reichen).
*   Es hat nur EINE Kernmechanik (z.B. nur Springen, noch kein Schießen).

**Eure Aufgabe:** Definiert das MVP in der Datei `docs/GDD.md` und baut **nichts anderes**, bis dieses MVP vom Lehrer abgenommen wurde.

---

## 2. Repository Struktur
Haltet euer Repo sauber. Ein chaotisches Repo führt zu Punktabzug.

```text
/ (Root)
├── .gitignore          <-- WICHTIG! Nutzt eine Unity/Godot Vorlage!
├── README.md           <-- Diese Datei (Projektübersicht)
├── /builds             <-- Hier landen spielbare Versionen (Zips)
├── /docs               <-- Eure Dokumentation
│   ├── GDD.md          <-- Das Game Design Dokument
│   └── DEVLOG.md       <-- Euer Entwicklungstagebuch
└── /project            <-- Der eigentliche Projektordner (Unity/Godot Files)
    ├── Assets
    ├── Scenes
    └── Scripts
