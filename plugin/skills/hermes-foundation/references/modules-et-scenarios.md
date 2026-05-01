# Modules et scénarios HERMES — référence pour l'examen Foundation

## Les 12 modules HERMES (à savoir énumérer ; 7 sont approfondis)

Référence : Manuel HERMES p. 33-45.

### Modules de pilotage et de conduite (obligatoires)

| Module | But résumé | Phases | Approfondi ? | Obligatoire |
|--------|------------|--------|:------------:|:-----------:|
| **Pilotage du projet** | Pilote le projet dans son ensemble, prend les décisions de pilotage | Toutes | ✅ Obj 3 | ✅ |
| **Conduite du projet** | Conduit le projet au quotidien, exécute les décisions de conduite | Toutes | ✅ Obj 3 | ✅ |

### Modules concernant l'exécution

| Module | But résumé | Phases | Approfondi ? | Obligatoire |
|--------|------------|--------|:------------:|:-----------:|
| **Bases du projet** | Pose les fondations (parties prenantes, exigences, business case) | Initialisation, Conception | ✅ Obj 3 | ✅ |
| **Achat** | Gère l'évaluation et la passation de marchés (appel d'offres, adjudication) | Conception, Réalisation | ✅ Obj 3 | — |
| **Organisation** | Adapte l'organisation permanente aux nouvelles structures issues du projet | Conception, Réalisation, Déploiement | ✅ Obj 3 | — |
| **Produit** | Développe ou adapte la prestation/le produit | Conception, Réalisation, Déploiement | ✅ Obj 3 | — |
| **Organisation du déploiement** | Organise le déploiement de la solution | Déploiement | ✅ Obj 3 | ✅ |
| Système informatique | Développe le système IT | Conception, Réalisation, Déploiement | ❌ savoir nommer | — |
| Tests | Définit et exécute les tests | Conception, Réalisation, Déploiement | ❌ savoir nommer | — |
| SIPD (Sécurité de l'information et protection des données) | Garantit la sécurité et la conformité données | Toutes | ❌ savoir nommer | — |
| Migration informatique | Migre les données et systèmes existants | Réalisation, Déploiement | ❌ savoir nommer | — |
| Exploitation informatique | Met en place l'exploitation IT | Réalisation, Déploiement | ❌ savoir nommer | — |

**Règle (source : [hermes.admin.ch — Modules](https://www.hermes.admin.ch/fr/gestion-de-projet/modules.html), Digital First) :** 4 modules sont obligatoires dans tout projet HERMES :
- **Pilotage du projet**
- **Conduite du projet**
- **Bases du projet**
- **Organisation du déploiement**

## Les 5 scénarios standard (à savoir énumérer ; 2 sont approfondis)

### Scénarios à maîtriser à fond (Obj 2 — 20 %)

**Source officielle des modules par scénario :** aperçus officiels « Aperçu des scénarios » de la Chancellerie fédérale (cf. fig. 18 et 19, manuel p. 29, et PDFs d'aperçu HERMES 2022).

#### 1. Développement de la prestation/du produit (fig. 18, p. 29)

Champ d'application : créer une **nouvelle** prestation/un nouveau produit.

Modules actifs (**6 modules**) :
- Pilotage du projet
- Conduite du projet
- Bases du projet
- Organisation
- Produit
- Organisation du déploiement

(**Achat est ABSENT** dans l'aperçu officiel — la création se fait typiquement in-house.)

#### 2. Adaptation de la prestation/du produit (fig. 19, p. 29)

Champ d'application : **modifier** une prestation/un produit existant.

Modules actifs (**7 modules**) :
- Pilotage du projet
- Conduite du projet
- Bases du projet
- **Achat** (en Conception — pour acheter composants/services externes nécessaires à l'adaptation)
- Organisation
- Produit
- Organisation du déploiement

🪤 **Distinction clé** (contre-intuitive) : Développement = nouveau, **PAS d'Achat**. Adaptation = modification, **avec Achat**. C'est l'inverse de l'intuition courante. Ne pas confondre.

### Scénarios à savoir nommer uniquement (Obj 1.7)

3. **Développement IT** (fig. 20, p. 30) — créer un nouveau système IT
4. **Adaptation IT** (fig. 21, p. 31) — modifier un système IT
5. **Adaptation de l'organisation** (fig. 22, p. 32) — adapter la structure organisationnelle

Pour ces 3 scénarios : ne PAS générer de questions sur les modules détaillés ou les rôles spécifiques.

## Adaptation des scénarios (Obj 1.7)

- **Dimensionnement** : ajuster la taille du scénario (combien de tâches/résultats appliquer).
- **Découpage** : réorganiser les tâches/résultats dans des phases différentes.
- Effets possibles : nouveaux résultats/tâches/modules/rôles, adaptés ou supprimés.

## Modèle de phases

### Phases (6 au total)

| Phase | Approche | Description |
|-------|----------|-------------|
| **Initialisation** | Toujours | Cadre le projet, valide la faisabilité, prépare le mandat d'exécution |
| **Conception** | Classique | Spécifie en détail la solution |
| **Réalisation** | Classique | Réalise et teste la solution |
| **Déploiement** | Classique | Met en service la solution |
| **Mise en œuvre** | Agile | Combine conception/réalisation/déploiement en releases itératifs |
| **Clôture** | Toujours | Bilan, transfert à l'organisation permanente |

**Approche classique :** Initialisation → Conception → Réalisation → Déploiement → Clôture (5 phases)
**Approche agile :** Initialisation → Mise en œuvre → Clôture (3 phases)

### Jalons = Quality Gates

Les jalons marquent :
- début/fin de phase
- libération d'un release (en agile)

Tous les jalons sont des résultats de type **« état »** (pas des documents).

Chaque jalon est attribué à la *Liste des décisions de Pilotage* ou *