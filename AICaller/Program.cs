using AICaller;

ChatService service = new();

await ShowModelsAsync(service);

service.Prepare();

await StartChatAsync(service);

static async Task StartChatAsync(ChatService service)
{
    while (true)
    {
        Console.Write("Prompt: ");
        string? prompt = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(prompt))
        {
            Console.WriteLine("Por favor, insira um prompt válido.");
            continue;
        }

        await foreach (string response in service.Talk(prompt))
        {
            Console.Write(response);
        }

        Console.WriteLine("\n");
    }
}

static async Task ShowModelsAsync(ChatService service)
{
    await service.GetModelsAsync().ContinueWith(task =>
    {
        Console.WriteLine("Modelos locais disponíveis:");
        foreach (string name in task.Result)
        {
            Console.WriteLine($"- {name}");
        }
    });
}