---
description: Quiz interactif HERMES Foundation — questions une par une avec correction immédiate
argument-hint: "[topic|objectif] [N]   ex.: 'Rôles 5' ou 'Obj 4 10' ou 'Phases'"
---

# /hermes-quiz — Quiz interactif HERMES Foundation

Lance une session de quiz interactive en français pour préparer la certification **HERMES 2022 Foundation**.

## Procédure

1. **Activer le skill `hermes-foundation`** pour charger le contexte (objectifs, modules, scénarios, rôles, pièges).

2. **Parser l'argument utilisateur :**
   - Topic libre (« Rôles », « Phases », « Tâches décisionnelles »…) → mapper à un ou plusieurs objectifs via `references/objectifs-didactiques.md`.
   - Objectif précis (« Obj 4 », « 1.6 », « 4.2 ») → ciblage direct.
   - Aucun argument → demander à l'utilisateur sur quoi il veut être interrogé (proposer les 4 grands objectifs).
   - Nombre de questions : par défaut **5**, max 15.

3. **Refus si hors scope** : si l'utilisateur demande un topic non testé (gestion de programme, scénarios custom, modules IT en profondeur, outils HERMES online), expliquer poliment qu'il n'est pas testé et proposer un topic testable proche.

4. **Générer une question à la fois** au format spécifié dans `skills/hermes-foundation/references/style-questions.md` :
   - Une question complète (énoncé + 4 choix a/b/c/d).
   - Indiquer l'objectif testé, le type A(pos)/A(neg), la taxonomie.
   - **Ne pas révéler la réponse**.

5. **Attendre la réponse** de l'utilisateur (a, b, c, d, ou texte libre du genre « b », « la b », « réponse b »).

6. **Réagir à la réponse :**
   - Indiquer si c'est correct ou non.
   - Donner la **correction structurée** : réponse correcte, explication courte (1-2 phrases), référence page du manuel.
   - Mettre à jour le score courant (« Score : 3/4 »).
   - Demander : « On continue ? » (oui par défaut → question suivante).

7. **À la fin de la session** :
   - Score final + pourcentage.
   - Répartition par objectif (« Obj 4 : 4/5 — Obj 1 : 2/3 »).
   - Identifier les **points faibles** (obj. avec < 60 % de bonnes réponses) et proposer un `/hermes-drill` ciblé.
   - Proposer une autre session ou retour à l'étude.

## Règles strictes

- **Toujours en français.**
- **Une seule question à la fois** en mode interactif (jamais batcher).
- **Ne pas réutiliser** les 40 questions de la banque officielle TÜV SÜD (réservées au mock final).
- Distracteurs piochés dans `references/pieges-frequents.md`.
- Si l'utilisateur dit « stop », « arrête », « fini » à n'importe quel moment, clore proprement avec le score partiel.

## Exemples d'invocation

- `/hermes-quiz` → demande à l'utilisateur ce qu'il veut tester
- `/hermes-quiz Rôles 5` → 5 questions sur Obj 1.6 + Obj 4
- `/hermes-quiz Obj 3 10` → 10 questions sur les 7 modules approfondis
- `/hermes-quiz Phases` → 5 questions (défaut) sur Obj 1.3
- `/hermes-quiz "Tâches décisionnelles" 3` → 3 questions très ciblées
