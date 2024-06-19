using HealthSystem.Models.Users; 

public interface IUserRepository
{
    User GetByLogin(string email);
    User GetByCPF(string cpf);
    Doctor GetByCOREN(string coren);
    bool Update(User user);
    void Add(User user);
}
