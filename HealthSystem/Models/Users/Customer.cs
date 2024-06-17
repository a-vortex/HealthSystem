namespace HealthSystem.Models.Users;

public class Customer : User
{
    public HealthPlan? HealthPlan { get; private set; } = null;
    public int HealthPlanId { get; private set; } //Foreign Key

    public Customer() : base(){}
    public Customer(string login, string password, string name, string address, string email, int telephone, int cpf) :
    base(login, password, name, address, email, telephone, cpf){}
    public void SetHealthPlan(HealthPlan healthPlan)
    {
        HealthPlan = healthPlan;
        HealthPlanId = healthPlan.PlanId;
    }
}