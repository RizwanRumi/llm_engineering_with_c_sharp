using Anthropic;
using Anthropic.Models.Messages;

namespace LLMConsoleApp.Week1.Day1
{
    public static class TextGenClaude
    {
        public static async Task<string> RunAsync(string userPrompt, string systemPrompt)
        {
            AnthropicClient client = new();  // reads ANTHROPIC_API_KEY automatically

            MessageCreateParams parameters = new()
            {                
                Model = Model.ClaudeSonnet5,
                MaxTokens = 1000,
                System = systemPrompt,
                Messages = [ new() { Role = Role.User, Content = userPrompt }]
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
