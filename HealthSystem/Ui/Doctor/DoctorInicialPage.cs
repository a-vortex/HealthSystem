public class DoctorInicialPage : IMenu
{
    private readonly IMenuFactory _menuFactory;
    private readonly IUserSessionService _userSessionService;
    
    private readonly IAppointmentController _appointmentController;
    public DoctorInicialPage(IMenuFactory menuFactory,IUserSessionService userSessionService,IAppointmentController appointmentController, string optionadd = "Input")
    {
        _title = "Doctor Page";
        _menuFactory = menuFactory;
        _userSessionService = userSessionService;
        _appointmentController = appointmentController;
        _options.Add("[1] View Profile");
        _options.Add("[2] View Appointments");
        _options.Add("[3] Log Out");
        inputstr = optionadd;
    }
    public override IMenu MenuNext(int option)
    {
        switch(option)
        {
            case 1:
                return _menuFactory.CreateMenu("UserProfile", "Option");
            case 2:
                _appointmentController.ViewAppointmentsDoctor();
                return this;
            case 3:
                _userSessionService.ClearCurrentUser();
                return _menuFactory.CreateMenu("Login", "Logged Out");
            default:
                return _menuFactory.CreateMenu("DoctorInicialPage", "Invalid Option, please type an option");
        }
    }
}