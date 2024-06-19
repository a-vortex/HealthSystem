public interface IUserService
{
    bool Login(UserDto userDto);
    void RegisterUser(RegisterUserDto userDto, string type);
    RegisterUserDto GetByLogin(string userName);
    string GetUserType(string login);
    bool EditUser(RegisterUserDto userDto,UserDto currentUser,out string error);
}