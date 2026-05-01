# HERMES Foundation Quiz

Plugin de préparation à la certification **HERMES 2022 Foundation** (méthode officielle de gestion de projet de la Confédération suisse).

Calibré sur les *Objectifs didactiques* officiels (Chancellerie fédérale, Édition décembre 2025) et le style de questions de **TÜV SÜD Akademie** (organisme certificateur).

## À qui ça s'adresse

- Solution Architects, Project Managers et Business Analysts qui préparent l'examen Foundation.
- Surtout pour les contextes mandats Confédération suisse (où HERMES est obligatoire).
- Idéal pour préparer une certification individuelle ou comme outil partagé en équipe.

## Trois commandes

### `/hermes-quiz [topic|objectif] [N]`

Quiz interactif. Une question à la fois, correction immédiate, score continu.

```
/hermes-quiz Rôles 5
/hermes-quiz "Obj 4" 10
/hermes-quiz Phases
```

### `/hermes-mock [chemin_de_sortie]`

Examen blanc complet — 40 questions calibrées sur la pondération officielle (Obj 1 : 30 %, Obj 2 : 20 %, Obj 3 : 25 %, Obj 4 : 25 %), exporté en fichier Markdown imprimable.

```
/hermes-mock
/hermes-mock examen-blanc-final.md
```

### `/hermes-drill <concept>`

Drill intensif sur un seul concept (5-10 questions, même angle, correction approfondie).

```
/hermes-drill niveaux hiérarchiques
/hermes-drill comité spécialisé
/hermes-drill jalons
```

## Périmètre couvert

**Testable** :
- Obj 1 — Bases de la méthode + tous les éléments en vue d'ensemble (30 %)
- Obj 2 — 2 scénarios standard : *Développement* + *Adaptation* prestation/produit (20 %)
- Obj 3 — 7 modules approfondis : Pilotage, Conduite, Bases, Achat, Organisation, Produit, Organisation du déploiement (25 %)
- Obj 4 — Organisation de projet, rôles + responsabilités (25 %)

**Hors scope** (le plugin refuse de générer des questions sur ces sujets) :
- Gestion de programme
- Gestion du développement agile détaillée (Scrum, cérémonies, artefacts)
- Scénarios personnalisés (Obj 5 = 0 %)
- Modules IT en profondeur (Système informatique, Tests, SIPD, Migration informatique, Exploitation informatique)
- Outils & templates HERMES online
- Comparaison à d'autres méthodes PM

## Sources & limites

Le plugin s'appuie sur :
- *HERMES — Manuel de référence — gestion de projet*, Édition 2022 (Chancellerie fédérale, 252 pages).
- *Objectifs didactiques Foundation*, Édition décembre 2025 (Chancellerie fédérale, secteur TNI).
- Le format des 40 questions exemple de TÜV SÜD Akademie GmbH.

**Important** :
- Les questions générées approximent le style officiel mais **ne sont pas** des questions officielles.
- Source faisant foi pour la certification : [hermes.admin.ch](https://www.hermes.admin.ch) (principe *Digital First*).
- Les seuils de réussite, durée exacte de l'examen et règles d'inscription doivent être vérifiés sur le site officiel et auprès du prestataire de certification (TÜV SÜD Akademie).

## Architecture du plugin

```
hermes-foundation-quiz/
├── .claude-plugin/
│   └── plugin.json
├── commands/
│   ├── hermes-quiz.md
│   ├── hermes-mock.md
│   └── hermes-drill.md
├── skills/
│   └── hermes-foundation/
│       ├── SKILL.md
│       └── references/
│           ├── objectifs-didactiques.md
│           ├── modules-et-scenarios.md
│           ├── roles-organisation.md
│           ├── style-questions.md
│           └── pieges-frequents.md
└── README.md
```

## Auteur

Fabian Nicollier (ELCA) — usage interne ELCA.
