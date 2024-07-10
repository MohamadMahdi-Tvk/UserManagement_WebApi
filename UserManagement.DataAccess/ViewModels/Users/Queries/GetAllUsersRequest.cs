namespace UserManagement.DataAccess.ViewModels.Users.Queries;

public record GetAllUsersRequest(int PageNumber, int PageSize, string Query);

