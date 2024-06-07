abstract class HealthPlan(string name, float price)
{
    protected int PlanId { get; private set; }
    protected string Name { get; private set; } = name;
    protected float Price { get; private set; } = price;
    protected List<MedicalServices>? Coverages { get; private set; } = null;

    public abstract string Description();
}
