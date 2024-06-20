public class CustomerInicialPage : IMenu
{
    private readonly IMenuFactory _menuFactory;
    private readonly IUserSessionService _userSessionService;
    public CustomerInicialPage(IMenuFactory menuFactory, IUserSessionService userSessionService, string message = "Option")
    {
        _title = "Customer Page";
        _options.Add("[1] View Profile");
        _options.Add("[2] Medical Services");
        _options.Add("[3] Log Out");
        inputstr = message;
        _menuFactory = menuFactory;
        _userSessionService = userSessionService;
    }

    public override IMenu? MenuNext(int option)
    {
        switch (option)
        {
            case 1:
                return _menuFactory.CreateMenu("UserProfile", "Option");
            case 2:
                return _menuFactory.CreateMenu("CustomerMedicalServices", "Option");
            case 3:
                _userSessionService.ClearCurrentUser();
                return _menuFactory.CreateMenu("Login", "Logged Out");
            default:
                return _menuFactory.CreateMenu("CustomerInicialPage", "Invalid Option, please type an option");
        }
    }
}