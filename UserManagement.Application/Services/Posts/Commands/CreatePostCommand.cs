using MediatR;
using UserManagement.DataAccess.ViewModels.Posts.Commands;

namespace UserManagement.Application.Services.Posts.Commands;

public record CreatePostCommand(CreatePostRequest Command, CancellationToken CancellationToken) : IRequest<CreatePostResponse>;
