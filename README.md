# 🎲 Monopoly

**Monopoly** est une version revisitée du célèbre jeu de société, développée en collaboration avec **Lilian Mirabel**. Ce projet a été pensé comme un terrain de jeu pour mettre en pratique nos compétences en développement Unity, tout en ajoutant notre propre touche aux règles et à l'expérience de jeu.

> Un projet codé entre amis dans le cadre de nos cours de Jeux-Vidéo au Cégep de La Pocatière.

## 🚀 Fonctionnalités principales

- 🧱 Plateau interactif et personnalisable
- 💸 Gestion dynamique des propriétés, loyers et transactions
- 🎲 Lancer de dés simulé avec animations
- 👥 Mode multijoueur local

## 📦 Installation

### 1. Cloner le projet

```bash
git clone https://github.com/Percyyyyyy/Monopoly.git
cd Monopoly
```

### 2. Ouvrir dans Unity

- Lancer **Unity Hub**
- Ajouter le dossier cloné comme nouveau projet
- Ouvrir avec la version recommandée (Unity [2022.3.13f1])

### 3. Lancer le jeu en appuyant sur `Play` dans l’éditeur

## 🧪 Technologies utilisées

- 🎮 **Unity (2022.3.13f1)** – Moteur de jeu utilisé pour construire l'ensemble du gameplay et de la logique
- 🧠 **C#** – Langage principal pour les scripts (gestion des règles, mouvements, UI…)
- 🧰 **Unity Input System** – Gestion moderne des entrées utilisateurs (clavier/souris/manette)
- 🗂️ **ScriptableObjects** – Système de données pour les propriétés, cartes, et éléments de plateau
- 🎥 **Cinemachine / Camera Controller** – Gestion fluide et dynamique de la caméra pendant le jeu
- 🖼️ **Unity UI Toolkit & Canvas** – Interface utilisateur dynamique (affichage d'infos, boutons, menus)
- 🧱 **Prefab System** – Réutilisation d'objets (joueurs, cases, UI…)
- 🧊 **Blender** – Certains éléments du plateau ou pions ont été modélisés en 3D dans Blender, puis importés dans Unity

## 🛠️ TODO

🎨 Refonte de l’UI pour un rendu plus moderne  
🧠 Amélioration de l’IA pour le mode solo (si implémenté)  
🎭 Ajout de cartes joker personnalisées  
🔧 Sauvegarde et reprise de parties  
🎲 Refonte du système de dés : actuellement, le jeu se lance bien, mais reste bloqué sur une boucle infinie affichant toujours "5". Ce bug critique empêche toute partie de se dérouler normalement.


## ⚠️ État actuel

Le projet est **fonctionnel au lancement** (scènes, plateau, interface, logique de base), mais **non jouable à ce jour** à cause d’un bug critique :

- 🎲 Le script de lancer de dés (provenant d’une source externe) affiche constamment "5" en boucle infinie.  
- ❌ Il empêche toute progression dans le jeu.  

## ⚠️ Remarques

🎲 Le script de lancer de dés actuellement utilisé **ne provient pas de nous**.  
Il a été intégré à titre expérimental, mais **ne fonctionne pas comme nous l'aurions souhaité** (manque de réalisme, animations limitées, logique peu claire).

🛠️ Ce système est donc **amené à être entièrement refait** dans une version ultérieure, avec un vrai focus sur l'animation et l'intégration au gameplay.

## 📄 Licence

Ce projet est open-source pour usage personnel, éducatif ou collaboratif.

---

Fait avec ❤️ par **[Kenzo AFFAGARD]** & **Lilian Mirabel**(https://github.com/lilianmirabel)
