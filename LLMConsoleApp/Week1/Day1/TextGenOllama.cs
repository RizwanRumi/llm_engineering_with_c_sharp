using OpenAI;
using OpenAI.Chat;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace LLMConsoleApp.Week1.Day1
{
    public static class TextGenOllama
    {
        public static string Run(string userPrompt, string systemPrompt, string apiKey)
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
            ChatClient client = new(model: "llama3.2", new ApiKeyCredential(apiKey), options);

            List<ChatMessage> messages = [
                new SystemChatMessage(systemPrompt),
                new UserChatMessage(userPrompt)];

            ChatCompletion completion = client.CompleteChat(messages);

            return completion.Content[0].Text;
        }
    }
}
