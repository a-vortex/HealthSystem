using HealthSystem.Tools;

InicialPage inicialPage = new();
string? option;
inicialPage.Render();
//FAZER TRATAMENTO DE ENTRADA
option = Console.ReadLine() ?? "5";
int? optionInt = IntValidator.Validate(option);
IMenu? amenu = inicialPage.MenuNext(optionInt ?? 5);

while(amenu != null)
{
    amenu.Render();
    option = Console.ReadLine() ?? "5";
    //FAZER TRATAMENTO DE ENTRADA
    optionInt = IntValidator.Validate(option);
    amenu = amenu.MenuNext(optionInt ?? 5);
} // Esse loop é o que faz o menu funcionar, favor nao remover


InicialPage.Exit();
Console.ReadKey();
Console.Clear();