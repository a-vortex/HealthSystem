public class CustomerMedicalServices : IMenu
{
    private readonly IMenuFactory _menuFactory;
    private readonly IAppointmentController _appointmentController;
    public CustomerMedicalServices(IMenuFactory menuFactory, IAppointmentController appointmentController, string message = "Option")
    {
        _title = "Medical Services";
        _options.Add("[1] Schedule an appointment");
        _options.Add("[2] View Appointments");
        _options.Add("[3] Back to main Page");
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
                _appointmentController.ViewAppointments();
                return this;
            case 3:
                return _menuFactory.CreateMenu("CustomerInicialPage", "Option");
            default:
                return _menuFactory.CreateMenu("CustomerMedicalServices", "Invalid Option, please type an option");
        }
    }

}