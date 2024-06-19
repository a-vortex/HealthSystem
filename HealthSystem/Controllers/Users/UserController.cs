using HealthSystem.Models.Users;
using System.Text.RegularExpressions;

public class UserController : IUserController
{
    readonly IUserService _userService;
    readonly IUserSessionService _userSessionService;

    public UserController(IUserService userService, IUserSessionService userSessionService)
    {
        _userService = userService;
        _userSessionService = userSessionService;
    }

    public bool Login(out int? type)
    {
        type = null;

        var userName = GetValidInput("user");
        var userPassword = GetValidInput("password");

        var userDTO = new UserDto
        {
            Login = userName,
            Password = userPassword
        };

        if (!_userService.Login(userDTO))
            return false;

        var userType = _userService.GetUserType(userName);
        type = userType == "Doctor" ? 1 : userType == "Customer" ? 2 : null;

        var loggedInUser = _userService.GetByLogin(userName);
        _userSessionService.SetCurrentUser(loggedInUser);

        return true;
    }

    public bool SignUp()
    {
        var type = GetUserType();
        var userDTO = GetUserDetails(type);

        if (ConfirmUserDetails(userDTO))
        {
            _userService.RegisterUser(userDTO, type);
            return true;
        }

        return false;
    }

    public bool EditUser(string info, out string error)
    {
        var currentuserName = GetValidInput("current user", "Input", "Edit Profile");
        var currentPassword = GetValidInput("current password", "Input", "Edit Profile");

        var currentUserDTO = new UserDto
        {
            Login = currentuserName,
            Password = currentPassword
        };

        if (!_userService.Login(currentUserDTO))
        {
            error = "Invalid credentials";
            return false;
        }

        RegisterUserDto currentCredentials = _userService.GetByLogin(currentuserName);
        UpdateUserInfo(info, currentCredentials);

        if (info != "UserName")
        {
            currentCredentials.Login = null;
        }
        var success = _userService.EditUser(currentCredentials, currentUserDTO, out error);
        if (success)
        {
            var loggedInUser = _userService.GetByLogin(currentCredentials.Login ?? currentuserName);
            _userSessionService.SetCurrentUser(loggedInUser);
        }
        return success;
    }

    private string GetUserType()
    {
        int type = 0;
        RenderSignupPage("Sign Up Page", "Wich one are you?", new string[] { "[1] Doctor", "[2] Patient" });

        while (type != 1 && type != 2)
        {
            if (!int.TryParse(Console.ReadLine(), out type) || (type != 1 && type != 2))
            {
                RenderSignupPage("Sign Up Page", "Please type a valid option", new string[] { "[1] Doctor", "[2] Patient" });
            }
        }

        return type == 1 ? "Doctor" : "Customer";
    }

    private RegisterUserDto GetUserDetails(string type)
    {
        var userName = GetValidInput("user");
        var userPassword = GetValidInput("password");
        var name = GetValidName();
        var address = GetValidAddress();
        var email = GetValidEmail();
        var telephone = GetValidPhone();
        var cpf = GetValidCPF();

        var userDTO = new RegisterUserDto
        {
            Login = userName,
            Password = userPassword,
            Name = name,
            Address = address,
            Email = email,
            Telephone = telephone,
            Cpf = cpf
        };

        if (type == "Doctor")
        {
            userDTO.CRMorCOREN = GetValidCRMOrCOREN();
            userDTO.MedicalServiceArea = GetValidMedicalServiceArea();
        }

        return userDTO;
    }

    private bool ConfirmUserDetails(RegisterUserDto userDTO)
    {
        RenderConfirmationPage(userDTO);
        Console.Write("> Confirm your data? If not, you will be redirected to the Login menu [Y/N]: ");
        string? confirm;
        confirm = Console.ReadLine();

        while (!(confirm == "Y" || confirm == "y" || confirm == "N" || confirm == "n"))
        {
            RenderConfirmationPage(userDTO);
            Console.WriteLine("> Confirm your data? If not, you will be redirected to the Login menu [Y/N]: ");
            Console.Write("> Invalid option. Please type Y or N: ");
            confirm = Console.ReadLine();
        }

        return confirm == "Y" || confirm == "y";
    }

    private void UpdateUserInfo(string info, RegisterUserDto currentCredentials)
    {
        switch (info)
        {
            case "Name":
                currentCredentials.Name = GetValidName();
                break;
            case "Email":
                currentCredentials.Email = GetValidEmail();
                break;
            case "Address":
                currentCredentials.Address = GetValidAddress();
                break;
            case "Telephone":
                currentCredentials.Telephone = GetValidPhone();
                break;
            case "UserName":
                currentCredentials.Login = GetValidInput("new user", "Input", "Edit Profile");
                break;
            case "Password":
                currentCredentials.Password = GetValidInput("new password", "Input", "Edit Profile");
                break;
        }
    }

    private void RenderSignupPage(string title, string subtitle, string[] options = null)
    {
        Console.Clear();
        var border = new string('=', Console.WindowWidth - 1);

        Console.WriteLine(border);
        Console.WriteLine($"|| {title}");
        Console.WriteLine(border);
        Console.WriteLine();
        Console.WriteLine($"=> {subtitle}");
        Console.WriteLine();

        if (options != null)
        {
            foreach (var option in options)
            {
                Console.WriteLine(option);
                Console.WriteLine();
            }
        }

        Console.WriteLine(border);
        Console.Write("> Input: ");
    }

