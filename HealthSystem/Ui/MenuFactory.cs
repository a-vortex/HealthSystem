public class MenuFactory : IMenuFactory
{
    private readonly IUserController _userController;
    private readonly IUserSessionService _userSessionService;
    private readonly IAppointmentController _appointmentController;

    public MenuFactory(IUserController userController, IUserSessionService userSessionService,  IAppointmentController appointmentController)
    {
        _userController = userController;
        _userSessionService = userSessionService;
        _appointmentController = appointmentController;
    }

    public IMenu CreateMenu(string menuType, string message = "Input")
    {
        return menuType switch
        {
            "InicialPage" => new InicialPage(this, message),
            "Login" => new Login(_userController, this, message),
            "UserProfile" => new UserProfile(this, _userController, _userSessionService, message),
            
            "CustomerInicialPage" => new CustomerInicialPage(this, _userSessionService, message),
            "CustomerMedicalServices" => new CustomerMedicalServices(this, _appointmentController, message),
            "CustomerHealthPlanPage" => new CustomerHealthPlanPage(this, _userSessionService, _userController, message),

            "DoctorInicialPage" => new DoctorInicialPage(this, _userSessionService,_appointmentController, message),


            _ => throw new ArgumentException("Invalid menu type", nameof(menuType)),
        };
    }
}