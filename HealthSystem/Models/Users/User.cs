namespace HealthSystem.Models.Users;
using System.ComponentModel.DataAnnotations;

public abstract class User
{
    // NÃO TOQUE NESSE ID DE JEITO NENHUM
    [Key]
    public int id { get; protected set; } 
    // POR FAVOR NAO MUDE ISSO SUA TONTA!
    [Required]
    public string? Login { get; set; }
    [Required]
    public string? Password { get; set; }
    public Personal PersonalInfo { get; set; }

    public User() => PersonalInfo = new Personal();
    public User(string login, string password,
    string name, string address, string email, string telephone, string cpf)
    {
        Login = login;
        Password = password;
        PersonalInfo = new Personal()
        {
            Name = name,
            Address = address,
            Email = email,
            Telephone = telephone,
            Cpf = cpf
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
        public string? Telephone { get; set; }
        [Required]
        public string? Cpf { get; set; }

        public void UpdateName(string newName) => Name = newName;
        public void UpdateAddress(string newAddress) => Address = newAddress;
        public void UpdateEmail(string newEmail) => Email = newEmail;
        public void UpdateTelephone(string newTelephone) => Telephone = newTelephone;
    }
}