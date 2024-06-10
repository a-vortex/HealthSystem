namespace HealthSystem.Models.User;
public abstract class User(string login, string password, string name, string address, string email, int telephone)
{
    protected int _id;
    public string? Login { get; private set; } = login;
    public string? Password { get; private set; } = password;
    public Personal PersonalInfo { get; private set; } = new Personal(name, address, email, telephone);

    public class Personal(string name, string address, string email, int telephone)
    {
        public string? Name { get; set; } = name;
        public string? Address { get; set; } = address;
        public string? Email { get; set; } = email;
        public int? Telephone { get; set; } = telephone;
    }
}