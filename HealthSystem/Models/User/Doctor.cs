namespace HealthSystem.Models.User;

public class Doctor(string login, string password, string name, string address, string email, int telephone) : 
User(login, password, name, address, email, telephone)
{

}