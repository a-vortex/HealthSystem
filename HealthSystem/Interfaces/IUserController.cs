public interface IUserController
{
    bool Login(out int? type);
    bool SignUp();
    bool EditUser(string info, out string error);
}