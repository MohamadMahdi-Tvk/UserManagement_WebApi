using MediatR;
using UserManagement.DataAccess.ViewModels.Users.Queries;

namespace UserManagement.Application.Services.Users.Queries;

public record GetUserByIdQuery(GetUserByIdRequest Query, CancellationToken CancellationToken) : IRequest<GetUserByIdResponse>;

