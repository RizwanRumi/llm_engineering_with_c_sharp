using Anthropic.Models.Messages;
using OpenAI;
using OpenAI.Chat;
using System.ClientModel;
using static System.Net.Mime.MediaTypeNames;

namespace LLMConsoleApp.Week1.Day1.StrategyPattern
{
    public class OllamaSubjectLineStrategy : ISubjectLineStrategy
    {
        private readonly ChatClient _client;

        public OllamaSubjectLineStrategy(string apikey)
        {
            var options = new OpenAIClientOptions
            {
                Endpoint = new Uri("http://localhost:11434/v1")
            };

            // Ollama doesn't check the API key, but the SDK requires a non-empty value            
            _client = new ChatClient(model: "llama3.2", new ApiKeyCredential(apikey), options);
        }

        public Task<string> GenerateAsync(string userPrompt, string systemPrompt)
        {
            List<ChatMessage> messages =
            [
                new SystemChatMessage(systemPrompt),
                new UserChatMessage(userPrompt)
            ];

            ChatCompletion completion = _client.CompleteChat(messages);
            return Task.FromResult(completion.Content[0].Text.Trim());
        }
    }
}
