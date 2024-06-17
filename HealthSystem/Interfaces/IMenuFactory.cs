public interface IMenuFactory
{
    IMenu CreateMenu(string menuType, string message = "");
}
