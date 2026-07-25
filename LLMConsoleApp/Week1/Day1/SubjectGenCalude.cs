using Anthropic;
using Anthropic.Models.Messages;

namespace LLMConsoleApp.Week1.Day1
{
    public static class SubjectGenClaude
    {
        private const string SystemPrompt =
            "You are an assistant that reads the contents of an email and suggests a short, " +
            "clear, professional subject line for it. Respond with only the subject line, nothing else.";

        public static async Task<string> RunAsync(string emailText)
        {
            AnthropicClient client = new();  // reads ANTHROPIC_API_KEY automatically

            MessageCreateParams parameters = new()
            {                
                Model = Model.ClaudeSonnet5,
                MaxTokens = 1000,
                System = SystemPrompt,
                Messages = [ new() { Role = Role.User, Content = emailText }]
            };

            var message = await client.Messages.Create(parameters);

            foreach (var block in message.Content)
            {
                if (block.TryPickText(out var textBlock))
                {
                    return textBlock.Text;
                }
            }

            return string.Empty; // no text block found (shouldn't normally happen for this prompt)

        }
    }
}
