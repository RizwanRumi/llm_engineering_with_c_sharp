namespace LLMConsoleApp.Week1.Day1.StrategyPattern
{
    public interface ISubjectLineStrategy
    {
        Task<string> GenerateAsync(string meetingNotes, string systemNotes);
    }
}
