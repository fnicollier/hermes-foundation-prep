using System.Reflection;
using System.Text.Json;
using HermesQuizCli.Models;

namespace HermesQuizCli.Services;

/// <summary>
/// Charge la banque de questions depuis la ressource embarquée et tire un sous-ensemble
/// selon une configuration (random, filtré, ou mock examen).
/// </summary>
public sealed class QuestionBank
{
    private readonly IReadOnlyList<Question> _questions;

    public QuestionBank()
    {
        var assembly = Assembly.GetExecutingAssembly();
        const string resourceName = "HermesQuizCli.Data.questions.json";

        using var stream = assembly.GetManifestResourceStream(resourceName)
            ?? throw new InvalidOperationException(
                $"Ressource embarquée introuvable : {resourceName}. " +
                $"Ressources disponibles : {string.Join(", ", assembly.GetManifestResourceNames())}");

        var loaded = JsonSerializer.Deserialize<List<Question>>(stream)
            ?? throw new InvalidOperationException("Échec du parsing de questions.json.");

        _questions = loaded;
    }

    public int TotalCount => _questions.Count;

    public IReadOnlyDictionary<string, int> CountByObjectif() =>
        _questions
            .GroupBy(q => q.Objectif.Split('.')[0])
            .ToDictionary(g => g.Key, g => g.Count());

    public IReadOnlyList<Question> Pick(QuizConfig config)
    {
        var rng = config.Seed.HasValue ? new Random(config.Seed.Value) : Random.Shared;

        IEnumerable<Question> pool = _questions;

        if (!string.IsNullOrEmpty(config.ObjectifFilter))
        {
            pool = pool.Where(q =>
                q.Objectif.Equals(config.ObjectifFilter, StringComparison.OrdinalIgnoreCase) ||
                q.Objectif.StartsWith(config.ObjectifFilter + ".", StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(config.TopicFilter))
        {
            pool = pool.Where(q =>
                q.Topic.Contains(config.TopicFilter, StringComparison.OrdinalIgnoreCase));
        }

        var filtered = pool.ToList();

        if (config.MockMode)
        {
            return BuildMockExam(filtered, rng);
        }

        var shuffled = filtered.OrderBy(_ => rng.Next()).ToList();
        var take = Math.Min(config.Count, shuffled.Count);
        return shuffled.Take(take).ToList();
    }

    /// <summary>
    /// Construit un examen blanc de 40 questions avec la distribution officielle :
    /// Obj 1 = 12, Obj 2 = 8, Obj 3 = 10, Obj 4 = 10.
    /// </summary>
    private static IReadOnlyList<Question> BuildMockExam(List<Question> pool, Random rng)
    {
        var distribution = new (string ObjPrefix, int Count)[]
        {
            ("1", 12),
            ("2", 8),
            ("3", 10),
            ("4", 10)
        };

        var picked = new List<Question>();
        foreach (var (prefix, count) in distribution)
        {
            var fromObj = pool
                .Where(q => q.Objectif.StartsWith(prefix + ".") || q.Objectif == prefix)
                .OrderBy(_ => rng.Next())
                .Take(count)
                .ToList();

            if (fromObj.Count < count)
            {
                Console.Error.WriteLine(
                    $"Avertissement : seulement {fromObj.Count}/{count} questions disponibles pour Obj {prefix}.");
            }

            picked.AddRange(fromObj);
        }

        return picked.OrderBy(_ => rng.Next()).ToList();
    }
}
