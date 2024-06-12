public class Signup : IMenu
{
    public Signup()
    {
        _title = "Sign Up";
        _options.Add("[1] Enter");
        _options.Add("[2] Back");
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