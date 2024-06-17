public class CustomerInicialPage : IMenu
{
    public CustomerInicialPage()
    {
        _title = "Customer Page";
        _options.Add("1. Register");
        _options.Add("2. Login");
        _options.Add("3. Exit");
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
                return null;
            default:
                return this;
        }
    }
}