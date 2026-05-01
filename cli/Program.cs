using HermesQuizCli.Models;
using HermesQuizCli.Services;
using Spectre.Console;

try
{
    // Console.OutputEncoding for proper UTF-8 (accents, é, etc.) on Windows.
    Console.OutputEncoding = System.Text.Encoding.UTF8;

    var config = ParseArgs(args);
    var bank = new QuestionBank();

    // If no count was explicitly provided (and not in mock mode), prompt the user.
    if (!config.MockMode && !config.CountExplicit)
    {
        var count = PromptForCount(bank, config);
        config = config with { Count = count, CountExplicit = true };
    }

    if (!config.MockMode && config.Count > bank.TotalCount)
    {
        AnsiConsole.MarkupLine(
            $"[yellow]La banque contient {bank.TotalCount} questions ; {config.Count} sera tronqué à {bank.TotalCount}.[/]");
    }

    var picked = bank.Pick(config);

    if (picked.Count == 0)
    {
        AnsiConsole.MarkupLine("[red]Aucune question ne correspond aux filtres.[/]");
        return 1;
    }

    var session = new QuizSession(picked, config);
    session.Run();
    return 0;
}
catch (Exception ex)
{
    AnsiConsole.MarkupLine($"[red]Erreur fatale :[/] {ex.Message}");
    AnsiConsole.WriteException(ex, ExceptionFormats.ShortenEverything);
    return 2;
}

static int PromptForCount(QuestionBank bank, QuizConfig config)
{
    // Determine the relevant pool size for the user's filters.
    var availablePool = bank.Pick(config with { Count = int.MaxValue, CountExplicit = true }).Count;

    var contextLabel = (config.ObjectifFilter, config.TopicFilter) switch
    {
        (string o, null)    => $" sur Obj {o}",
        (null, string t)    => $" sur le topic « {t} »",
        (string o, string t) => $" sur Obj {o} / topic « {t} »",
        _                   => ""
    };

    AnsiConsole.MarkupLine(
        $"[grey]Banque chargée : {bank.TotalCount} questions au total ; {availablePool} disponible(s){contextLabel}.[/]");

    var defaultCount = Math.Min(10, availablePool);

    var count = AnsiConsole.Prompt(
        new TextPrompt<int>($"[cyan]Combien de questions ?[/] [grey](1 à {availablePool}, défaut {defaultCount})[/]")
            .DefaultValue(defaultCount)
            .ShowDefaultValue(false)
            .Validate(n =>
                n switch
                {
                    < 1 => ValidationResult.Error("[red]Au moins 1 question.[/]"),
                    _ when n > availablePool => ValidationResult.Error($"[red]Maximum disponible : {availablePool}.[/]"),
                    _ => ValidationResult.Success()
                }));

    AnsiConsole.WriteLine();
    return count;
}

static QuizConfig ParseArgs(string[] args)
{
    int count = 10;
    bool countExplicit = false;
    string? obj = null;
    string? topic = null;
    bool mock = false;
    int? seed = null;
    bool hideExplanationOnCorrect = false;

    for (int i = 0; i < args.Length; i++)
    {
        switch (args[i])
        {
            case "--count" or "-c" when i + 1 < args.Length:
                count = int.Parse(args[++i]);
                countExplicit = true;
                break;

            case "--obj" or "-o" when i + 1 < args.Length:
                obj = args[++i];
                break;

            case "--topic" or "-t" when i + 1 < args.Length:
                topic = args[++i];
                break;

            case "--mock" or "-m":
                mock = true;
                break;

            case "--seed" or "-s" when i + 1 < args.Length:
                seed = int.Parse(args[++i]);
                break;

            case "--terse":
                hideExplanationOnCorrect = true;
                break;

            case "--help" or "-h" or "-?":
                PrintHelp();
                Environment.Exit(0);
                break;

            default:
                // Bare number → count (e.g. "hermes-quiz 50")
                if (int.TryParse(args[i], out var n))
                {
                    count = n;
                    countExplicit = true;
                }
                else
                {
                    AnsiConsole.MarkupLine($"[red]Argument inconnu :[/] {args[i]}");
                    PrintHelp();
                    Environment.Exit(1);
                }
                break;
        }
    }

    return new QuizConfig(
        Count: count,
        ObjectifFilter: obj,
        TopicFilter: topic,
        MockMode: mock,
        Seed: seed,
        ShowExplanationOnCorrect: !hideExplanationOnCorrect,
        CountExplicit: countExplicit);
}

static void PrintHelp()
{
    Console.WriteLine("""
        HERMES Foundation Quiz CLI

        Usage : hermes-quiz [options]
                dotnet run -- [options]

        Options :
          -c, --count N        Nombre de questions à tirer (sinon : prompt interactif)
          -o, --obj X[.Y]      Filtrer par objectif (ex. : --obj 4 ou --obj 1.3)
          -t, --topic NAME     Filtrer par topic (ex. : --topic Phases)
          -m, --mock           Examen blanc 40 questions (distribution officielle 12/8/10/10)
          -s, --seed N         Graine RNG pour reproductibilité
              --terse          Ne pas afficher l'explication quand la réponse est correcte
          -h, --help           Affiche cette aide

        Exemples :
          hermes-quiz                       # demande combien de questions au démarrage
          hermes-quiz 30                    # 30 questions, sans prompt
          hermes-quiz --obj 4               # demande combien, sur l'Obj 4 uniquement
          hermes-quiz --obj 1.3 -c 10       # 10 questions sur Obj 1.3 (Phases), sans prompt
          hermes-quiz --topic Rôles         # demande combien, filtré par topic
          hermes-quiz --mock                # examen blanc 40 Q (pas de prompt)
          hermes-quiz --mock --seed 42      # mock reproductible (utile pour comparer 2 sessions)

        Pendant le quiz :
          a / b / c / d   Réponse à la question
          q               Passer cette question
          s               Stopper le quiz et voir le score partiel

        Source : Manuel HERMES 2022 (Chancellerie fédérale) + Objectifs didactiques FND FR.
        Les questions sont générées dans le style TÜV SÜD Akademie mais ne sont PAS officielles.
        """);
}
