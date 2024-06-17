public class InicialPage : IMenu
{
    protected string _description =
    "Welcome to Health System! This is a simple terminal system created by Clara to gain some points on my subject Object Oriented Programming. Enjoy!";
    private readonly IMenuFactory _menuFactory;
    public InicialPage(IMenuFactory menuFactory)
    {
        _menuFactory = menuFactory;
        _title = "Health System";
        _options.Add("[1] Login or Sign Up");
        _options.Add("[2] About");
        _options.Add("[3] Exit");
    }
    public InicialPage(IMenuFactory menuFactory, string message) : this(menuFactory)
    {
        inputstr = message;
    }
    public override IMenu? MenuNext(int option)
    {
        return option switch
        {
            1 => _menuFactory.CreateMenu("Login"),
            2 => DisplayAbout(),
            3 => null,
            _ => _menuFactory.CreateMenu("InicialPage","Please type a valid option"),
        };
    }
    private IMenu? DisplayAbout()
    {
        RenderAboutPage();
        return _menuFactory.CreateMenu("InicialPage");
    }
    public static void Exit()
    {
        RenderPage("Thank you for using Health System!");
        Console.WriteLine("> Press any key to exit the program: ");
    }
    private void RenderAboutPage()
    {
        RenderPage("About", _description);
        Console.WriteLine("> Press any key to return to the main menu:");
        Console.ReadKey();
    }
    private static void RenderPage(string title, string? content = null)
    {
        string border = new('=', Console.WindowWidth - 1);
        Console.Clear();
        Console.WriteLine(border);
        Console.WriteLine($"|| {title}");
        Console.WriteLine(border);
        Console.WriteLine();

        if (!string.IsNullOrEmpty(content))
        {
            Console.WriteLine(content);
            Console.WriteLine();
        }

        Console.WriteLine(border);
    }
}