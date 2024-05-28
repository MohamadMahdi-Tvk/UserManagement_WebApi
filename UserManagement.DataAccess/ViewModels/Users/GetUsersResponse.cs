namespace UserManagement.DataAccess.ViewModels.Users;

public record GetUsersResponse(string firstName, string lastName, DateTime insertedDate, string userName, string password);

