public class HealthPlan
{
    public int PlanId { get; private set; }
    public string? Name { get; private set; } 
    public float? Price { get; private set; }
    public string? Description { get; private set; }
    public List<MedicalServices> Coverages { get; private set; } = [];
    public HealthPlan() {}
    public HealthPlan(string name, float price, string description)
    {
        Name = name;
        Price = price;
        Description = description;
    }
    public void AddCoverages(MedicalServices medicalService){
        Coverages.Add(medicalService);
    }
}