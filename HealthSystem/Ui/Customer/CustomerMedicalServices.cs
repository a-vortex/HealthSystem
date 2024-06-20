public class CustomerMedicalServices : IMenu
{
    private readonly IMenuFactory _menuFactory;
    private readonly IAppointmentController _appointmentController;
    private readonly IUserController _userController;
    public CustomerMedicalServices(IMenuFactory menuFactory, IAppointmentController appointmentController, string message = "Option")
    {
        _title = "Medical Services";
        _options.Add("[1] Schedule an appointment");
        _options.Add("[2] View Appointments");
        _options.Add("[3] View Medical Records");
        _options.Add("[4] View Health Plans");
        _options.Add("[5] Back to main Page");
        inputstr = message;
        _menuFactory = menuFactory;
        _appointmentController = appointmentController;
    }

    public override IMenu? MenuNext(int option)
    {
        switch (option)
        {
            case 1:
                var sucess = _appointmentController.ScheduleMedicalAppointment(out string error);
                if (!sucess)
                {
                   return _menuFactory.CreateMenu("CustomerMedicalServices", error);
                }
                return _menuFactory.CreateMenu("CustomerMedicalServices", "Appointment scheduled successfully!");
            case 2:
                return this;
            case 3:
                return this;
            case 4:
                return _menuFactory.CreateMenu("CustomerHealthPlanPage", "Option");
            case 5:
                return _menuFactory.CreateMenu("CustomerInicialPage", "Option");
            default:
                return _menuFactory.CreateMenu("CustomerMedicalServices", "Invalid Option, please type an option");
        }
    }

}