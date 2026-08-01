namespace LLMConsoleApp.Week1.Day1.StrategyPattern
{
    // Context class for the Strategy pattern, which uses an ITextGenerationStrategy to generate text.
    public class TextGenerator
    {
        private readonly ITextGenerationStrategy _strategy;

        public TextGenerator(ITextGenerationStrategy strategy)
        {
            _strategy = strategy;
        }

        public Task<string> Generate(string meetingNotes, string systemNotes)
            => _strategy.GenerateAsync(meetingNotes, systemNotes);
    }
}
