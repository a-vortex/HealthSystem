public class UserProfile : IMenu
{
    private readonly IMenuFactory _menuFactory;
    private readonly IUserController _userController;
    private readonly IUserSessionService _userSessionService;
    public UserProfile(IMenuFactory menuFactory,IUserController userController,IUserSessionService userSessionService, string message = "Option")
    {
        _title = "Your profile";
        _options.Add("[1] View Profile");
        _options.Add("[2] Edit Profile");
        _options.Add("[3] Back to Main Page");
        inputstr = message;
        _menuFactory = menuFactory;
        _userSessionService = userSessionService;
        _userController = userController;
    }

    public override IMenu? MenuNext(int option)
    {
        var type = _userSessionService.GetUserType();
        switch (option)
        {
            case 1:
                ViewProfile();
                return _menuFactory.CreateMenu("UserProfile", "Option");
            case 2:
                string error;
                if (EditProfile(out error)){
                    return _menuFactory.CreateMenu("UserProfile", "Profile edited successfully");
                }
                return _menuFactory.CreateMenu("UserProfile", error);
            case 3:
                if (type == "Doctor"){
                    return _menuFactory.CreateMenu("DoctorInicialPage", "Option");
                }
                return _menuFactory.CreateMenu("CustomerInicialPage", "Option");
            default:
                return _menuFactory.CreateMenu("UserProfile", "Invalid Option, please type an option");
        }
    }
    private void ViewProfile()
    {
        RegisterUserDto thisuser = _userSessionService.CurrentUser;
        Console.Clear();
        int windowWidth = Console.WindowWidth;
        string border = new('=', windowWidth - 1);
        Console.WriteLine(border);
        Console.WriteLine("|| " + "Your profile");
        Console.WriteLine(border);
        Console.WriteLine();
        Console.WriteLine("=> Name: " + thisuser.Name);
        Console.WriteLine();
        Console.WriteLine("=> Email: " + thisuser.Email);
        Console.WriteLine();
        Console.WriteLine("=> Address: " + thisuser.Address);
        Console.WriteLine();
        Console.WriteLine("=> Telephone: " + thisuser.Telephone);
        Console.WriteLine();
        Console.WriteLine("=> CPF: " + thisuser.Cpf);
        Console.WriteLine();
        if (thisuser.CRMorCOREN != null)
        {
            Console.WriteLine("=> CRM/COREN: " + thisuser.CRMorCOREN);
            Console.WriteLine();
            Console.WriteLine("=> Specialty: " + ((MedicalServiceArea)thisuser.MedicalServiceArea).ToString());
            Console.WriteLine();
        }
        Console.WriteLine(border);
        Console.WriteLine("Press any key to return to the previous menu");
        Console.ReadKey();
    }
    private bool EditProfile(out string error){
        error = "Operation canceled by the user";
        string[] options = new string[] {
            "Name",
            "Email",
            "Address",
            "Telephone",
            "UserName",
            "Password",
        };
        Console.Clear();
        int windowWidth = Console.WindowWidth;
        string border = new('=', windowWidth - 1);
        Console.WriteLine(border);
        Console.WriteLine("|| " + "Edit Profile");
        Console.WriteLine(border);
        Console.WriteLine();
        Console.WriteLine("=> Choose the field you want to edit: ");
        Console.WriteLine();
        for (int i = 0; i < options.Length; i++)
        {
            Console.WriteLine($"[{i + 1}] {options[i]}");
            
        Console.WriteLine();
        }
        Console.WriteLine("[0] Cancel");
        Console.WriteLine();
        Console.WriteLine(border);
        Console.Write("=> Type the number of the field you want to edit: ");
        int option;
        while (!int.TryParse(Console.ReadLine(), out option) || option < 0 || option > options.Length)
        {
            Console.Clear();
            Console.WriteLine(border);
            Console.WriteLine("|| " + "Edit Profile");
            Console.WriteLine(border);
            Console.WriteLine();
            Console.WriteLine("=> Choose the field you want to edit:");
            
            Console.WriteLine();
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {options[i]}");
            Console.WriteLine();
            }
            Console.WriteLine("[0] Cancel");
            Console.WriteLine();
            Console.WriteLine(border);
            Console.Write("=> Invalid option, please type a valid option: ");
        }

        return option switch
        {
            1 => _userController.EditUser("Name", out error),
            2 => _userController.EditUser("Email",out error),
            3 => _userController.EditUser("Address", out error),
            4 => _userController.EditUser("Telephone", out error),
            5 => _userController.EditUser("UserName", out error),
            6 => _userController.EditUser("Password", out error),
            0 => false,
            _ => false,
        };
    }
}