abstract class User
{
    protected int _id;
    public string? Login { get; private set; }
    public string? Password { get; private set; }
    protected Personal PersonalInfo { get; private set; }

    //modificar
    public User(string login, string password)
    {
        this.Login = login;
        this.Password = password;
        PersonalInfo = new Personal();
    }
    protected class Personal
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public int? Telephone { get; set; }

        public Personal()
        {
        }
        public Personal(string name, string address, string email, int telephone)
        {
            Name = name;
            Address = address;
            Email = email;
            Telephone = telephone;
        }
    }
}