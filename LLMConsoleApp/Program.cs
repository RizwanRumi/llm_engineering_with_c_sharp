using LLMConsoleApp.Interfaces;
using LLMConsoleApp.Week1.Day1;
using LLMConsoleApp.Week1.Day1.StrategyPattern;

namespace LLMConsoleApp
{    
    public class Program
    {
        private static async Task Main(string[] args)
        {
            List<IExercise> exercises =
            [
                new Week1Day1Exercise(),
                new Week1Day2Exercise()
            ];

            Console.WriteLine("Select an exercise:");
            for (int i = 0; i < exercises.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {exercises[i].Name}");
            }

            Console.Write("Enter choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= exercises.Count)
            {
                await exercises[choice - 1].RunAsync();
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}