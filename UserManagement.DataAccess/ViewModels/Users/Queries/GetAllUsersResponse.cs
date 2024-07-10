namespace UserManagement.DataAccess.ViewModels.Users.Queries;

public record GetAllUsersResponse(int Id, string FirstName, string LastName, string UserName, DateTime InsertDate, bool IsDeleted, string Title);

