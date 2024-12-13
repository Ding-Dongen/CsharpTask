
using Business.Models;

namespace MainApp;

public class UserConsoleInterface
{
    private readonly UserManager userManager = new UserManager();

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\nUser Management App");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. Show Users");
            Console.WriteLine("3. Update User");
            Console.WriteLine("4. Delete User");
            Console.WriteLine("5. Find User By Email");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid option. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddUser();
                    break;
                case 2:
                    ShowUsers();
                    break;
                case 3:
                    UpdateUser();
                    break;
                case 4:
                    DeleteUser();
                    break;
                case 5:
                    FindUserByEmail();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    private void AddUser()
    {
        Console.Write("Enter user name: ");
        string name = Console.ReadLine()!;
        Console.Write("Enter user last name: ");
        string lastname = Console.ReadLine()!;
        Console.Write("Enter email: ");
        string email = Console.ReadLine()!;
        Console.Write("Enter password: ");
        string password = Console.ReadLine()!;

        try
        {
            userManager.AddUser(new User(name, lastname, email, password));
            Console.WriteLine("User added successfully.");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private void ShowUsers()
    {
        var users = userManager.GetAllUsers();
        if (users.Count == 0)
        {
            Console.WriteLine("No users found.");
            return;
        }
        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, LastName: {user.LastName} Email: {user.Email}");
        }
    }

    private void UpdateUser()
    {
        Console.Write("Enter user email to update: ");
        string email = Console.ReadLine()!;


        var user = userManager.GetUserByEmail(email);
        if (user != null)
        {
            Console.Write("Enter new name: ");
            string newName = Console.ReadLine()!;
            Console.Write("Enter new last name: ");
            string newLastName = Console.ReadLine()!;
            Console.Write("Enter new email: ");
            string newEmail = Console.ReadLine()!;
            Console.Write("Enter new password: ");
            string newPassword = Console.ReadLine()!;

            user.Name = string.IsNullOrWhiteSpace(newName) ? user.Name : newName;
            user.LastName = string.IsNullOrWhiteSpace(newLastName) ? user.LastName : newLastName;
            user.Email = string.IsNullOrWhiteSpace(newEmail) ? user.Email : newEmail;
            user.Password = string.IsNullOrWhiteSpace(newPassword) ? user.Password : newPassword;

            userManager.UpdateUser(user);
            Console.WriteLine("User updated successfully.");
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }

    private void DeleteUser()
    {
        Console.Write("Enter user email to delete: ");
        string email = Console.ReadLine()!;

        var user = userManager.GetUserByEmail(email);
        if (user != null)
        {
            try
            {
                userManager.DeleteUser(user.Id);
                Console.WriteLine("User deleted successfully.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("User not found.");
            }
        }
        else
        {
            Console.WriteLine("No user found with that email.");
        }
    }

    private void FindUserByEmail()
    {
        Console.Write("Enter email to search: ");
        string email = Console.ReadLine()!;
        var user = userManager.GetUserByEmail(email);

        if (user != null)
        {
            Console.WriteLine($"User found - ID: {user.Id}, Name: {user.Name}, Last name, {user.LastName} Email: {user.Email}");
        }
        else
        {
            Console.WriteLine("No user found with that email.");
        }
    }
}
