namespace Bitstore.Core.Models;

public class User
{
    public User(Guid id, string username,
        string email, string passwordHash)
    {
        Id = id;
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        //Role = role;
    }
    public Guid  Id { get; }
    public string Username { get;  }
    public string Email { get;  }
    public string Role { get; } = string.Empty;
    public string PasswordHash { get;  }
    public List<Beat> Beats = new();
    
    public static  User Create(Guid id, string username, 
        string email, string passwordHash)
    {
        // validation
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
        {
            throw new Exception();
        }
        return new User(id, username, email, passwordHash);
    }
}