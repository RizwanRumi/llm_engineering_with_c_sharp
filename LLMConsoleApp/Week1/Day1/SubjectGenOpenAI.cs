using OpenAI.Chat;

namespace LLMConsoleApp.Week1.Day1
{
    public static class SubjectGenOpenAI
    {
        public static string Run(string apiKey, string emailText)
        {
            ChatClient client = new(model: "gpt-5.1", apiKey: apiKey);

            List<ChatMessage> messages =
            [
                new SystemChatMessage("You are an assistant that reads the contents of an email and suggests a short, clear, professional subject line for it. Respond with only the subject line, nothing else."),
            new UserChatMessage(emailText)
            ];

            ChatCompletion completion = client.CompleteChat(messages);
            return completion.Content[0].Text;
        }
    }  
}
