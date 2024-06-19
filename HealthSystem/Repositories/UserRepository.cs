using HealthSystem.Data;
using HealthSystem.Models.Users;
using System.Diagnostics.CodeAnalysis;

public class UserRepository : IUserRepository
{
    private readonly HealthSystemDbContext _context;

    public UserRepository(HealthSystemDbContext context)
    {
        _context = context;
    }

    [return: NotNull]
    #pragma warning disable CS8603 
    public User GetByLogin(string login)
    {
        return _context.Users.SingleOrDefault(u => u.Login == login);
    }
    public User GetByCPF(string cpf)
    {
        return _context.Users.SingleOrDefault(u => u.PersonalInfo.Cpf == cpf);
    }
    public Doctor GetByCOREN(string coren)
    {
        return _context.Doctors.SingleOrDefault(u => u.CRMorCOREN == coren);
    }
    #pragma warning restore CS8603

    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
    public bool Update(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
        return true;
    }
}
