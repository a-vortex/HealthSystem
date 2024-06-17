public class Login : IMenu
{
    private readonly IUserController _userController;
    private readonly IMenuFactory _menuFactory;
    public Login(IUserController userController, IMenuFactory menuFactory, string optionadd = "Input")
    {
        _title = "Login or Sign Up";
        _userController = userController;
        _menuFactory = menuFactory;
        _options.Add("[1] Login");
        _options.Add("[2] Sign Up");
        _options.Add("[3] Return to the main menu");
    }
    public override IMenu MenuNext(int option)
    {
        switch(option)
        {
            case 1:
                var isLogged = _userController.Login();
                if (isLogged)
                {
                    return _menuFactory.CreateMenu("CustomerInicialPage");
                }
                return _menuFactory.CreateMenu("InicialPage", "Login failed, please try again");

            case 2:
            case 3:
                return _menuFactory.CreateMenu("InicialPage");

            default:
                return _menuFactory.CreateMenu("Login", "Invalid Option, please type an option");
        }
    }
}