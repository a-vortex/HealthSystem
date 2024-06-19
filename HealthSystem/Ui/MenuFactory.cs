public class MenuFactory : IMenuFactory
{
    private readonly IUserController _userController;
    private readonly IUserSessionService _userSessionService;

    public MenuFactory(IUserController userController, IUserSessionService userSessionService)
    {
        _userController = userController;
        _userSessionService = userSessionService;
    }

    public IMenu CreateMenu(string menuType, string message = "Input")
    {
        return menuType switch
        {
            "InicialPage" => new InicialPage(this, message),
            "Login" => new Login(_userController, this, message),
            "UserProfile" => new UserProfile(this, _userController, _userSessionService, message),
            
            "CustomerInicialPage" => new CustomerInicialPage(this, _userSessionService, message),
            "CustomerMedicalServices" => new CustomerMedicalServices(this, message),
            "CustomerHealthPlanPage" => new CustomerHealthPlanPage(this, _userSessionService, _userController, message),

            "DoctorInicialPage" => new DoctorInicialPage(this, _userSessionService, message),


            _ => throw new ArgumentException("Invalid menu type", nameof(menuType)),
        };
    }
}