namespace LLMConsoleApp.Week1.Day1.StrategyPattern
{
    // Context class for the Strategy pattern, which uses an ISubjectLineStrategy to generate subject lines.
    public class SubjectLineGenerator
    {
        private readonly ISubjectLineStrategy _strategy;

        public SubjectLineGenerator(ISubjectLineStrategy strategy)
        {
            _strategy = strategy;
        }

        public Task<string> Generate(string meetingNotes, string systemNotes)
            => _strategy.GenerateAsync(meetingNotes, systemNotes);
    }
}
