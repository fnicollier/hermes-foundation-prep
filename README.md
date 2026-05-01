# HERMES 2022 Foundation — Préparation à la certification

> Matériel de préparation pour l'examen **HERMES 2022 Foundation** délivré par TÜV SÜD Akademie GmbH (méthode officielle de gestion de projet de la Confédération suisse).

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![.NET 10 LTS](https://img.shields.io/badge/.NET-10.0-blue)](https://dotnet.microsoft.com/download/dotnet/10.0)
[![Lang: FR](https://img.shields.io/badge/lang-français-orange)](docs/vocabulaire.md)

## Contenu du dépôt

| Dossier | Description |
|---------|-------------|
| **[`docs/`](docs/)** | Fiche de **vocabulaire** (~165 termes, 47 hyperliens vers la doc officielle) et **plan d'étude** sur 4 semaines + révision finale |
| **[`cli/`](cli/)** | CLI .NET 10 `hermes-quiz` — quiz interactif avec 215 questions calibrées sur les *Objectifs didactiques* officiels (Édition décembre 2025) et le style TÜV SÜD Akademie |
| **[`plugin/`](plugin/)** | Plugin Cowork avec 3 commandes (`/hermes-quiz`, `/hermes-mock`, `/hermes-drill`) pour générer des questions interactives au sein de Claude |

## Démarrage rapide

### Pour réviser

```bash
# Ouvre directement la fiche de vocabulaire
open docs/vocabulaire.md      # macOS
xdg-open docs/vocabulaire.md  # Linux
start docs/vocabulaire.md     # Windows
```

### Pour s'entraîner avec le CLI

```bash
git clone https://github.com/<your-username>/hermes-foundation-prep.git
cd hermes-foundation-prep/cli
dotnet run                       # quiz interactif (demande combien de questions)
dotnet run -- --mock             # examen blanc 40 Q en distribution officielle
dotnet run -- --obj 4 --count 20 # 20 questions sur Obj 4 (rôles)
```

> Nécessite **.NET 10 SDK** ([download](https://dotnet.microsoft.com/download/dotnet/10.0)).

### Pour utiliser le plugin Cowork

```bash
cd plugin
zip -r ../hermes-foundation-quiz.plugin . -x "*.DS_Store"
# Importer le .plugin dans Claude Cowork via l'UI
```

## Pourquoi ce repo

La méthode HERMES est une **norme ouverte de la Confédération suisse**. La certification Foundation valide la connaissance théorique de la méthode. Préparer cet examen demande :

1. **Lire le manuel** (252 pages, FR) — disponible sur [hermes.admin.ch](https://www.hermes.admin.ch)
2. **Mémoriser le vocabulaire** technique HERMES (rôles, modules, scénarios, jalons, etc.)
3. **S'entraîner sur des QCM** au format officiel TÜV SÜD (40 questions, choix unique, 60 min)

Ce repo couvre les points 2 et 3, sans se substituer au manuel officiel. Il est conçu pour servir de **complément structuré** à la lecture du manuel pour un Solution Architect / Project Manager qui doit obtenir la certification.

## Distribution des sujets dans la banque CLI

Calibrée sur la pondération officielle des *Objectifs didactiques* :

| Objectif | Poids officiel | Q dans la banque | Couvre |
|----------|---------------:|-----------------:|--------|
| Obj 1 — Bases + vue d'ensemble | 30 % | 67 | Méthode, Phases & jalons, Résultats/Tâches, Modules, Rôles, Scénarios, Application |
| Obj 2 — 2 scénarios standard | 20 % | 40 | Champ d'application, modules par scénario, organisation, listes de contrôle |
| Obj 3 — 7 modules approfondis | 25 % | 50 | Pilotage, Conduite, Bases, Achat, Organisation, Produit, Org. déploiement |
| Obj 4 — Organisation de projet | 25 % | 58 | Org. classique/agile, niveaux hiérarchiques, principes d'attribution, descriptions de rôles |
| **Total** | **100 %** | **215** | |

## Source de vérité

- **Manuel HERMES 2022** (Chancellerie fédérale, 252 pages, version actuelle au moment de la rédaction : 3e édition du 09.03.2026)
- **Objectifs didactiques Foundation** (Édition décembre 2025)
- **Style des questions** : TÜV SÜD Akademie GmbH (organisme certificateur)

## Avertissement important

Le principe **« Digital First »** d'HERMES stipule que **seul le contenu de [hermes.admin.ch](https://www.hermes.admin.ch) fait foi pour la certification**. Ce repo est un snapshot — vérifier le site officiel avant la passation pour détecter d'éventuelles mises à jour de la méthode ou des objectifs didactiques.

Les **questions générées** dans le CLI/plugin approximent le style officiel mais **ne sont pas des questions de certification**. Les seules questions officielles sont celles fournies par TÜV SÜD Akademie aux candidats.

## Contribuer

Issues et pull requests bienvenus. Cas d'usage typiques :

- Ajouter des questions à `cli/Data/questions.json` (suivre le schéma de `cli/Models/Question.cs`)
- Enrichir le vocabulaire avec un terme manquant
- Corriger une imprécision détectée vs. la doc officielle
- Adapter pour la version EN/DE/IT (la fiche actuelle est en FR)

## Licence

[MIT](LICENSE) — utilise, modifie et partage librement. Voir le LICENSE pour le disclaimer complet sur l'absence d'affiliation avec la Chancellerie fédérale ou TÜV SÜD.

## Liens utiles

- 🌐 [HERMES Online](https://www.hermes.admin.ch) — référence officielle
- 📜 [Page Certifications HERMES](https://www.hermes.admin.ch/fr/methode/certifications.html)
- 📥 [Page Downloads (manuel + ressources)](https://www.hermes.admin.ch/fr/downloads.html)
- 🏛 [Chancellerie fédérale — TNI](https://www.bk.admin.ch/bk/fr/home/digitale-transformation-ikt-lenkung.html)

---

Bonne préparation et bon examen 💪
