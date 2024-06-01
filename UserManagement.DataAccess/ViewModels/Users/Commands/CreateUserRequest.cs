namespace UserManagement.DataAccess.ViewModels.Users.Commands;

public record CreateUserRequest(string FirstName, string LastName, string UserName, string Password);