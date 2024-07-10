using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application;
using UserManagement.Application.Services.Posts.Commands;
using UserManagement.Application.Services.Posts.Queries;
using UserManagement.Controllers.Base;
using UserManagement.DataAccess.ViewModels.Posts.Commands;
using UserManagement.DataAccess.ViewModels.Posts.Queries;

namespace UserManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController : BaseController
{
    public PostController(IMediator mediator, ILogger logger) : base(mediator, logger)
    {
    }

    [HttpPost]
    [Route(nameof(GetAll))]
    public async Task<Paginated<GetAllPostsResponse>> GetAll(GetAllPostsRequest request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetAllPostsQuery(request, cancellationToken));
    }

    [HttpPost]
    [Route(nameof(Create))]
    public async Task<CreatePostResponse> Create(CreatePostRequest request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new CreatePostCommand(request, cancellationToken));
    }
}
