namespace UserManagement.DataAccess.ViewModels.Posts.Commands;

public record CreatePostRequest(string Title, string Description, int UserId);
