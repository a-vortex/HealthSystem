public class InicialPage : IMenu
{
    protected string _description = "Welcome to Health System! This is a simple terminal system created by Clara to gain some points on my subject Object Oriented Programming. Enjoy!";
    public InicialPage()
    {
        _title = "Health System";
        _options.Add("[1] Login");
        _options.Add("[2] Sign Up");
        _options.Add("[3] About");
        _options.Add("[4] Exit");
    }
    public override IMenu? MenuNext(int option)
    {
        InicialPage inicialPage = new();
        switch(option)
        {
            case 1:
                Login login = new();
                return login;
            case 2:
                Signup signup = new();
                return signup;
            case 3:
                About();
                return inicialPage;
            case 4:
                return null;
            default:
                Console.WriteLine("Invalid Option");
                return inicialPage;
        }

    }
    private void About()
    {
        string border = new('=', _title.Length + 30);

        Console.Clear();
        Console.WriteLine(border);
        Console.WriteLine("|| " + "About");
        Console.WriteLine(border);
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.WriteLine(border);
        Console.WriteLine("> Press any key to return to the main menu:");
        Console.ReadKey();
    }
    public static void Exit()
    {
        Console.Clear();
        string border = new('=', 43);
        Console.WriteLine(border);
        Console.WriteLine("|| " + "Thank you for using Health System!");
        Console.WriteLine(border);
        Console.WriteLine();
        Console.WriteLine(border);
        Console.WriteLine("> Press any key to exit the program: ");
    }
}