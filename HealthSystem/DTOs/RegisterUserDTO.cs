#pragma warning disable CS8618 

public class RegisterUserDto
{
    public string? Login { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Telephone { get; set; }
    public string Cpf { get; set; }

    public string? CRMorCOREN { get; set; }
    public MedicalServiceArea? MedicalServiceArea { get; set; }

    public int? HealthPlanId { get; set; }
    public HealthPlan? HealthPlan { get; set; }
}
