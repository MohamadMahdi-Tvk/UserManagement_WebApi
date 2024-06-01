namespace UserManagement.DataAccess.ViewModels.Users.Commands;

public record UpdateUserRequest(int id, string firstName, string lastName, string userName, string Password);
