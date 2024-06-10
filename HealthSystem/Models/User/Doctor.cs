namespace HealthSystem.Models.User;

public class Doctor(string login, string password, string name, string address, string email, int telephone, string crm, string specialty) : 
User(login, password, name, address, email, telephone)
{
    readonly string CRM = crm;
    readonly string Specialty = specialty;
}