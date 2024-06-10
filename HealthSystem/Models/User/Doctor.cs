namespace HealthSystem.Models.User;

public class Doctor : User
{
    readonly string? CRM;
    readonly string? Specialty;

    public Doctor() : base() { }
    public Doctor(string login, string password, Personal personalInfo, string name, string address, string email, int telephone, string crm, string specialty) : 
    base(login, password, personalInfo, name, address, email, telephone)
    {
        CRM = crm;
        Specialty = specialty;
    }
}