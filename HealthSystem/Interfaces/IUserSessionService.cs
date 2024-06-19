using HealthSystem.Models.Users;

public interface IUserSessionService
{
    RegisterUserDto CurrentUser { get; }
    string GetUserType();
    void SetCurrentUser(RegisterUserDto user);
    void ClearCurrentUser();
}