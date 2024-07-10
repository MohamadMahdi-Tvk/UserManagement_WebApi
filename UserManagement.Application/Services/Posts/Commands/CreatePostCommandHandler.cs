using AutoMapper;
using MediatR;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.Posts.Commands;

namespace UserManagement.Application.Services.Posts.Commands;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatePostResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CreatePostResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var modelMapped = _mapper.Map<CreatePostRequest, Post>(request.Command);

            await _unitOfWork.PostRepository.CreatePost(modelMapped);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new CreatePostResponse(modelMapped.Id);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
