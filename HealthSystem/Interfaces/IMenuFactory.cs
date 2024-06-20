public interface IMenuFactory
{
    //Retorna um menu de acordo com o tipo de menu
    //menuType: tipo de menu a ser criado
    //message: mensagem a ser exibida no menu
    IMenu CreateMenu(string menuType, string message = "");
}
