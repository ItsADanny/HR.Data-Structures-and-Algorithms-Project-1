using System.Text.Json;

class JsonTaskRepository : ITaskRepository
{
    private readonly string _filePath;

    public JsonTaskRepository(string filePath) => _filePath = filePath;

    public List<Task> LoadTasks()
    {
        if (!File.Exists(_filePath))
            return new List<Task>();

        string json = File.ReadAllText(_filePath);
        var tasks = JsonSerializer.Deserialize<List<Task>>(json);
        return tasks ?? new List<Task>();
    }

    public void SaveTasks(List<Task> tasks)
    {
        string json = JsonSerializer.Serialize(tasks, new 
        JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }
}