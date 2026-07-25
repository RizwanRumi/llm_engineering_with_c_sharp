using OpenAI.Chat;

namespace LLMConsoleApp.Week1.Day1.StrategyPattern
{
    public class OpenAiSubjectLineStrategy : ISubjectLineStrategy
    {
        private readonly ChatClient _client;
        private const string SystemPrompt =
            "You are an assistant that reads the contents of an email and suggests a short, " +
            "clear, professional subject line for it. Respond with only the subject line, nothing else.";

        public OpenAiSubjectLineStrategy(string apiKey, string model = "gpt-5.1")
        {
            _client = new ChatClient(model: model, apiKey: apiKey);
        }

        public Task<string> GenerateAsync(string emailText)
        {
            List<ChatMessage> messages =
            [
                new SystemChatMessage(SystemPrompt),
                new UserChatMessage(emailText)
            ];

            ChatCompletion completion = _client.CompleteChat(messages);
            return Task.FromResult(completion.Content[0].Text);
        }
    }
}
