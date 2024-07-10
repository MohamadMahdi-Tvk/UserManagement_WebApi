namespace UserManagement.DataAccess.ViewModels.Posts.Queries;

public record GetAllPostsRequest(int PageNumber, int PageSize, string Query);
