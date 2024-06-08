namespace UserManagement.DataAccess.ViewModels.Users.Queries;

public record UsersRequest(int PageNumber, int PageSize, string Query);

