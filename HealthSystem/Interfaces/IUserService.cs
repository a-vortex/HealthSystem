public interface IUserService
{
    //Continua a lógica de login
    //Retorna true se o login foi feito com sucesso
    //userDto: Dto do usuário a ser logado
    bool Login(UserDto userDto);

    //Continua a lógica de cadastro de usuário
    //userDto: Dto do usuário a ser cadastrado
    //type: tipo de usuário a ser cadastrado
    void RegisterUser(RegisterUserDto userDto, string type);

    //Retorna um usuário do repositório pelo login
    //username: Login do usuário
    RegisterUserDto GetByLogin(string userName);

    //Retorna o tipo de usuário pelo login
    //login: Login do usuário
    string GetUserType(string login);

    //Continua a lógica de edição de usuário
    //userDto: Dto do usuário a ser editado
    //currentUser: Dto do usuário atual
    //error: Mensagem de erro
    bool EditUser(RegisterUserDto userDto, UserDto currentUser, out string error);
}