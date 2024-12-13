
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace Business.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    [JsonConstructor]
    public User(string name, string lastname, string email, string password)
    {
        Name = name;
        LastName = lastname;
        Email = email;
        Password = password;
    }
}
