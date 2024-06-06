abstract class User(string login, string password)
{
    protected int _id;
    public string? Login { get; private set; } = login;
    public string? Password { get; private set; } = password;
    protected Personal PersonalInfo { get; private set; } = new Personal();

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