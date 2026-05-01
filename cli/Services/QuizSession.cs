using HermesQuizCli.Models;
using Spectre.Console;

namespace HermesQuizCli.Services;

/// <summary>
/// Pilote une session de quiz interactive : présente chaque question,
/// collecte la réponse, donne la correction, calcule le score final.
/// </summary>
public sealed class QuizSession
{
    private readonly IReadOnlyList<Question> _questions;
    private readonly QuizConfig _config;
    private readonly Dictionary<string, (int Correct, int Total)> _byObjectif = new();
    private readonly Dictionary<string, (int Correct, int Total)> _byTopic = new();
    private readonly List<Question> _missedQuestions = new();
    private int _correct;
    private int _answered;

    public QuizSession(IReadOnlyList<Question> questions, QuizConfig config)
    {
        _questions = questions;
        _config = config;
    }

    public void Run()
    {
        AnsiConsole.Write(new FigletText("HERMES Quiz").Color(Color.Cyan1));
        AnsiConsole.MarkupLine($"[grey]Banque chargée : {_questions.Count} questions[/]");
        AnsiConsole.MarkupLine("[grey]Tape la lettre de ta réponse, ou 's' pour stopper, 'q' pour passer.[/]");
        AnsiConsole.WriteLine();

        for (int i = 0; i < _questions.Count; i++)
        {
            var question = _questions[i];
            if (!AskOne(question, i + 1, _questions.Count))
            {
                break; // user stopped
            }
        }

        ShowSummary();
    }

    private bool AskOne(Question q, int index, int total)
    {
        AnsiConsole.Write(new Rule($"[yellow]Question {index}/{total}[/]").LeftJustified());
        AnsiConsole.MarkupLine(
            $"[grey]Obj {q.Objectif} · {q.Topic} · {q.Type} · {q.Taxonomie}[/]");
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine($"[bold]{Markup.Escape(q.Stem)}[/]");
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine($"  [bold]a)[/] {Markup.Escape(q.OptionA)}");
        AnsiConsole.MarkupLine($"  [bold]b)[/] {Markup.Escape(q.OptionB)}");
        AnsiConsole.MarkupLine($"  [bold]c)[/] {Markup.Escape(q.OptionC)}");
        AnsiConsole.MarkupLine($"  [bold]d)[/] {Markup.Escape(q.OptionD)}");
        AnsiConsole.WriteLine();

        var answer = ReadAnswer();

        if (answer == "s")
        {
            AnsiConsole.MarkupLine("[grey]Quiz interrompu sur demande.[/]");
            AnsiConsole.WriteLine();
            return false;
        }

        var objStat = _byObjectif.GetValueOrDefault(q.Objectif);
        var topicStat = _byTopic.GetValueOrDefault(q.Topic);

        if (answer == "q")
        {
            AnsiConsole.MarkupLine(
                $"[grey]Question sautée. Bonne réponse : [bold]{q.Answer.ToUpper()}[/] — " +
                $"{Markup.Escape(q.GetOption(q.Answer))}[/]");
            AnsiConsole.MarkupLine($"[grey italic]{Markup.Escape(q.Explanation)} (manuel p. {q.Page})[/]");
            _byObjectif[q.Objectif] = (objStat.Correct, objStat.Total + 1);
            _byTopic[q.Topic] = (topicStat.Correct, topicStat.Total + 1);
            _missedQuestions.Add(q);
            _answered++;
        }
        else if (string.Equals(answer, q.Answer, StringComparison.OrdinalIgnoreCase))
        {
            _correct++;
            _answered++;
            AnsiConsole.MarkupLine("[green bold]✓ Correct ![/]");
            if (_config.ShowExplanationOnCorrect)
            {
                AnsiConsole.MarkupLine(
                    $"[grey italic]{Markup.Escape(q.Explanation)} (manuel p. {q.Page})[/]");
            }
            _byObjectif[q.Objectif] = (objStat.Correct + 1, objStat.Total + 1);
            _byTopic[q.Topic] = (topicStat.Correct + 1, topicStat.Total + 1);
        }
        else
        {
            _answered++;
            AnsiConsole.MarkupLine(
                $"[red bold]✗ Faux.[/] La bonne réponse était [bold]{q.Answer.ToUpper()}[/] : " +
                $"[italic]{Markup.Escape(q.GetOption(q.Answer))}[/]");
            AnsiConsole.MarkupLine(
                $"[grey italic]{Markup.Escape(q.Explanation)} (manuel p. {q.Page})[/]");
            _byObjectif[q.Objectif] = (objStat.Correct, objStat.Total + 1);
            _byTopic[q.Topic] = (topicStat.Correct, topicStat.Total + 1);
            _missedQuestions.Add(q);
        }

        var pct = _answered == 0 ? 0 : 100 * _correct / _answered;
        AnsiConsole.MarkupLine($"[grey]Score courant : {_correct}/{_answered} ({pct} %)[/]");
        AnsiConsole.WriteLine();
        return true;
    }

    private static string ReadAnswer()
    {
        while (true)
        {
            var input = AnsiConsole.Ask<string>("[cyan]Ta réponse[/] :")
                .Trim()
                .ToLowerInvariant();

            // Accept "a", "b", "c", "d", or full forms like "la a", "réponse b"
            var lastChar = input.LastOrDefault(c => c is 'a' or 'b' or 'c' or 'd' or 's' or 'q');
            if (lastChar != default)
            {
                return lastChar.ToString();
            }

            AnsiConsole.MarkupLine(
                "[red]Réponse invalide.[/] [grey]Tape a, b, c, d, 's' pour stop, ou 'q' pour passer.[/]");
        }
    }

    private void ShowSummary()
    {
        if (_answered == 0)
        {
            AnsiConsole.MarkupLine("[grey]Aucune question répondue.[/]");
            return;
        }

        AnsiConsole.Write(new Rule("[yellow]Résultat final[/]").LeftJustified());

        var pct = 100 * _correct / _answered;
        var verdict = pct switch
        {
            >= 80 => "[green]Excellent[/]",
            >= 70 => "[green]Bon niveau[/]",
            >= 60 => "[yellow]Niveau acceptable, à consolider[/]",
            _ => "[red]Reprendre la matière[/]"
        };

        AnsiConsole.MarkupLine($"[bold]Score : {_correct}/{_answered} ({pct} %)[/] — {verdict}");
        AnsiConsole.WriteLine();

        // === Tableau par objectif ===
        var objTable = new Table()
            .Border(TableBorder.Rounded)
            .Title("[bold]Score par objectif[/]")
            .AddColumn("Objectif")
            .AddColumn(new TableColumn("Score").RightAligned())
            .AddColumn(new TableColumn("%").RightAligned())
            .AddColumn("Statut");

        foreach (var kvp in _byObjectif.OrderBy(k => k.Key))
        {
            var (c, t) = kvp.Value;
            var p = t == 0 ? 0 : 100 * c / t;
            var status = p switch
            {
                >= 80 => "[green]Maîtrisé[/]",
                >= 60 => "[yellow]À consolider[/]",
                _ => "[red]Faible[/]"
            };

            objTable.AddRow(
                $"Obj {kvp.Key}",
                $"{c}/{t}",
                $"{p} %",
                status);
        }

        AnsiCons