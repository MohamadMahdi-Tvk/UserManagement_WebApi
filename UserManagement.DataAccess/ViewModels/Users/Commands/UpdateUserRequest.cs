namespace UserManagement.DataAccess.ViewModels.Users.Commands;

public record UpdateUserRequest(int Id, string FirstName, string LastName, string UserName, string Password);
