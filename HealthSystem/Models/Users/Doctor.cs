namespace HealthSystem.Models.Users;
using System.ComponentModel.DataAnnotations;

public class Doctor : User
{
    [Required]
    public string? CRMorCOREN { get; set; }
    [Required]
    public MedicalServiceArea MedicalServiceArea { get; set; }

    public Doctor() : base() { }
    public Doctor(string login, string password, string name, string address, string email, int telephone, int cpf, 
    string crmorcoren, MedicalServiceArea medicalServiceArea) : 
    base(login, password,  name, address, email, telephone, cpf)
    {
        CRMorCOREN = crmorcoren;
        MedicalServiceArea = medicalServiceArea;
    }
}