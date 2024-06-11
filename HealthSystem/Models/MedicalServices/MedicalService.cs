public class MedicalService
{
    public int MedicalServiceId { get; private set; }
    public string? Name { get; private set; }
    public float Price { get; private set; }
    public string? Description { get; private set; }
    public MedicalServiceType Type { get; private set; }
    public MedicalServiceArea Area { get; private set; }

    public MedicalService() { }
    public MedicalService(string name, float price, string description, 
    MedicalServiceType medicalServiceType, MedicalServiceArea medicalServiceArea)
    {
        Name = name;
        Price = price;
        Description = description;
        Type = medicalServiceType;
        Area = medicalServiceArea;
    }
}
