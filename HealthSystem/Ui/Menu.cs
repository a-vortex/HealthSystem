public abstract class IMenu
{
    protected string _title = "Title";
    protected string inputstr = "Option";
    protected List<string> _options = new List<string>();

    public virtual void Tentativa()
    {
    }
    public abstract IMenu? MenuNext(int option);
    public void Render(string text)
    {
        this.BaseRender();
        Console.Write("> " + text + ": ");
    }
    public void Render()
    {
        this.BaseRender();
        Console.Write("> " + inputstr + ": ");
        this.Tentativa();
    }

    protected void BaseRender()
    {
        Console.Clear();
        int windowWidth = Console.WindowWidth;
        string border = new('=', windowWidth - 1);
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
    }
}
