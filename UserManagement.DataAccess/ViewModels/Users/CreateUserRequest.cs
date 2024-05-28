namespace UserManagement.DataAccess.ViewModels.Users;

public record CreateUserRequest(string FirstName,string LastName,string UserName,string Password);