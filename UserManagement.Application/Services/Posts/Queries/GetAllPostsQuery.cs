using MediatR;
using UserManagement.DataAccess.ViewModels.Posts.Queries;

namespace UserManagement.Application.Services.Posts.Queries;

public record GetAllPostsQuery(GetAllPostsRequest Query, CancellationToken CancellationToken): IRequest<Paginated<GetAllPostsResponse>>;
