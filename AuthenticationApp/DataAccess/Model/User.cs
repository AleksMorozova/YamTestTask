using System.ComponentModel.DataAnnotations;

namespace AuthenticationApp.DataAccess.Model;

public class User
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    public string Password { get; set; }

    public int Age { get; set; }

    public string Email { get; set; }

    public string Role { get; set; }
}
