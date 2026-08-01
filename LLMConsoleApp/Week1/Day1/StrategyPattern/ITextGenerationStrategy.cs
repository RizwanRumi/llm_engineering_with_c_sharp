namespace LLMConsoleApp.Week1.Day1.StrategyPattern
{
    public interface ITextGenerationStrategy
    {
        Task<string> GenerateAsync(string meetingNotes, string systemNotes);
    }
}
