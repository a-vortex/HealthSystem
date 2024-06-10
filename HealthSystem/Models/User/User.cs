namespace HealthSystem.Models.User;
public abstract class User(string login, string password, string name, string address, string email, int telephone)
{
    protected int _id;
    public string? Login { get; private set; } = login;
    public string? Password { get; private set; } = password;
    public Personal PersonalInfo { get; private set; } = new Personal(name, address, email, telephone);

    public class Personal(string name, string address, string email, int telephone)
    {
        public string? Name { get; private set; } = name;
        public string? Address { get; private set; } = address;
        public string? Email { get; private set; } = email;
        public int? Telephone { get; private set; } = telephone;

        public void UpdateName(string newName) => Name = newName;
        public void UpdateAddress(string newAddress) => Address = newAddress;
        public void UpdateEmail(string newEmail) => Email = newEmail;
        public void UpdateTelephone(int newTelephone) => Telephone = newTelephone;
    }

    public void UpdateLogin(string newlogin) => Login = newlogin;
    public void UpdatePassword(string newPassword) => Password = newPassword;
}