    private void RenderConfirmationPage(RegisterUserDto userDTO)
    {
        Console.Clear();
        var border = new string('=', Console.WindowWidth - 1);

        Console.WriteLine(border);
        Console.WriteLine("|| Sign Up Page");
        Console.WriteLine(border);
        Console.WriteLine();
        Console.WriteLine("=> Confirm your data:");
        Console.WriteLine();
        Console.WriteLine($"Name: {userDTO.Name}");
        Console.WriteLine();
        Console.WriteLine($"Address: {userDTO.Address}");
        Console.WriteLine();
        Console.WriteLine($"Email: {userDTO.Email}");
        Console.WriteLine();
        Console.WriteLine($"Phone: {userDTO.Telephone}");
        Console.WriteLine();
        Console.WriteLine($"CPF: {userDTO.Cpf}");
        Console.WriteLine();
        if (userDTO.CRMorCOREN != null)
        {
            Console.WriteLine($"CRM or COREN: {userDTO.CRMorCOREN}");
        Console.WriteLine();
            Console.WriteLine($"Medical Service Area: {userDTO.MedicalServiceArea}");
        Console.WriteLine();
        }
        Console.WriteLine(border);
    }

    private string GetValidInput(string arg, string input = "Input", string title = "Login Page")
    {
        RenderInputPage(arg, input, title);
        string? userInput = Console.ReadLine();

        while (userInput == null || userInput.Length < 8 || userInput.Length > 16)
        {
            RenderInputPage(arg, "Please type a valid " + arg, title);
            userInput = Console.ReadLine();
        }

        return userInput;
    }

    private void RenderInputPage(string text, string input, string title)
    {
        Console.Clear();
        var border = new string('=', Console.WindowWidth - 1);

        Console.WriteLine(border);
        Console.WriteLine($"|| {title}");
        Console.WriteLine(border);
        Console.WriteLine();
        Console.WriteLine($"=> Type your {text}");
        Console.WriteLine();
        Console.WriteLine("=> Minimum 8 characters");
        Console.WriteLine();
        Console.WriteLine("=> Maximum 16 characters");
        Console.WriteLine();
        Console.WriteLine(border);
        Console.Write($"> {input}: ");
    }

    private MedicalServiceArea GetValidMedicalServiceArea()
{
    DisplayMedicalServiceAreas();
    Console.Write("> Medical Service Area: ");
    if (!int.TryParse(Console.ReadLine(), out int option) || option < 1 || option > Enum.GetValues(typeof(MedicalServiceArea)).Length)
    {
        while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > Enum.GetValues(typeof(MedicalServiceArea)).Length)
        {
            DisplayMedicalServiceAreas();
            Console.Write("> Type a valid Medical Service Area: ");
        }
    }
    return (MedicalServiceArea)Enum.GetValues(typeof(MedicalServiceArea)).GetValue(option - 1);
}

private void DisplayMedicalServiceAreas()
{
    Console.Clear();
    var border = new string('=', Console.WindowWidth - 1);
    Console.WriteLine(border);
    Console.WriteLine($"|| Sign Up Page");
    Console.WriteLine(border);
    Console.WriteLine();
    Console.WriteLine($"=> Select Medical Service Area:");
    Console.WriteLine();
    var values = Enum.GetValues(typeof(MedicalServiceArea));
    foreach (var value in values)
    {
        Console.WriteLine($"[{(int)value + 1}] {value}");
        Console.WriteLine();
    }
    Console.WriteLine(border);
}

    private string GetValidCRMOrCOREN()
    {
        RenderSignupPage("Sign Up Page", "CRM or COREN");

        string registration;

        while (true)
        {
            registration = Console.ReadLine();
            var cleanRegistration = new string(registration.Where(char.IsLetterOrDigit).ToArray());

            if (cleanRegistration.Length >= 5 && cleanRegistration.Length <= 10)
                break;

            RenderSignupPage("Sign Up Page", "Please type a valid CRM or COREN");
        }

        return registration;
    }

    private string GetValidCPF()
    {
        RenderSignupPage("Sign Up Page", "CPF");

        string cpf;

        while (true)
        {
            cpf = Console.ReadLine();
            var cleanCPF = new string(cpf.Where(char.IsDigit).ToArray());

            if (cleanCPF.Length == 11)
                break;

            RenderSignupPage("Sign Up Page", "Please type a valid CPF");
        }

        return cpf;
    }

    private string GetValidPhone()
    {
        RenderSignupPage("Sign Up Page", "Phone");

        string phone;
        var phoneRegex = new Regex(@"^\+?(\d{1,3})?[-. ]?(\(\d{1,3}\)|\d{1,3})[-. ]?\d{1,4}[-. ]?\d{1,4}[-. ]?\d{1,9}$");

        while (true)
        {
            phone = Console.ReadLine();
            if (phoneRegex.IsMatch(phone))
                break;

            RenderSignupPage("Sign Up Page", "Please type a valid phone number");
        }

        return phone;
    }

    private string GetValidEmail()
    {
        RenderSignupPage("Sign Up Page", "Email");

        string email;
        var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        while (true)
        {
            email = Console.ReadLine();
            if (emailRegex.IsMatch(email))
                break;

            RenderSignupPage("Sign Up Page", "Please type a valid email address");
        }

        return email;
    }

    private string GetValidAddress()
    {
        RenderSignupPage("Sign Up Page", "Address");

        string address;

        while (true)
        {
            address = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(address) && address.Length >= 10 && address.Length <= 100)
                break;

            RenderSignupPage("Sign Up Page", "Please type a valid address");
        }

        return address;
    }

    private string GetValidName()
    {
        RenderSignupPage("Sign Up Page", "Name");

        string name;

        while (true)
        {
            name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name) && name.Length >= 10 && name.Length <= 30)
                break;

            RenderSignupPage("Sign Up Page", "Please type a valid name");
        }

        return name;
    }
}
