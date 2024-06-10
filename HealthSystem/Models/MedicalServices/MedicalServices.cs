public class MedicalServices(string name, float price, string description)
{
    public int MedicalServiceId { get; private set; }
    public string Name { get; private set; } = name;
    public float Price { get; private set; } = price;
	public string Description { get; private set; } = description;
}