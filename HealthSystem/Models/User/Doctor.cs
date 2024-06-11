using System.ComponentModel.DataAnnotations;

namespace HealthSystem.Models.User;

public class Doctor : User
{
    [Required]
    public string? CRM { get; set; }
    [Required]
    public string? Specialty { get; set; }

    public Doctor() : base() { }
    public Doctor(string login, string password, Personal personalInfo, string name, string address, string email, int telephone, string crm, string specialty) : 
    base(login, password, personalInfo, name, address, email, telephone)
    {
        CRM = crm;
        Specialty = specialty;
    }
}