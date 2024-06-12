public class Login : IMenu
{
    public Login()
    {
        _title = "Login";
        inputstr = "> Input: ";
        _options.Add("=> Type your user");
    }
    public override IMenu MenuNext(int option)
    {
        InicialPage inicialPage = new();
        switch(option)
        {
            case 1:
                return inicialPage;
            case 2:
                return inicialPage;
            default:
                return inicialPage;
        }

    }
}