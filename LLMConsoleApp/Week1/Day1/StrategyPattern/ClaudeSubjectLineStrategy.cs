using Anthropic;
using Anthropic.Models.Messages;

namespace LLMConsoleApp.Week1.Day1.StrategyPattern
{
    public class ClaudeSubjectLineStrategy : ISubjectLineStrategy
    {
        private readonly AnthropicClient _client;
        private const string SystemPrompt =
            "You are an assistant that reads the contents of an email and suggests a short, " +
            "clear, professional subject line for it. Respond with only the subject line, nothing else.";

        public ClaudeSubjectLineStrategy()
        {
            _client = new AnthropicClient(); // reads ANTHROPIC_API_KEY automatically
        }

        public async Task<string> GenerateAsync(string emailText)
        {
            var message = await _client.Messages.Create(new MessageCreateParams
            {
                Model = Model.ClaudeSonnet5,
                MaxTokens = 1000,
                System = SystemPrompt,
                Messages =
                [
                    new() { Role = Role.User, Content = emailText }
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
