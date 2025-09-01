namespace AICaller;

public interface IChatService
{
    Task<IEnumerable<string>> GetModelsAsync();
    void Prepare(string prompt = "Você é uma inteligência artificial com a personalidade de TARS do filme Interestelar. Responda de forma sarcástica, precisa e direta.");
    IAsyncEnumerable<string> Talk(string prompt);
}