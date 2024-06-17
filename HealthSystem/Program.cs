using Microsoft.Extensions.DependencyInjection;
using HealthSystem.Data;
using HealthSystem.Tools;

var serviceProvider = new ServiceCollection()
            .AddSingleton<HealthSystemDbContext>()
            .AddSingleton<IUserRepository, UserRepository>()
            .AddSingleton<IUserService, UserService>()
            .AddSingleton<IUserController, UserController>()
            .AddSingleton<IMenuFactory, MenuFactory>()
            .BuildServiceProvider();

var userController = serviceProvider.GetService<IUserController>();
var menuFactory = serviceProvider.GetService<IMenuFactory>();

InicialPage inicialPage = new(menuFactory);
int? optionInt;
string option = "";
IMenu? amenu = inicialPage;
do
{
    amenu.Render();
    option = Console.ReadLine() ?? "0";
    //FAZER TRATAMENTO DE ENTRADA
    optionInt = IntValidator.Validate(option);
    amenu = amenu.MenuNext(optionInt ?? 0);
} while(amenu != null);

InicialPage.Exit();
Console.ReadKey();
Console.Clear();