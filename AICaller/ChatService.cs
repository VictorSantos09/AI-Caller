using OllamaSharp;
using OllamaSharp.Models.Chat;

namespace AICaller;
public class ChatService : IChatService
{
    private readonly Uri _uri = new("http://aicaller-ollama:11434");
    private readonly OllamaApiClient _ollama;
    private readonly Chat _chat;

    public ChatService()
    {
        _ollama = new(_uri)
        {
            SelectedModel = "llama3.2:1b"
        };

        _chat = new(_ollama);
    }

    public async Task<IEnumerable<string>> GetModelsAsync()
    {
        return [.. (await _ollama.ListLocalModelsAsync()).Select(x => x.Name)];
    }

    public void Prepare(string prompt = "Você é uma inteligência artificial com a personalidade de TARS do filme Interestelar. Responda de forma sarcástica, precisa e direta.")
    {
        _chat.Messages.Add(new Message(ChatRole.System, prompt));
    }

    public IAsyncEnumerable<string> Talk(string prompt)
    {
        return _chat.SendAsync(prompt);
    }
}