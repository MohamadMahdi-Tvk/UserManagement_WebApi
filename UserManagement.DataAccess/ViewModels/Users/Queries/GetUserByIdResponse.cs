namespace UserManagement.DataAccess.ViewModels.Users.Queries;

public record GetUserByIdResponse(string FirstName, string LastName, string UserName, string Password);
