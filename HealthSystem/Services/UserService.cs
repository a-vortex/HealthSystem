using HealthSystem.Models.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public bool Login(string username, string password)
    {
        var user = _userRepository.GetByLogin(username);

        if (user != null && VerifyPassword(user.Password, password))
        {
            return true;
        }

        return false;
    }

    private bool VerifyPassword(string storedPassword, string enteredPassword)
    {
        // Implemente a lógica de verificação de senha com hashing seguro aqui
        return storedPassword == enteredPassword;
    }

    // public void RegisterUser(UserDto userDto)
    // {
    //     var user = new User
    //     {
    //         Name = userDto.Name,
    //         Email = userDto.Email,
    //         Password = HashPassword(userDto.Password),
    //     };

    //     _userRepository.Add(user);
    // }

    private string HashPassword(string password)
    {
        // Implemente a lógica de hashing de senha segura aqui
        return password; // Exemplo simplificado (não use isso em produção)
    }
}
