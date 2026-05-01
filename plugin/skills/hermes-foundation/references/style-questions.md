# Style officiel des questions HERMES Foundation (TÜV SÜD Akademie)

Référence : banque officielle de 40 questions, format `M10025-26`, source TÜV SÜD Akademie GmbH (Zertifizierungsstelle für Personal).

## Format obligatoire

- **40 questions à choix unique** (single answer).
- **4 options** par question (a, b, c, d).
- **Une seule** option correcte par question.
- Notation : **+1 par bonne réponse, 0 si non cochée, pas de points négatifs**.
- Toutes les questions sont en **français** (édition FR).
- Tous niveaux Bloom acceptent A(pos) et A(neg).

## Types de questions

### A(pos) — environ 80 % du jeu

Formulation : « Lequel des énoncés est CORRECT ? », « Quel est… ? », « Que régissent… ? ».

Exemple Q21 : *« Quels sont les rôles indispensables dans chaque projet ? »*

### A(neg) — environ 20 % du jeu

Formulation : « Lequel des énoncés N'EST PAS correct ? », « Quel rôle ne peut pas… ? ».

Exemple Q28 : *« Quels rôles ne peuvent pas être occupés par la même personne ? »*

> Toujours **signaler explicitement** la négation par une majuscule ou un mot fort (NE PAS, JAMAIS, NON-RESPECT).

## Style rédactionnel

### Énoncé (stem)

- 1 à 3 lignes maximum.
- Français formel, ton neutre, vocabulaire HERMES strict.
- Pas de "always/never" sauf intentionnel.
- Pas de double négation.
- Pas de jeu sur la ponctuation pour piéger (ce n'est pas un test de lecture rapide).
- Reformuler suffisamment par rapport au manuel pour que la réponse demande **compréhension**, pas mémorisation littérale.

Bons stems (banque officielle) :
- *« HERMES est… »*
- *« Quelles sont les phases qui composent HERMES en cas de création d'une solution en mode classique ? »*
- *« À quel moment l'organisation de projet devient-elle effective ? »*
- *« Que régissent les rôles de l'organisation de projet ? »*

### Choix (a, b, c, d)

- Longueurs et structures grammaticales **similaires** entre les 4 (pas de bonne réponse 3× plus longue).
- Numérotation par **lettre minuscule + parenthèse** : `a)`, `b)`, `c)`, `d)`.
- Les choix peuvent être :
  - une phrase complète (cas standard)
  - une fin de phrase qui complète l'énoncé (« HERMES est… ...la méthode de gestion de projet pour… »)
  - une liste courte (« Phase X, phase Y, phase Z »)
- Position de la bonne réponse **randomisée** sur l'ensemble du jeu (≈ 25 % chacune).

### Distracteurs

Trois sources d'inspiration pour des distracteurs plausibles :

1. **Confusions internes HERMES** : remplacer un terme exact par un cousin proche (Comité spécialisé / Comité de pilotage, Organisation / Organisation du déploiement, Mandant / Mandat).
2. **Erreurs courantes des candidats** : oublier qu'un rôle est en organisation permanente, confondre niveau hiérarchique pilotage/conduite, attribuer une tâche à la mauvaise phase.
3. **Vocabulaire d'autres frameworks** : termes PMI/PRINCE2/Scrum (Product Owner, Sprint, etc.) — utiliser uniquement comme distracteur reconnaissable, jamais comme bonne réponse.

❌ **Ne pas** créer de distracteurs absurdes ou trop évidemment faux.
❌ **Ne pas** créer de distracteurs « presque corrects » (ambigus) — un seul choix doit être manifestement défendable.

## Mapping taxonomie → style de question

### Facile (savoir — restitution 1:1)

Questions où la bonne réponse est dans le manuel mot pour mot ou presque.

Verbes typiques dans le stem : « énumérer », « nommer », « citer », « quels sont… ».

Exemple : *« Quelles sont les 6 phases du modèle de phases HERMES ? »*

### Moyen (savoir + comprendre — application contextuelle)

Questions où la bonne réponse demande de comprendre une relation, attribuer un élément, ou comparer.

Verbes : « expliquer », « justifier », « interpréter », « attribuer », « différencier ».

Exemple : *« Pourquoi le module Bases du projet n'est-il pas pertinent dans tel scénario ? »*

### Difficile (savoir + comprendre + application en contexte)

Questions à mini-cas (1-2 phrases de scénario suivies d'une question).

Verbes : « déterminer », « appliquer », « décider », « choisir ».

Exemple : *« Dans un projet d'adaptation de prestation/produit avec une équipe externe, quels rôles minimums faut-il attribuer au groupe Utilisateurs ? »*

## Format de sortie attendu (Markdown)

```markdown
### Question N

**Objectif testé :** [Obj X.Y]
**Type :** A(pos) ou A(neg)
**Taxonomie :** Facile / Moyen / Difficile

**Énoncé :**
[texte]

a) [option a]
b) [option b]
c) [option c]
d) [option d]
```

Pour la correction (séparée) :

```markdown
### Correction Q N

**Réponse correcte :** [lettre]
**Pourquoi :** [1-2 phrases courtes, factuelles, citant la source]
**Référence :** Manuel HERMES p. [X]
```

## Anti-patterns à éviter

- ❌ Trois bonnes réponses où une seule est « la plus correcte » — l'examen ne pratique pas cela.
- ❌ Réponses du type « Toutes les réponses ci-dessus » ou « Aucune des réponses ».
- ❌ Questions à plusieurs réponses (multi-select) — le format est strictement single-answer.
- ❌ Questions tirées telles quelles de la banque officielle TÜV SÜD (réservées pour le mock final).
- ❌ Questions sur des points marqués « non pertinent pour l'examen » dans les Lernziele.
- ❌ Questions sur des chiffres précis qui ne sont pas dans le manuel (ex. « combien de jours dure une phase ? »).
- ❌ Questions piège fondées sur la formulation et non le contenu.
