# Game Design Document (GDD)

**Projektname:** Cat Wars
**Teammitglieder:** Lukas Pock, Gregor Kerschbaumer & Justin Tatzgern
**Engine:** Unity

---

## 1. High Concept (Der Pitch)
> Beschreibt euer Spiel in maximal 2 Sätzen. (Elevator Pitch)
*Beispiel: Ein 2D-Platformer, bei dem der Spieler die Schwerkraft alle 10 Sekunden umkehren muss, um aus einem sinkenden Turm zu entkommen.*

**Antwort:**
Man spielt in einem 3d third person game als ein Katzen Character und wird in einem Wellen - Gameplayloop von Gegnern angegriffen und kann immer nach jeder Welle (wenn man sie überlebt) upgrades freischalten und weiterspielen.

## 2. Core Gameplay Loop
> Was macht der Spieler Sekunde für Sekunde? (Beschreibt die Schleife)
*Beispiel: Gegner sichten -> In Deckung gehen -> Schießen -> Munition sammeln -> Weitergehen.*

**Antwort:**
Spiel starten -> Erste Welle -> upgrade -> Zweite Welle -> upgrade -> ... -> Gewonnen / Verloren -> Nochmal spielen


## 3. Das MVP (Minimum Viable Product) - Euer Vertrag
Dies ist der wichtigste Teil. Was MUSS zur Deadline funktionieren? Alles hier Aufgelistete ist notenrelevant. Alles was NICHT hier steht, ist Bonus.

**Die 3 Pflicht-Features (Must-Haves):**
1. [ ] Wave Based System
2. [ ] Generieren von Gegnern
3. [ ] Shop based System mit Upgrades

**Die "Nice-to-Haves" (Nur wenn Zeit bleibt!):**
*   [ ] verschiedene Waffen und Items
*   [ ] verschiedene Start Charaktere
*   [ ] Soundeffekte

## 4. Steuerung & Mechanik
| Aktion | Taste / Input | Effekt im Spiel |
| :--- | :--- | :--- |
| Bewegung | WASD | Spieler bewegt sich horizontal |
| Angriff | Auto Target | Gegner werden automatisch angegriffen wenn man nahe genug zu ihnen ist |

## 5. Assets & Technik
*   **Grafikstil:** Low Poly
*   **Audio:** Aus dem Internet / Asset store
*   **Besondere Herausforderung:** erstellen der Low Poly Models in Blender, Auto Target System

