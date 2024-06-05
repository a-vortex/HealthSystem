abstract class HealthPlan 
{
    protected int PlanId { get; private set; }
    protected string Name { get; private set; }
    protected float Price { get; private set; }

    protected HealthPlan(string name, float price)
    {
        this.Name = name;
        this.Price = price; 
    }

    public abstract string Description();
}
