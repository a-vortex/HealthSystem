namespace HealthSystem.Models.User;

public class Customer : User
{
    public HealthPlan HealthPlan {get;private set;} = new HealthPlan();

    public Customer() : base() { }
    public Customer(string login, string password, Personal personalInfo, string name, string address, string email, int telephone) :
    base(login, password, personalInfo, name, address, email, telephone) { }
    public void SetHealthPlan(HealthPlan healthPlan) => HealthPlan = healthPlan;
}