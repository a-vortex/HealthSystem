using Microsoft.Extensions.DependencyInjection;
using HealthSystem.Data;
using HealthSystem.Tools;
using HealthSystem.Models.Users;

var serviceProvider = new ServiceCollection()
    .AddSingleton<HealthSystemDbContext>()
    .AddSingleton<IUserRepository, UserRepository>()
    .AddSingleton<IHealthPlanRepository, HealthPlanRepository>()
    .AddSingleton<IUserService, UserService>()
    .AddSingleton<IUserController, UserController>()
    .AddSingleton<IMenuFactory, MenuFactory>()
    .AddSingleton<IUserSessionService, UserSessionService>()
    .BuildServiceProvider();

var userController = serviceProvider.GetService<IUserController>();
var userSessionService = serviceProvider.GetService<IUserSessionService>();
var menuFactory = serviceProvider.GetService<IMenuFactory>();

InicialPage inicialPage = new(menuFactory);
int? optionInt;
string option = "";
IMenu? amenu = inicialPage;
do
{
    amenu.Render();
    option = Console.ReadLine() ?? "0";
    optionInt = IntValidator.Validate(option);
    amenu = amenu.MenuNext(optionInt ?? 0);
} while(amenu != null);

InicialPage.Exit();
Console.ReadKey();
Console.Clear();