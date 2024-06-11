﻿public class HealthPlan
{
    public int PlanId { get; private set; }
    public string? Name { get; private set; } 
    public float? Price { get; private set; }
    public string? Description { get; private set; }
    public List<MedicalServiceType> Coverages { get; private set; } = [];

    public HealthPlan() {}
    public HealthPlan(string name, float price, string description)
    {
        Name = name;
        Price = price;
        Description = description;
    }
    
    public void AddCoverages(MedicalServiceType medicalService){
        Coverages.Add(medicalService);
    }
    public void RemoveCoverages(MedicalServiceType medicalService){
        Coverages.Remove(medicalService);
    }
}