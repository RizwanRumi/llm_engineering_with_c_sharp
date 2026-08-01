using OpenAI.Chat;

namespace LLMConsoleApp.Week1.Day1.StrategyPattern
{
    public class OpenAiSubjectLineStrategy : ISubjectLineStrategy
    {
        private readonly ChatClient _client;
       
        public OpenAiSubjectLineStrategy(string apiKey, string model = "gpt-5.1")
        {
            _client = new ChatClient(model: model, apiKey: apiKey);
        }

        public Task<string> GenerateAsync(string userPrompt, string systemPrompt)
        {
            List<ChatMessage> messages =
            [
                new SystemChatMessage(systemPrompt),
                new UserChatMessage(userPrompt)
            ];

            ChatCompletion completion = _client.CompleteChat(messages);
            return Task.FromResult(completion.Content[0].Text);
        }
    }
}
