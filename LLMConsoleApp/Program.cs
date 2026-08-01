using LLMConsoleApp.Week1.Day1;
using LLMConsoleApp.Week1.Day1.StrategyPattern;

namespace LLMConsoleApp
{    
    public class Program
    {
        private static async Task Main(string[] args)
        {
            string openAiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? throw new InvalidOperationException("OPENAI_API_KEY not found.");
            string anthropicKey = Environment.GetEnvironmentVariable("ANTHROPIC_API_KEY") ?? throw new InvalidOperationException("ANTHROPIC_API_KEY not found.");
            //Install Ollama and pull a model first, you can set any api-key.
            string ollamaKey = "ollama";

            //// <summary>
            /// Solution for Week 1: Day 1: single provider exercise and Strategy Pattern exercise. 
            /// This program demonstrates the use of the Strategy Pattern to generate 
            /// meeting notes summary for a team using different AI providers (OpenAI and Anthropic Claude).
            /// The user can select a provider, and the program will generate a summary meeting notes.
            /// Solution for Week 1: Day 2: Install ollama and add example with other providers.
            ///</summary>

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

            Console.WriteLine("--- OpenAI ---");
            string summaryOpenAI = SubjectGenOpenAI.Run(openAiKey, meetingNotes, systemPrompt);
            Console.WriteLine(summaryOpenAI);

            Console.WriteLine("\n--- Claude ---");
            string summaryClaude = await SubjectGenClaude.RunAsync(meetingNotes, systemPrompt);
            Console.WriteLine(summaryClaude);

            Console.WriteLine("\n--- Ollama ---");
            string summaryOllama = SubjectGenOllamaAI.Run(meetingNotes, systemPrompt, ollamaKey);
            Console.WriteLine(summaryOllama);

            // Strategy Pattern exercise

            //Console.WriteLine("Select a provider:");
            //Console.WriteLine("  1. OpenAI");
            //Console.WriteLine("  2. Anthropic (Claude)");
            //Console.Write("Enter choice (1 or 2): ");

            //string? choice = Console.ReadLine();

            //ISubjectLineStrategy? strategy = null;

            //while (strategy is null)
            //{                
            //    strategy = choice switch
            //    {
            //        "1" => new OpenAiSubjectLineStrategy(openAiKey),
            //        "2" => new ClaudeSubjectLineStrategy(),
            //        _ => null
            //    };

            //    if (strategy is null)
            //    {
            //        Console.WriteLine("Invalid choice, please enter 1 or 2.");
            //        Console.Write("Enter choice (1 or 2): ");
            //        choice = Console.ReadLine();
            //    }
            //}

            //var generator = new SubjectLineGenerator(strategy);
            //string subjectLine = await generator.Generate(emailText);

            //Console.WriteLine($"\nSuggested subject line:\n{subjectLine}");
        }
    }
}