using System.ComponentModel.DataAnnotations;

namespace HealthSystem.Models.User;

public class Doctor : User
{
    [Required]
    public string? CRMorCOREN { get; set; }
    [Required]
    public MedicalServiceArea MedicalServiceArea { get; set; }

    public Doctor() : base() { }
    public Doctor(string login, string password, Personal personalInfo, string name, string address, string email, int telephone,
    string crmorcoren, MedicalServiceArea medicalServiceArea) : 
    base(login, password, personalInfo, name, address, email, telephone)
    {
        CRMorCOREN = crmorcoren;
        MedicalServiceArea = medicalServiceArea;
    }
}