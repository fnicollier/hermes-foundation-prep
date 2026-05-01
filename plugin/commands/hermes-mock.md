---
description: Examen blanc HERMES Foundation — 40 questions calibrées sur la pondération officielle, exportées en Markdown
argument-hint: "[chemin_de_sortie]   ex.: 'mock-2026-05-30.md' (optionnel)"
---

# /hermes-mock — Examen blanc HERMES Foundation

Génère un examen blanc complet de **40 questions** au format officiel TÜV SÜD, exporté en fichier Markdown que l'utilisateur peut imprimer ou passer à l'écran.

## Procédure

1. **Activer le skill `hermes-foundation`** pour charger le contexte complet.

2. **Vérifier que le mock final officiel n'est pas déjà tiré** : si l'utilisateur prépare son examen blanc final, lui rappeler que la **banque officielle des 40 questions TÜV SÜD** existe et est plus représentative. Le `/hermes-mock` génère une variante **fraîche** complémentaire, pas un substitut.

3. **Générer 40 questions** réparties selon la pondération officielle :

   | Objectif | Nombre de questions | Distribution typique |
   |----------|--------------------:|----------------------|
   | Obj 1 — Bases + vue d'ensemble | **12** | Phases (~4), Résultats/Tâches (~3), Modules vue d'ensemble (~2), Scénarios vue d'ensemble (~1), Application/gouvernance (~2) |
   | Obj 2 — 2 scénarios standard | **8** | Distinction dév/adaptation (~2), modules par scénario (~3), org. projet par scénario (~2), listes de contrôle (~1) |
   | Obj 3 — 7 modules approfondis | **10** | But du module (~4), tâches/résultats (~4), rôles responsables (~2) |
   | Obj 4 — Organisation de projet | **10** | Org. classique/agile (~3), principes d'attribution (~3), 3 rôles min (~2), niveau hiérarchique des rôles (~2) |

4. **Mix taxonomie et types** :
   - ~50 % Facile, ~40 % Moyen, ~10 % Difficile (mini-cas).
   - ~80 % A(pos), ~20 % A(neg).
   - Position des bonnes réponses (a/b/c/d) randomisée — ~25 % chacune.

5. **Sortie en deux parties dans le fichier** :
   - **Partie 1 — Questions** : les 40 questions, numérotées, sans révéler les réponses. À imprimer ou répondre dans une grille à part.
   - **Partie 2 — Corrigé** : à la fin du même fichier (séparé clairement par un `---` et un titre), les 40 corrections avec réponse, explication, référence au manuel.

6. **Sauvegarder le fichier** dans `C:\Users\FNI\Documents\Claude\Projects\Hermes\` :
   - Nom par défaut si pas d'argument : `mock-hermes-foundation-YYYY-MM-DD.md`
   - Nom personnalisable si l'utilisateur fournit un chemin.

7. **Présenter le fichier à l'utilisateur** avec :
   - Lien `computer://` vers le fichier.
   - Rappel des règles : 60 minutes, pas de points négatifs, toujours répondre, lire deux fois les énoncés A(neg).
   - Recommandation : faire les 40 questions d'affilée avant de regarder le corrigé.

8. **Optionnel** : Proposer en fin de message d'analyser les résultats une fois l'examen passé. Si l'utilisateur revient avec ses réponses, calculer le score, identifier les points faibles, proposer des `/hermes-drill` ciblés.

## Règles strictes

- **Toujours en français.**
- **Ne jamais réutiliser** les 40 questions de la banque officielle TÜV SÜD (`Exemples_de_questions_HERMES-2022-Foundation.pdf`). Générer du contenu original mais conforme au style.
- Distribution stricte des objectifs : 12 / 8 / 10 / 10 — pas d'écart de plus de ±1 par catégorie.
- Aucune question sur le hors-scope (programme, custom scenarios, modules IT en profondeur, outils online).
- Format Markdown propre — chaque question utilisable individuellement par copier-coller.

## Format du fichier de sortie

```markdown
# Examen blanc HERMES 2022 Foundation
**Date :** [YYYY-MM-DD]
**Durée :** 60 minutes
**Nombre de questions :** 40 (choix unique)
**Notation :** +1 par bonne réponse, 0 si non cochée, pas de points négatifs

---

## Questions

### Question 1
**Objectif :** Obj 1.3 — Phases
**Type :** A(pos)
**Énoncé :** [...]

a) [...]
b) [...]
c) [...]
d) [...]

### Question 2
[...]

[... 40 questions au total ...]

---

## Corrigé

### Q1 — Réponse : c
**Explication :** [...]
**Référence :** Manuel HERMES p. 17

[... 40 corrections ...]

---

## Récapitulatif

| Objectif | Questions | Poids officiel |
|----------|-----------|---------------:|
| Obj 1    | Q1-Q12    | 30 % |
| Obj 2    | Q13-Q20   | 20 % |
| Obj 3    | Q21-Q30   | 25 % |
| Obj 4    | Q31-Q40   | 25 % |
```

## Exemples d'invocation

- `/hermes-mock` → fichier auto-nommé `mock-hermes-foundation-2026-04-30.md` dans Hermes/
- `/hermes-mock mock-final.md` → fichier nommé manuellement
