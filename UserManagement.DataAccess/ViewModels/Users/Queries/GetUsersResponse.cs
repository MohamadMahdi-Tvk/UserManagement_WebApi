namespace UserManagement.DataAccess.ViewModels.Users.Queries;

public record GetUsersResponse(string firstName, string lastName, DateTime insertedDate, string userName, string password);

