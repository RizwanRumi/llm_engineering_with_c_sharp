using Anthropic;
using Anthropic.Models.Messages;

namespace LLMConsoleApp.Week1.Day1.StrategyPattern
{
    public class ClaudeSubjectLineStrategy : ISubjectLineStrategy
    {
        private readonly AnthropicClient _client;
        
        public ClaudeSubjectLineStrategy()
        {
            _client = new AnthropicClient(); // reads ANTHROPIC_API_KEY automatically
        }

        public async Task<string> GenerateAsync(string userPrompt, string systemPrompt)
        {
            var message = await _client.Messages.Create(new MessageCreateParams
            {
                Model = Model.ClaudeSonnet5,
                MaxTokens = 1000,
                System = systemPrompt,
                Messages =
                [
                    new() { Role = Role.User, Content = userPrompt }
                ],
            });

            foreach (var block in message.Content)
            {
                if (block.TryPickText(out var textBlock))
                {
                    return textBlock.Text;
                }
            }

            return string.Empty;
        }
    }
}
