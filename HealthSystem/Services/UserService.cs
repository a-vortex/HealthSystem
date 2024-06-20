using HealthSystem.Models.Users;
using System.Diagnostics.CodeAnalysis; // Add this using directive

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    private readonly IHealthPlanRepository _healthPlanRepository;

    public UserService(IUserRepository userRepository, IHealthPlanRepository healthPlanRepository)
    {
        _userRepository = userRepository;
        _healthPlanRepository = healthPlanRepository;
    }

    [return: NotNull]
#pragma warning disable CS8604
    public bool Login(UserDto userDto)
    {
        var user = _userRepository.GetByLogin(userDto.Login);

        if (user != null && VerifyPassword(user.Password, userDto.Password))
        {
            return true;
        }
        return false;
    }
#pragma warning restore CS8604
    public RegisterUserDto GetByLogin(string login)
    {
#pragma warning disable
        var type = GetUserType(login);
        if (type == "Doctor")
        {
            var doctor = (Doctor)_userRepository.GetByLogin(login);
            return new RegisterUserDto
            {
                Login = doctor.Login,
                Password = doctor.Password,
                Name = doctor.PersonalInfo.Name,
                Address = doctor.PersonalInfo.Address,
                Email = doctor.PersonalInfo.Email,
                Telephone = doctor.PersonalInfo.Telephone,
                Cpf = doctor.PersonalInfo.Cpf,
                CRMorCOREN = doctor.CRMorCOREN,
                MedicalServiceArea = doctor.MedicalServiceArea
            };
        }
        else
        {
            var customer = (Customer)_userRepository.GetByLogin(login);
            var healthPlan = customer.HealthPlanId.HasValue ? _healthPlanRepository.GetById(customer.HealthPlanId.Value) : null;
            return new RegisterUserDto
            {
                Login = customer.Login,
                Password = customer.Password,
                Name = customer.PersonalInfo.Name,
                Address = customer.PersonalInfo.Address,
                Email = customer.PersonalInfo.Email,
                Telephone = customer.PersonalInfo.Telephone,
                Cpf = customer.PersonalInfo.Cpf,
                HealthPlanId = customer.HealthPlanId,
                HealthPlan = healthPlan
            };
        }
#pragma warning restore
    }

    //=======================================================================================================
    public void RegisterUser(RegisterUserDto userDto, string type)
    {
#pragma warning disable
        if (_userRepository.GetByLogin(userDto.Login) != null)
        {
            throw new ArgumentException("An User with this UserName already exists");
        }
        if (_userRepository.GetByCPF(userDto.Cpf) != null)
        {
            throw new ArgumentException("User with the same CPF already exists");
        }
        if (type == "Doctor")
        {
            if (_userRepository.GetByCOREN(userDto.CRMorCOREN) != null)
            {
                throw new ArgumentException("User with the same CRM or COREN already exists");
            }

            var doctor = new Doctor
            {
                Login = userDto.Login,
                Password = HashPassword(userDto.Password),
                PersonalInfo = new User.Personal
                {
                    Name = userDto.Name,
                    Address = userDto.Address,
                    Email = userDto.Email,
                    Telephone = userDto.Telephone,
                    Cpf = userDto.Cpf
                },
                CRMorCOREN = userDto.CRMorCOREN,
                MedicalServiceArea = userDto.MedicalServiceArea ?? throw new ArgumentException("Medical Service Area is required")
            };
            _userRepository.Add(doctor);
        }
        else if (type == "Customer")
        {
            var customer = new Customer
            {
                Login = userDto.Login,
                Password = HashPassword(userDto.Password),
                PersonalInfo = new User.Personal
                {
                    Name = userDto.Name,
                    Address = userDto.Address,
                    Email = userDto.Email,
                    Telephone = userDto.Telephone,
                    Cpf = userDto.Cpf
                },
                HealthPlanId = null
            };
            _userRepository.Add(customer);
        }
        else
        {
            throw new ArgumentException("Invalid user type");
        }
#pragma warning restore
    }
    //=======================================================================================================
    public bool EditUser(RegisterUserDto editUserDto, UserDto userDto, out string error)
    {
#pragma warning disable
        var user = _userRepository.GetByLogin(userDto.Login);
        if (user == null)
        {
            error = "User not found";
            return false; // Usuário não encontrado
        }
        else if (_userRepository.GetByLogin(editUserDto.Login) != null)
        {
            error = "An User with this UserName already exists";
            return false; // Login já cadastrado
        }
        user.PersonalInfo.Name = editUserDto.Name;
        user.PersonalInfo.Address = editUserDto.Address;
        user.PersonalInfo.Email = editUserDto.Email;
        user.PersonalInfo.Telephone = editUserDto.Telephone;
        user.Password = editUserDto.Password;
        user.Login = editUserDto.Login ?? userDto.Login;

        var result = _userRepository.Update(user);
        error = result ? "" : "Error updating user";
        return result;
#pragma warning restore
    }
    //=======================================================================================================
    public string GetUserType(string login)
    {
        var user = _userRepository.GetByLogin(login);
        if (user is Doctor)
        {
            return "Doctor";
        }
        else if (user is Customer)
        {
            return "Customer";
        }
        else
        {
            throw new ArgumentException("Invalid user type");
        }
    }

    private bool VerifyPassword(string storedPassword, string enteredPassword)
    {
        // Implemente a lógica de verificação de senha com hashing seguro aqui
        return storedPassword == enteredPassword;
    }

    private string HashPassword(string password)
    {
        // Implemente a lógica de hashing de senha segura aqui
        return password; // Exemplo simplificado (não use isso em produção)
    }
}
