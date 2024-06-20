public class Login : IMenu
{
    private readonly IUserController _userController;
    private readonly IMenuFactory _menuFactory;
    public Login(IUserController userController, IMenuFactory menuFactory, string optionadd)
    {
        _title = "Login or Sign Up";
        _userController = userController;
        _menuFactory = menuFactory;
        _options.Add("[1] Login");
        _options.Add("[2] Sign Up");
        _options.Add("[3] Return to the main menu");
        inputstr = optionadd;
    }
    public override IMenu MenuNext(int option)
    {
        switch (option)
        {
            case 1:
                int? type;
                var isLogged = _userController.Login(out type);
                if (isLogged)
                {
                    return type switch
                    {
                        1 => _menuFactory.CreateMenu("DoctorInicialPage", "Welcome to HealthSystem!"),
                        2 => _menuFactory.CreateMenu("CustomerInicialPage", "Welcome to HealthSystem!"),
                        _ => _menuFactory.CreateMenu("Login", "Invalid User Type, please try again")
                    };
                }
                return _menuFactory.CreateMenu("Login", "Login failed, please try again");

            case 2:
                var isSignedUp = _userController.SignUp();
                if (isSignedUp)
                {
                    return _menuFactory.CreateMenu("Login", "Sign Up successful, please login");
                }
                return _menuFactory.CreateMenu("Login", "Sign Up failed, please try again");
            case 3:
                return _menuFactory.CreateMenu("InicialPage", "Option");

            default:
                return _menuFactory.CreateMenu("Login", "Invalid Option, please type an option");
        }
    }
}