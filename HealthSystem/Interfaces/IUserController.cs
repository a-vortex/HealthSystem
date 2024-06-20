public interface IUserController
{
    //Inicia a lógica de login
    //Retorna true se o login foi feito com sucesso
    //type: tipo de usuário logado
    bool Login(out int? type);

    //Inicia a lógica de cadastro de usuário
    //Retorna true se o cadastro foi feito com sucesso
    bool SignUp();

    //Inicia a lógica de edição de usuário
    //Retorna true se a edição foi feita com sucesso
    bool EditUser(string info, out string error);
}