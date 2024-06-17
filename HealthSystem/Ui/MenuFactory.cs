public class MenuFactory : IMenuFactory
{
    private readonly IUserController _userController;

    public MenuFactory(IUserController userController)
    {
        _userController = userController;
    }

    public IMenu CreateMenu(string menuType, string message = "")
    {
        return menuType switch
        {
            "CustomerInicialPage" => new CustomerInicialPage(),
            "InicialPage" => new InicialPage(this, message),
            "Login" => new Login(_userController, this, message),
            _ => throw new ArgumentException("Invalid menu type", nameof(menuType)),
        };
    }
}