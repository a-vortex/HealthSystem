using HealthSystem.Models.Users;

public class UserSessionService : IUserSessionService
{
    public RegisterUserDto CurrentUser { get; private set; }

    public string GetUserType()
    {
        if (CurrentUser.MedicalServiceArea == null)
        {
            return "Customer";
        }
        else
        {
            return "Doctor";
        }
    }

    public void SetCurrentUser(RegisterUserDto user)
    {
        CurrentUser = user;
    }

    public void ClearCurrentUser()
    {
        CurrentUser = null;
    }
}