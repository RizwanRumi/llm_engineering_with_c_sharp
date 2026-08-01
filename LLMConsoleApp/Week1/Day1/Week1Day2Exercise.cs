using LLMConsoleApp.Interfaces;
using LLMConsoleApp.Week1.Day1.StrategyPattern;

namespace LLMConsoleApp.Week1.Day1
{
    internal class Week1Day2Exercise : IExercise
    {
        public string Name => "Week 1, Day 2 - include Ollama for Text Generation ( Single provider or Strategy Pattern example)";

        public async Task RunAsync()
        {
            string openAiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? throw new InvalidOperationException("OPENAI_API_KEY not found.");
            string anthropicKey = Environment.GetEnvironmentVariable("ANTHROPIC_API_KEY") ?? throw new InvalidOperationException("ANTHROPIC_API_KEY not found.");
            //Install Ollama and pull a model first, you can set any api-key.
            string ollamaKey = "ollama";
                       
            const string systemPrompt = """
                You are an assistant that turns raw, informal meeting notes into a clean,
                structured summary suitable for sharing with the team.

                Format your response in markdown with these sections:
                - **Key Decisions** (bullet points)
                - **Action Items** (bullet points, format: "Task — Owner — Due date if mentioned")
                - **Open Questions** (bullet points, only include if there are unresolved items)

                Keep it concise. Do not invent information that isn't in the notes.
                If a section has nothing relevant, omit that section entirely.
                """;

            string meetingNotes = """
                quick sync w/ design + eng
                - decided going w/ blue theme not the green one, everyone liked it more
                - sarah still needs to finalize the logo, said she'll have it by fri
                - mike raised concern about mobile load time, no one had an answer, need to follow up
                - launch date pushed to next month, marketing needs more time
                - john to update the roadmap doc with new date
                """;

            //// single provider exercise

            //Console.WriteLine("--- OpenAI ---");
            //string summaryOpenAI = TextGenOpenAI.Run(openAiKey, meetingNotes, systemPrompt);
            //Console.WriteLine(summaryOpenAI);

            //Console.WriteLine("\n--- Claude ---");
            //string summaryClaude = await TextGenClaude.RunAsync(meetingNotes, systemPrompt);
            //Console.WriteLine(summaryClaude);

            //Console.WriteLine("\n--- Ollama ---");
            //string summaryOllama = TextGenOllama.Run(meetingNotes, systemPrompt, ollamaKey);
            //Console.WriteLine(summaryOllama);

            // Strategy Pattern exercise

            Console.WriteLine("Select a provider:");
            Console.WriteLine("  1. OpenAI");
            Console.WriteLine("  2. Anthropic (Claude)");
            Console.WriteLine("  3. Ollama");
            Console.Write("Enter a specific choice: ");

            string? choice = Console.ReadLine();

            ITextGenerationStrategy? strategy = null;

            while (strategy is null)
            {
                strategy = choice switch
                {
                    "1" => new OpenAiTextGenerationStrategy(openAiKey),
                    "2" => new ClaudeTextGenerationStrategy(),
                    "3" => new OllamaTextGenerationStrategy(ollamaKey),
                    _ => null
                };

                if (strategy is null)
                {
                    Console.WriteLine("Invalid choice, please enter an option.");
                    Console.Write("Enter a specific choice: ");
                    choice = Console.ReadLine();
                }
            }

            var generator = new TextGenerator(strategy);
            string summary = await generator.Generate(meetingNotes, systemPrompt);

            Console.WriteLine($"\nSummary :\n{summary}");
        }
    }
}
