# HermesQuizCli — Quiz HERMES 2022 Foundation en .NET

CLI **.NET 10 (LTS)** pour préparer la certification **HERMES 2022 Foundation**. 200 questions originales calibrées sur les *Objectifs didactiques* officiels (Chancellerie fédérale, Édition décembre 2025) et le style TÜV SÜD Akademie.

## Installation et exécution

```bash
# Restaurer + lancer (200 questions aléatoires par défaut)
dotnet run

# Ou compiler en exécutable autonome (mono-fichier)
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true
# binaire produit : bin/Release/net10.0/win-x64/publish/hermes-quiz.exe
```

> Nécessite **.NET 10 SDK** (LTS, supportée jusqu'à novembre 2028 — [download](https://dotnet.microsoft.com/download/dotnet/10.0)).

## Usage

```text
hermes-quiz [options]

Options
  -c, --count N        Nombre de questions à tirer (sinon : prompt interactif)
  -o, --obj X[.Y]      Filtrer par objectif (ex. : --obj 4 ou --obj 1.3)
  -t, --topic NAME     Filtrer par topic (ex. : --topic Phases)
  -m, --mock           Examen blanc 40 questions (distribution officielle 12/8/10/10)
  -s, --seed N         Graine RNG pour reproductibilité
      --terse          Cacher l'explication quand la réponse est correcte
  -h, --help           Affiche l'aide
```

### Exemples

```bash
hermes-quiz                         # demande combien de questions au démarrage
hermes-quiz 30                      # 30 Q aléatoires, sans prompt
hermes-quiz --obj 4                 # demande combien, filtré sur Obj 4 (rôles)
hermes-quiz --obj 1.3 -c 10         # 10 Q sur Obj 1.3 (Phases), sans prompt
hermes-quiz --topic Rôles           # demande combien, filtré par topic
hermes-quiz --mock                  # Examen blanc 40 Q (pas de prompt)
hermes-quiz --mock --seed 42        # Mock reproductible
```

> **Mode interactif par défaut :** si aucun nombre n'est donné (et pas en mode `--mock`), le CLI affiche
> la taille de la banque + nombre disponible selon les filtres, puis demande combien de questions tirer
> (validation : 1 à N, défaut suggéré = 10).

### Pendant le quiz

| Touche | Action |
|--------|--------|
| `a` / `b` / `c` / `d` | Réponse à la question |
| `q` | Passer cette question |
| `s` | Stopper le quiz et voir le score partiel |

## Banque de questions

**200 questions originales** distribuées selon la pondération officielle :

| Objectif | Q | Poids cible | Couvre |
|----------|--:|------------:|--------|
| Obj 1 — Bases + vue d'ensemble | 62 | 30 % | Méthode, Phases & jalons, Résultats/Tâches, Modules, Rôles, Scénarios, Application |
| Obj 2 — 2 scénarios standard | 40 | 20 % | Champ d'application, modules par scénario, organisation par scénario, listes de contrôle |
| Obj 3 — 7 modules approfondis | 50 | 25 % | Pilotage, Conduite, Bases, Achat, Organisation, Produit, Org. déploiement |
| Obj 4 — Organisation de projet | 48 | 25 % | Org. classique/agile, niveaux hiérarchiques, principes d'attribution, descriptions de rôles |

## Fonctionnalités CLI

- **Mode interactif** : une question à la fois, correction immédiate avec page du manuel.
- **Score continu** + récap par objectif en fin de session.
- **Identification automatique des points faibles** (objectif < 60 %) avec recommandation de filtre.
- **Mode mock** : reproduit la distribution officielle de l'examen (12/8/10/10).
- **Reproductibilité** via `--seed` (utile pour comparer deux sessions ou debug).
- **UTF-8 propre** sur Windows/Linux/macOS (accents français corrects).
- **Embedded resource** : la banque de 200 questions est embarquée dans l'exécutable — un seul binaire à distribuer.

## Architecture

```
HermesQuizCli/
├── HermesQuizCli.csproj      .NET 10 (LTS), Spectre.Console 0.55.0
├── Program.cs                Entry point + parsing CLI
├── Models/
│   ├── Question.cs           Record sealed avec annotations System.Text.Json
│   └── QuizConfig.cs         Config record (count, filters, mode)
├── Services/
│   ├── QuestionBank.cs       Charge les questions + algorithmes de tirage
│   └── QuizSession.cs        Pilote la session interactive (Spectre.Console)
└── Data/
    └── questions.json         200 questions, embedded resource
```

## Étendre la banque

Le format JSON est documenté dans `Models/Question.cs`. Pour ajouter une question, éditer `Data/questions.json` :

```json
{
  "id": "Q201",
  "obj": "1.3",
  "topic": "Phases",
  "type": "A(pos)",
  "tax": "Moyen",
  "stem": "Question…",
  "a": "Choix A",
  "b": "Choix B",
  "c": "Choix C",
  "d": "Choix D",
  "ans": "b",
  "exp": "Explication courte citant la source.",
  "page": 18
}
```

Recompiler avec `dotnet build` — la nouvelle banque est embarquée automatiquement.

## Source de vérité

- Manuel HERMES 2022 (Chancellerie fédérale, 252 p.)
- Objectifs didactiques Foundation, Édition décembre 2025
- Style des questions TÜV SÜD Akademie GmbH (organisme certificateur)

## Limites & disclaime