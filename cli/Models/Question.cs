using System.Text.Json.Serialization;

namespace HermesQuizCli.Models;

/// <summary>
/// Une question de quiz HERMES Foundation. Tous les champs sont sérialisés en JSON
/// avec des noms courts pour minimiser la taille de la banque embarquée.
/// </summary>
public sealed record Question
{
    [JsonPropertyName("id")] public required string Id { get; init; }

    /// <summary>Objectif didactique testé : "1.3", "4.2", etc.</summary>
    [JsonPropertyName("obj")] public required string Objectif { get; init; }

    /// <summary>Topic libre : "Phases", "Rôles", "Modules", etc.</summary>
    [JsonPropertyName("topic")] public required string Topic { get; init; }

    /// <summary>"A(pos)" ou "A(neg)".</summary>
    [JsonPropertyName("type")] public required string Type { get; init; }

    /// <summary>"Facile", "Moyen" ou "Difficile" (Bloom).</summary>
    [JsonPropertyName("tax")] public required string Taxonomie { get; init; }

    [JsonPropertyName("stem")] public required string Stem { get; init; }
    [JsonPropertyName("a")] public required string OptionA { get; init; }
    [JsonPropertyName("b")] public required string OptionB { get; init; }
    [JsonPropertyName("c")] public required string OptionC { get; init; }
    [JsonPropertyName("d")] public required string OptionD { get; init; }

    /// <summary>Lettre minuscule de la bonne réponse : "a", "b", "c" ou "d".</summary>
    [JsonPropertyName("ans")] public required string Answer { get; init; }

    [JsonPropertyName("exp")] public required string Explanation { get; init; }

    /// <summary>Page du manuel HERMES (Édition 2022).</summary>
    [JsonPropertyName("page")] public int Page { get; init; }

    public string GetOption(string key) => key.ToLowerInvariant() switch
    {
        "a" => OptionA,
        "b" => OptionB,
        "c" => OptionC,
        "d" => OptionD,
        _ => throw new ArgumentException($"Choix invalide : {key}")
    };
}
