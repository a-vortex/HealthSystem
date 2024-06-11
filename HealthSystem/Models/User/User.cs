using System.ComponentModel.DataAnnotations;
namespace HealthSystem.Models.User;

public abstract class User
{
    [Key]
    public int id { get; protected set; }
    [Required]
    public string? Login { get; set; }
    [Required]
    public string? Password { get; set; }
    public Personal PersonalInfo { get; set; }

    public User() => PersonalInfo = new Personal();
    public User(string login, string password, Personal personalInfo, string name, string address, string email, int telephone)
    {
        Login = login;
        Password = password;
        PersonalInfo = new Personal()
        {
            Name = name,
            Address = address,
            Email = email,
            Telephone = telephone
        };
    }

    public void UpdateLogin(string newlogin) => Login = newlogin;
    public void UpdatePassword(string newPassword) => Password = newPassword;
    public class Personal
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public int? Telephone { get; set; }

        public void UpdateName(string newName) => Name = newName;
        public void UpdateAddress(string newAddress) => Address = newAddress;
        public void UpdateEmail(string newEmail) => Email = newEmail;
        public void UpdateTelephone(int newTelephone) => Telephone = newTelephone;
    }
}