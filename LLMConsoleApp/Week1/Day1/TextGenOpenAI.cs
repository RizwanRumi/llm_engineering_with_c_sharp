using OpenAI.Chat;

namespace LLMConsoleApp.Week1.Day1
{
    public static class TextGenOpenAI
    {
        public static string Run(string apiKey, string userPrompt, string systemPrompt)
        {
            ChatClient client = new(model: "gpt-5.1", apiKey: apiKey);

            List<ChatMessage> messages =
            [
                new SystemChatMessage(systemPrompt),
            new UserChatMessage(userPrompt)
            ];

            ChatCompletion completion = client.CompleteChat(messages);
            return completion.Content[0].Text;
        }
    }  
}
