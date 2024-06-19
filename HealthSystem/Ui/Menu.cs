using System;
using System.Diagnostics;

public abstract class IMenu
{
    protected string _title = "Title";
    protected string inputstr = "Option";
    protected List<string> _options = new List<string>();
    private readonly bool _isDebugMode = Debugger.IsAttached;

    public virtual void Tentativa()
    {
    }
    public abstract IMenu? MenuNext(int option);
    public void Render(string text){
        this.BaseRender();
        Console.Write("> "+text+": ");
    }
    public void Render()
    {
        this.BaseRender();
        Console.Write("> "+inputstr+": ");
        this.Tentativa();
    }

    protected void BaseRender()
    {
        ClearConsole();
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
    private void ClearConsole()
    {
        // Só chama Console.Clear() se não estivermos em modo de depuração
        if (!_isDebugMode)
        {
            try
            {
                Console.Clear();
            }
            catch (IOException)
            {
                // Se ocorrer uma exceção, simplesmente ignore e continue
            }
        }
    }
}
