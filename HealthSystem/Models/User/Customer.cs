namespace HealthSystem.Models.User;

public class Customer : User
{
    public HealthPlan HealthPlan {get;private set;} = new HealthPlan();
    public int HealthPlanId { get; private set; } //Foreign Key

    public Customer() : base() => HealthPlanId = HealthPlan.PlanId;
    public Customer(string login, string password, Personal personalInfo, string name, string address, string email, int telephone) :
    base(login, password, personalInfo, name, address, email, telephone) => HealthPlanId = HealthPlan.PlanId;
    public void SetHealthPlan(HealthPlan healthPlan) 
    {
        HealthPlan = healthPlan;
        HealthPlanId = healthPlan.PlanId;
    }
}