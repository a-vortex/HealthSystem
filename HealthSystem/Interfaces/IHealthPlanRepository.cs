public interface IHealthPlanRepository
{
    HealthPlan GetById(int id);
    IEnumerable<HealthPlan> GetAll();
}