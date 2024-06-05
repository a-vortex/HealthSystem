class Customer(string login, string password) : User(login, password)
{
    private HealthPlan? healthPlan = null;

    public HealthPlan? GetHealthPlan() => healthPlan;
    public void ChangeHealthPlan(HealthPlan NewHealthPlan) => this.healthPlan = NewHealthPlan;
}