
namespace Business.Entities;

public class UserEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public UserEntity(string name, string lastname, string email, string password)
    {
        Name = name;
        LastName = lastname;
        Email = email;
    }
}
