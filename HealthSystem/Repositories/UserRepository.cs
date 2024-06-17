using HealthSystem.Data;
using HealthSystem.Models.Users;

public class UserRepository : IUserRepository
{
    private readonly HealthSystemDbContext _context;

    public UserRepository(HealthSystemDbContext context)
    {
        _context = context;
    }

    public User GetByLogin(string login)
    {
        return _context.Users.SingleOrDefault(u => u.Login == login);
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
}
