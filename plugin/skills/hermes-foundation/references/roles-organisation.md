# Rôles et organisation de projet HERMES — référence pour l'examen Foundation

Référence : Manuel HERMES p. 164-203.

> **Poids cumulé : Obj 1.6 + Obj 4 ≈ 40-50 % de l'examen.** C'est le chapitre le plus testé. La moitié des 40 questions de la banque officielle TÜV SÜD portent sur les rôles.

## Les 3 rôles minimums obligatoires

Tout projet HERMES, quelle que soit sa taille, doit attribuer **au minimum** ces 3 rôles :

1. **Mandant** (côté utilisateur — pilotage)
2. **Chef de projet** (conduite)
3. **Représentant des utilisateurs** (côté utilisateur — exécution / validation)

Ces 3 rôles font tous partie du **groupe de partenaires Utilisateurs** (Mandant + Représentant des utilisateurs côté demande ; le Chef de projet est attribué au groupe Utilisateurs car il représente les intérêts du mandant).

(Réf. fig. 9, p. 14 du manuel.)

## Niveaux hiérarchiques (3)

| Niveau | Finalité | Rôles attribués |
|--------|----------|-----------------|
| **Pilotage** | Piloter le projet dans son ensemble, préparer la clôture | Mandant, Comité de pilotage, Comité spécialisé |
| **Conduite** | Conduire le projet quotidiennement, garantir l'assurance qualité | Chef de projet, Gestionnaire de la qualité et des risques, Assistance de projet, Chef de sous-projet, Représentant des utilisateurs (selon scénario) |
| **Exécution** | Élaborer la solution + mettre en œuvre les mesures d'AQ | Business analyst, Développeur, Architecte informatique, Responsable des tests, Testeur, Responsable de l'exploitation, Responsable SIPD, Organisation de mise en œuvre |

(Réf. fig. 24-25, manuel p. 165-166.)

**Pièges fréquents :**
- *Comité spécialisé* est attribué au **niveau pilotage** mais il fait partie de l'**organisation permanente**, pas de l'organisation de projet (paradoxe à connaître).
- *Représentant des utilisateurs* est typiquement à la conduite mais peut être à l'exécution dans une organisation agile (position particulière, Obj 4.2).

## Groupes de partenaires (3)

Tous les rôles HERMES se classent dans **3 groupes de partenaires** :

| Groupe | Responsabilité | Rôles typiques |
|--------|---------------|----------------|
| **Utilisateur** | Définition de ses exigences, test et réception du produit/système ou de la solution | Mandant, Représentant des utilisateurs, Chef de projet, Comité spécialisé, Comité de pilotage |
| **Producteur** | Élaboration de la solution technique | Business analyst, Architecte informatique, Développeur, Responsable des tests, Testeur |
| **Exploitant** | Intégration de la solution dans l'environnement d'exploitation, exploitation | Responsable de l'exploitation, Organisation de mise en œuvre |

(Référence : Q27, Q35 de la banque officielle.)

**Le rôle d'interface** entre Utilisateurs et Producteurs/Exploitants = **Représentant des utilisateurs** (Q24).

## Description structurée d'un rôle

Chaque rôle est décrit selon **5 rubriques** (Q34) :

1. **Description**
2. **Responsabilité**
3. **Compétences**
4. **Qualifications**
5. **Relations**

(Note : la banque officielle a aussi vu la formulation à 4 éléments *description / responsabilité / compétences / qualifications* sans relations explicites — la structure exacte du manuel est de référence.)

## Subordinations clés

| Rôle | Subordonné à |
|------|--------------|
| Gestionnaire de la qualité et des risques | **Chef de projet** (Q31) |
| Assistance de projet | Chef de projet |
| Chef de sous-projet | Chef de projet |
| Comité de pilotage | Mandant |

## Effectivité de l'organisation de projet

- L'organisation de projet **devient effective avec le mandat d'initialisation du projet** (Q29).
- L'organisation de projet est **temporaire** et en étroite relation avec l'organisation permanente (Q18, Q20).
- Elle peut **être adaptée en continu** aux besoins du projet (Q36).
- Elle est **dissoute à la fin du projet** (sauf transfert explicite à la maintenance/développement).

## Principes d'attribution des rôles (slides 55-60 du cours Foundation)

### Règles strictes (formellement HERMES)

| Règle | Source |
|-------|--------|
| **Mandant ↔ Chef de projet** : ne peuvent **JAMAIS** être occupés par la même personne | slide 55 |
| **Mandant** = *toujours une seule personne physique* issue de l'organisation permanente | slide 55 |
| **Chef de projet** doit être rattaché au groupe **Utilisateur** ; **interdit** chez Producteurs/Exploitants | slide 57 |
| **Représentant des utilisateurs** doit être **Utilisateur** ; **interdit** chez Producteurs/Exploitants | slide 59 |
| **Gestionnaire QR** : organisation **indépendante**, n'assume **aucun autre rôle** dans le projet | slide 56 |

### Cumuls autorisés (avec garde-fous)

| Cumul | Condition |
|-------|-----------|
| Chef de projet + Chef de sous-projet | Disponibilité validée par le Mandant |
| Chef de sous-projet recruté chez Producteurs/Exploitants | OK — responsabilité générale au Chef de projet |
| Business analyste + Représentant des utilisateurs | Si connaissances métier approfondies |
| Représentant des utilisateurs + utilisateur final | OK |
| Chef de projet + rôle d'exécution | Si disponibilité préservée |

### Cumul déconseillé (gouvernance, pas formellement interdit)

- Chef de projet + Représentant des utilisateurs → conflit juge/partie sur exigences vs livraison.

### Synthèse

- **Seule incompatibilité strictement formelle** dans HERMES : *Mandant ↔ Chef de projet*.
- Tous les autres cumuls discutés ci-dessus sont des principes de gouvernance.
- Plusieurs personnes peuvent occuper le même rôle (rôle partagé) si l'ampleur le justifie.
- Désignations : Mandant désigne Chef de projet + Représentant des utilisateurs ; Chef de projet désigne Chef de sous-projet ; Mandant confie la gestion qualité/risques au Gestionnaire QR.

## Délimitation Chef de projet vs Représentant des utilisateurs (Obj 4.2)

| Aspect | Chef de projet | Représentant des utilisateurs |
|--------|---------------|------------------------------|
| Groupe | Utilisateur (mais conduit le projet) | Utilisateur |
| Niveau | Conduite | Conduite (classique) ou Exécution (agile) |
| Responsabilité principale |