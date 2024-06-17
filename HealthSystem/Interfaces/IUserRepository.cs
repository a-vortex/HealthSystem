using HealthSystem.Models.Users; 

public interface IUserRepository
{
    User GetByLogin(string email);
    void Add(User user);
}
