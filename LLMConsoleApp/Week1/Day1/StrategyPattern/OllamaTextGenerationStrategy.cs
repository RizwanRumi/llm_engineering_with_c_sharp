using OpenAI;
using OpenAI.Chat;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace LLMConsoleApp.Week1.Day1.StrategyPattern
{
    public class OllamaTextGenerationStrategy : ITextGenerationStrategy
    {
        private readonly ChatClient _client;

        public OllamaTextGenerationStrategy(string apikey)
        {
            // Disable proxy usage for this HttpClient — corporate proxy env vars (HTTP_PROXY/HTTPS_PROXY)
            // get picked up automatically by .NET and can intercept even localhost calls, causing
            // requests to Ollama to hang and fail with a 504 Gateway Timeout.
            var handler = new HttpClientHandler
            {
                UseProxy = false
            };
            var httpClient = new HttpClient(handler);

            // Point the OpenAI SDK at the local Ollama server (OpenAI-compatible API endpoint)
            // and use our proxy-free HttpClient as the transport.
            var options = new OpenAIClientOptions
            {
                Endpoint = new Uri("http://localhost:11434/v1"),
                Transport = new HttpClientPipelineTransport(httpClient)
            };

            // Ollama ignores the API key value but the SDK requires a non-empty credential.
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
