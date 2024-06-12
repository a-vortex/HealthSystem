public abstract class IMenu
{
    protected string _title = "Title";
    protected string inputstr = "> Option: ";
    protected List<string> _options = new List<string>();

    public abstract IMenu? MenuNext(int option);
    public void Render(){
        Console.Clear();
        string border = new('=', _title.Length + 30);
        Console.WriteLine(border);
        Console.WriteLine("|| " + _title);
        Console.WriteLine(border);
        Console.WriteLine();

        foreach (string opt in _options)
        {
            Console.WriteLine(opt);
            Console.WriteLine();
        }

        Console.WriteLine(border);
        Console.Write(inputstr);
    }

}
