public class CustomerHealthPlanPage : IMenu
{
    private readonly IMenuFactory _menuFactory;
    private readonly IUserSessionService _userSessionService;
    private readonly IUserController _userController;
    public CustomerHealthPlanPage(IMenuFactory menuFactory,IUserSessionService userSessionService, IUserController userController, string message = "Option")
    {
        _menuFactory = menuFactory;
        _userSessionService = userSessionService;
        _userController = userController;
        inputstr = message;
        // var userPlan = _userSessionService.CurrentUser?.HealthPlanDetails;
        // string plan = userPlan?.Name ?? "No Health Plan";
        _title = "Customer Health Plan Page";
        // _options.Add($"=> Your Health Plan: {plan}");
        _options.Add("[1] Edit Health Plan");
        _options.Add("[2] Cancel Health Plan");
        _options.Add("[3] Back to Customer Page");
    }

    public override IMenu? MenuNext(int option)
    {
        switch (option)
        {
            case 1:
                // var sucess = editHealthPlan(out string error);
                // if (sucess)
                // {
                //     return _menuFactory.CreateMenu("CustomerHealthPlanPage", "Sucessfully changed Health Plan!");
                // }
                // return _menuFactory.CreateMenu("CustomerHealthPlanPage", error);
                return this;
            case 2:
                return this;
            case 3:
                return _menuFactory.CreateMenu("CustomerInicialPage", "Option");
            default:
                return _menuFactory.CreateMenu("CustomerHealthPlanPage", "Invalid Option, please type an option");
        }
    }
    // private bool editHealthPlan(out string error)
    // {
    //     _userController.DisplayHealthPlansMenu(out int count);
    //     Console.WriteLine("> Choose a Health Plan number: ");
    //     var input = Console.ReadLine();
    //     int planId;
    //     count--;
    //     while(!int.TryParse(input, out planId) || planId>count || planId<0)
    //     {
    //         _userController.DisplayHealthPlansMenu(out count);
    //         Console.WriteLine("> Choose a valid Health Plan number: ");
    //         input = Console.ReadLine();
    //     }
    //     return _userController.UpdateHealthPlan(planId, out error);
    // }
}