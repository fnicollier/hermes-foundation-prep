namespace HermesQuizCli.Models;

public sealed record QuizConfig(
    int Count = 10,
    string? ObjectifFilter = null,
    string? TopicFilter = null,
    bool MockMode = false,
    int? Seed = null,
    bool ShowExplanationOnCorrect = true,
  