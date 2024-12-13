

using System.Text.Json;

namespace Business.Models;

public class JsonFileManager
{
    private const string FileName = "users.json";

    public List<User> LoadFromFile()
    {
        if (File.Exists(FileName))
        {
            try
            {
                string json = File.ReadAllText(FileName);
                return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading JSON file: " + ex.Message);
                return new List<User>();
            }
        }
        return new List<User>();
    }

    public void SaveToFile(List<User> users)
    {
        string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FileName, json);
    }
}
