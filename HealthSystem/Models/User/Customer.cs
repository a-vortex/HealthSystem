namespace HealthSystem.Models.User;

public class Customer(string login, string password, string name, string address, string email, int telephone) :
User(login, password, name, address, email, telephone)
{
    public HealthPlan? HealthPlan {get;set;}
}