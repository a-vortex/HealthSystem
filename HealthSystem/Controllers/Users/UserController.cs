public class UserController : IUserController
{
    readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    public bool Login()
    {
        var userName = GetValidInputs("user");
        var UserPassword = GetValidInputs("password");

        var loginResult = _userService.Login(userName, UserPassword);
        return loginResult;
    }
    private string GetValidInputs(string arg){
        this.BaseRender(arg);
        string? userInput = Console.ReadLine();
        while(userInput == null || userInput.Length < 8){
            this.BaseRender(arg, "Please type a valid "+arg);
            userInput = Console.ReadLine();
        }
        return userInput;
    }

    protected void BaseRender(string text, string input ="Input")
    {
        Console.Clear();
        int windowWidth = Console.WindowWidth;
        string border = new('=', windowWidth - 1);
        Console.WriteLine("|| " + "Login Page");
        Console.WriteLine(border);
        Console.WriteLine();
        Console.WriteLine("=> Type your "+ text);
        Console.WriteLine();
        Console.WriteLine("=> Minimum 8 characters");
        Console.WriteLine();
        Console.WriteLine(border);
        Console.Write("> "+input+": ");
    }
}

