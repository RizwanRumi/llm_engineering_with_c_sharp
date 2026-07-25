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

            //// <summary>
            /// Solution for Week 1: Day 1: single provider exercise and Strategy Pattern exercise. 
            /// This program demonstrates the use of the Strategy Pattern to generate 
            /// subject lines for emails using different AI providers (OpenAI and Anthropic Claude).
            /// The user can select a provider, and the program will generate a suggested subject 
            /// line based on the provided email text.
            ///</summary>

            string emailText = """
                Hi team,

                Just a heads up that the weekly SWD meeting originally scheduled for Thursday
                at 2pm has been moved to Wednesday at 9:15am due to a scheduling conflict on
                manager end.

                Thanks,
                Rizwan
                """;

            //// single provider exercise

            //Console.WriteLine("--- OpenAI ---");
            //Console.WriteLine(SubjectGenOpenAI.Run(openAiKey, emailText));

            //Console.WriteLine("\n--- Claude ---");           
            //string subjectLine = await SubjectGenClaude.RunAsync(emailText);
            //Console.WriteLine(subjectLine);

            // Strategy Pattern exercise

            Console.WriteLine("Select a provider:");
            Console.WriteLine("  1. OpenAI");
            Console.WriteLine("  2. Anthropic (Claude)");
            Console.Write("Enter choice (1 or 2): ");

            string? choice = Console.ReadLine();

            ISubjectLineStrategy? strategy = null;

            while (strategy is null)
            {                
                strategy = choice switch
                {
                    "1" => new OpenAiSubjectLineStrategy(openAiKey),
                    "2" => new ClaudeSubjectLineStrategy(),
                    _ => null
                };

                if (strategy is null)
                {
                    Console.WriteLine("Invalid choice, please enter 1 or 2.");
                    Console.Write("Enter choice (1 or 2): ");
                    choice = Console.ReadLine();
                }
            }

            var generator = new SubjectLineGenerator(strategy);
            string subjectLine = await generator.Generate(emailText);

            Console.WriteLine($"\nSuggested subject line:\n{subjectLine}");
        }
    }
}