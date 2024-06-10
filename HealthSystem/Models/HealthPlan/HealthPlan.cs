public class HealthPlan(string name, float price, string description)
{
    public int PlanId { get; private set; }
    public string Name { get; private set; } = name;
    public float Price { get; private set; } = price;
    public string Description { get; private set; } = description;
    public List<MedicalServices> Coverages { get; private set; } = new List<MedicalServices>();
    public void AddCoverages(MedicalServices medicalService){
        Coverages.Add(medicalService);
    }
}
