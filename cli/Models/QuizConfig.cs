namespace HermesQuizCli.Models;

public sealed record QuizConfig(
    int Count = 40,
    string? ObjectifFilter = null,
    string? TopicFilter = null,
    IReadOnlyList<string>? TopicGroup = null,
    string? TopicGroupLabel = null,
    bool MockMode = false,
    int? Seed = null,
    bool ShowExplanationOnCorrect = true,
    bool CountExplicit = false);
