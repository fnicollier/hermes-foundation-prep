---
name: hermes-foundation
description: Domain knowledge for HERMES 2022 Foundation certification. Use when generating practice MCQs in the style of the official TÜV SÜD Akademie exam, evaluating answers, explaining concepts in French, mapping topics to the official Lernziele weighting (Obj 1-4), or building mock exams. Triggers on phrases like "HERMES Foundation", "HERMES quiz", "QCM HERMES", "examen blanc HERMES", "préparer la certification HERMES", "questions HERMES", "drill HERMES".
---

# HERMES 2022 Foundation — Quiz Generator

This skill encodes the official syllabus, weighting, scope boundaries, and question style for the HERMES 2022 Foundation certification exam (Swiss Federal Chancellery, Édition décembre 2025).

The skill is invoked by three commands: `/hermes-quiz`, `/hermes-mock`, `/hermes-drill`. It also activates whenever a user asks about HERMES Foundation question generation or evaluation outside those commands.

## Operating principles

- **All output is in French.** The certification exam is taken in French; users practice in French.
- **Anchor every question to a specific objective.** Each generated question must declare which official objective (1.1 to 4.2) it tests.
- **Cite a manual page** in every correction. The reference is `HERMES — Manuel de référence — gestion de projet — Édition 2022` (252 pages).
- **Respect the official scope** described in `references/objectifs-didactiques.md`. Never generate a question on a topic flagged as "non pertinent pour l'examen".
- **Match the TÜV SÜD style** described in `references/style-questions.md`: 4 single-answer choices, one correct, plausible distractors, neutral tone.
- **Reserve the 40 official sample questions** as the final mock exam. Generate fresh, original questions — do not paraphrase or copy the official bank.

## Scope (in / out)

**In scope (testable):**

- Objectif 1 (30 %) — bases de la méthode + tous les éléments en vue d'ensemble
- Objectif 2 (20 %) — 2 scénarios standard : *Développement* + *Adaptation* prestation/produit
- Objectif 3 (25 %) — 7 modules : Pilotage, Conduite, Bases, Achat, Organisation, Produit, Organisation du déploiement
- Objectif 4 (25 %) — organisation de projet (rôles + responsabilités)

**Out of scope (do NOT test):**

- Gestion de programme (annexe du manuel)
- Gestion du développement agile détaillée (rôles propres Scrum, cérémonies, artefacts)
- Scénarios personnalisés (Obj 5 = 0 %)
- Modules IT en profondeur : Système informatique, Tests, SIPD, Migration informatique, Exploitation informatique (à savoir nommer uniquement)
- Scénarios IT et Adaptation organisation (à savoir nommer uniquement)
- Outils & templates HERMES online (Obj 1.10)
- Comparaison à d'autres méthodes PM (Obj 1.1 partiel)
- Distinction projet / affaires courantes (Obj 1.1)

If a user requests a question on an out-of-scope topic, refuse politely and propose an in-scope alternative.

## Question generation procedure

When asked to generate N questions on a topic, follow this procedure:

1. **Identify the targeted objective(s)** from `references/objectifs-didactiques.md`. If the user gave a topic name (e.g. "Rôles"), map it to one or more objectives.
2. **Determine the taxonomy level** for each question:
   - *Facile* (Bloom: savoir) — restitution directe (énumérer, nommer)
   - *Moyen* (savoir + comprendre) — interprétation, attribution, comparaison
   - *Difficile* (savoir + comprendre dans contexte) — application à un cas
   Match the official taxonomy of the chosen objective (see `references/objectifs-didactiques.md`).
3. **Choose the question type:**
   - `A(pos)` — « Lequel des énoncés est CORRECT ? » (default, ~80 %)
   - `A(neg)` — « Lequel des énoncés est INCORRECT / N'EST PAS… ? » (~20 %, signal explicitly)
4. **Write the stem** in neutral French, 1-3 lines. Avoid "always/never" unless intentional.
5. **Write 4 choices (a, b, c, d):**
   - Exactly one correct, in alignment with the manual.
   - Three plausible distractors. Pull distractor patterns from `references/pieges-frequents.md` (e.g. confusing *Comité spécialisé* with *Comité de pilotage*, confusing modules *Organisation* and *Organisation du déploiement*).
   - Choices have similar length and grammatical structure (prevents giveaways).
   - Randomize the position of the correct answer across questions.
6. **Provide the correction** with: correct letter, 1-2 sentence explanation, manual page reference, objective tested.

## Output format for questions

Use this exact format for every question, in French:

```markdown
### Question [N]

**Objectif testé :** [e.g. Obj 4.2]
**Type :** A(pos) ou A(neg)
**Taxonomie :** Facile / Moyen / Difficile

**Énoncé :**
[Le texte de la question]

a) [option a]
b) [option b]
c) [option c]
d) [option d]
```

For the correction (provided after answer or at end of set):

```markdown
### Correction Q[N]

**Réponse correcte :** [lettre]
**Explication :** [1-2 phrases courtes ; cite la page du manuel]
**Référence :** Manuel HERMES p. [X]
```

## Interactive mode (used by `/hermes-quiz` and `/hermes-drill`)

In interactive mode:

1. Present **one question at a time** without revealing choices' correctness.
2. Wait for the user's answer (a/b/c/d) before proceeding.
3. After their answer: reveal correct/incorrect, give the correction, then offer to continue or stop.
4. Track running score (e.g., `Score : 4/5 — 80 %`).
5. At the end of the set: show final score, breakdown by objective, and identify weak areas.

## Mock exam mode (used by `/hermes-mock`)

In mock mode:

1. Generate exactly 40 questions in one batch, distributed by official weighting:
   - 12 questions Obj 1 (30 %)
   - 8 questions Obj 2 (20 %)
   - 10 questions Obj 3 (25 %)
   - 10 questions Obj 4 (25 %)
2. Mix taxonomy levels and A(pos)/A(neg) types as in the real exam (~80/20).
3. Output **all 40 questions first**, then **all 40 corrections** at the end (so the user can sit the exam in 60 minutes before reviewing).
4. Save the result to a Markdown file in the workspace folder, with a timestamp.
5. Remind the user the time limit is 60 minutes and that pass mark / scoring details should be confirmed on hermes.admin.ch.

## Reference files

Detailed content lives in:

- `references/objectifs-didactiques.md` — full Obj 1-4 syllabus, sub-objectives, taxonomy per Obj
- `references/modules-et-scenarios.md` — 7 modules tested + 2 scenarios tested + brief mention of the rest
- `references/roles-organisation.md` — niveaux hiérarchiques, groupes de partenaires, 3 rôles min, principes d'attribution
- `references/style-questions.md` — TÜV SÜD style guide + Bloom taxonomy mapping
- `references/pieges-frequents.md` — common pitfalls observed in the official 40-question bank

Load the relevant reference file(s) before generating questions on a given topic.

## Calibration disclaimer

Generated questions approximate the official TÜV SÜD style but are NOT official certification questions. The only official questions are those in the TÜV SÜD sample bank. Pass-mark thresholds, exact session length, and current rules must be verified on [hermes.admin.ch](https://www.hermes.admin.ch) and via the certification provider.
