public class Customer(string login, string password) : User(login, password)
{
    public HealthPlan? HealthPlan {get;set;}
}