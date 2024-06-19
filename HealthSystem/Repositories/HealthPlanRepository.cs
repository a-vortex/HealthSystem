using HealthSystem.Data;

public class HealthPlanRepository : IHealthPlanRepository
{
    private readonly HealthSystemDbContext _context;

    public HealthPlanRepository(HealthSystemDbContext context)
    {
        _context = context;
    }

    public HealthPlan GetById(int id)
    {
        return new HealthPlan();
    }
    public IEnumerable<HealthPlan> GetAll()
    {
        return new List<HealthPlan>();
    }
}