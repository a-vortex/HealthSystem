public class HealthPlan 
{
    protected int PlanId { get; private set; }
    protected string Name { get; private set; }
    protected float Price { get; private set; }
    protected string Description { get; private set; }

    protected HealthPlan(string name, float price, string description)
    {
        this.Name = name;
        this.Price = price; 
        this.Description = description;
    }
}
