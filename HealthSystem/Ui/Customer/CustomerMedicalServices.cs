public class CustomerMedicalServices : IMenu
{
    private readonly IMenuFactory _menuFactory;
    public CustomerMedicalServices(IMenuFactory menuFactory, string message = "Option")
    {
        _title = "Medical Services";
        _options.Add("[1] Schedule an appointment");
        _options.Add("[2] View Appointments");
        _options.Add("[3] View Medical Records");
        _options.Add("[4] View Health Plans");
        _options.Add("[5] Back to main Page");
        inputstr = message;
        _menuFactory = menuFactory;
    }

    public override IMenu? MenuNext(int option)
    {
        switch (option)
        {
            case 1:
                return this;
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