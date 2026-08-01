using OpenAI;
using OpenAI.Chat;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLMConsoleApp.Week1.Day1
{
    public static class TextGenOllama
    {
        public static string Run(string userPrompt, string systemPrompt, string apiKey)
        {
            var options = new OpenAIClientOptions
            {
                Endpoint = new Uri("http://localhost:11434/v1")
            };

            ChatClient client = new(model: "llama3.2", new ApiKeyCredential(apiKey), options);

            List<ChatMessage> messages = [
                new SystemChatMessage(systemPrompt),
                new UserChatMessage(userPrompt)];

            ChatCompletion completion = client.CompleteChat(messages);

            return completion.Content[0].Text;
        }
    }
}
