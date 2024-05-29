namespace UserManagement.DataAccess.ViewModels.Users;

public record UpdateUserResponse(int id, string firstName, string lastName, string userName, string Password);
