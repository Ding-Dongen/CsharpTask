namespace Business.Models;

public class UserManager
{
    private List<User> users = new List<User>();
    private readonly JsonFileManager fileManager = new JsonFileManager();

    public UserManager()
    {
        LoadUsers();
    }

    public void AddUser(User user)
    {
        if (users.Exists(u => u.Email == user.Email))
        {
            throw new ArgumentException("Email already exists.");
        }
        users.Add(user);
        SaveUsers();
    }

    public User? GetUserByEmail(string email)
    {
        return users.Find(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    public void UpdateUser(User user)
    {
        var existingUser = users.Find(u => u.Id == user.Id);
        if (existingUser != null)
        {
            int index = users.IndexOf(existingUser);
            users[index] = user;
        }
        else
        {
            throw new ArgumentException("User not found.");
        }
        SaveUsers();
    }

    public void DeleteUser(Guid id)
    {
        var user = users.Find(u => u.Id == id);
        if (user != null)
        {
            users.Remove(user);
        }
        else
        {
            throw new ArgumentException("User not found.");
        }
        SaveUsers();
    }

    public List<User> GetAllUsers() => users;

    private void SaveUsers()
    {
        fileManager.SaveToFile(users);
    }

    private void LoadUsers()
    {
        users = fileManager.LoadFromFile(); // Load from file when UserManager is initialized
    }
}
