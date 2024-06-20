using HealthSystem.Models.Users;

public interface IUserSessionService
{
    //Retorna o usuário logado
    RegisterUserDto CurrentUser
    {
        get;
    }

    //Retorna o tipo de usuário logado
    string GetUserType();

    //Define o usuário logado
    //user: Usuário a ser logado
    void SetCurrentUser(RegisterUserDto user);

    //Limpa o usuário logado
    void ClearCurrentUser();
}