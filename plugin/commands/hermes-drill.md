---
description: Drill ciblé HERMES — 5 à 10 questions sur un seul concept précis avec correction immédiate et explication approfondie
argument-hint: "<concept>   ex.: 'niveaux hiérarchiques' ou 'jalons' ou 'rôles minimums'"
---

# /hermes-drill — Drill ciblé sur un concept HERMES

Génère un drill court et intensif (5-10 questions) sur **un seul concept précis** pour combler une lacune identifiée.

## Différence avec `/hermes-quiz`

| Aspect | `/hermes-quiz` | `/hermes-drill` |
|--------|---------------|-----------------|
| Périmètre | Topic large (Phases, Rôles, Modules…) | Concept précis (un piège, une distinction) |
| Volume | 5-15 questions | 5-10 questions, plus serrées |
| Variation | Plusieurs angles | Même angle, formulations différentes |
| Correction | Courte | **Approfondie** avec contre-exemples |

## Procédure

1. **Activer le skill `hermes-foundation`**.

2. **Identifier le concept** depuis l'argument utilisateur. Mapper aux références :
   - Si le concept est dans `references/pieges-frequents.md` → utiliser le piège comme angle principal.
   - Sinon, chercher le concept dans les références et le cadrer précisément.
   - Si l'argument est vague, demander à l'utilisateur de préciser (ex. « Rôles » → trop large, proposer « niveaux hiérarchiques », « groupes de partenaires », « 3 rôles minimums », « subordinations »).

3. **Refus si hors scope** comme pour `/hermes-quiz`.

4. **Générer 5-10 questions** toutes sur le même concept, mais avec :
   - Variations de formulation (différentes angles)
   - Différents niveaux de difficulté (de Facile à Difficile)
   - Mix A(pos) et A(neg) pour entraîner la lecture attentive
   - Distracteurs qui exposent les confusions classiques de ce concept précis

5. **Mode interactif** : une question à la fois, comme `/hermes-quiz`.

6. **Correction approfondie** après chaque réponse :
   - Réponse correcte + explication courte (comme dans quiz).
   - **EN PLUS** : pourquoi chaque distracteur est faux (1 phrase chacun).
   - Référence manuel.
   - Si l'utilisateur a répondu juste : *« Pourquoi les autres sont faux : ... »*
   - Si l'utilisateur a répondu faux : *« Votre choix [X] confond [concept A] et [concept B] parce que... »*

7. **Bilan final** :
   - Si > 80 % : *« Concept maîtrisé. »*
   - Si 50-80 % : *« Bonne base, retour au manuel pages [X] recommandé. »*
   - Si < 50 % : *« Concept à reprendre. Lire le manuel p. [X], puis re-tester. »*

## Concepts canoniques (drills pré-cadrés)

Les concepts suivants ont des drills standards :

- `niveaux hiérarchiques` — distinguer Pilotage / Conduite / Exécution
- `groupes de partenaires` — distinguer Utilisateur / Producteur / Exploitant
- `3 rôles minimums` — Mandant / Chef de projet / Représentant des utilisateurs
- `comité spécialisé` — piège : organisation permanente, pas projet
- `subordinations` — qui dépend de qui (Gestionnaire QR → Chef de projet)
- `tâches décisionnelles` — pilotage vs conduite + 3 résultats systématiques
- `jalons` — Quality Gates, type *état*, attribution aux listes de décisions
- `phases classique vs agile` — 5 vs 3, différences
- `documents vs états` — types de résultats
- `effectivité organisation projet` — mandat d'initialisation
- `rôles incompatibles` — qui ne peut pas être occupé par la même personne
- `modules incontournables` — 4 modules obligatoires : Pilotage + Conduite + Bases + Organisation du déploiement
- `description structurée d'un rôle` — Description / Responsabilité / Compétences / Qualifications

Si l'utilisateur demande un de ces concepts par mot-clé, lancer le drill directement sans clarification.

## Règles strictes

- **Toujours en français.**
- **Mode interactif** une question à la fois.
- **Ne pas réutiliser** les 40 questions officielles TÜV SÜD.
- Concept unique par drill — ne pas dériver vers d'autres sujets.
- Si l'utilisateur veut élargir, lui suggérer `/hermes-quiz` à la place.

## Exemples d'invocation

- `/hermes-drill niveaux hiérarchiques`
- `/hermes-drill comité spécialisé`
- `/hermes-drill jalons`
- `/hermes-drill "tâches décisionnelles"`
- `/hermes-drill` → demande 