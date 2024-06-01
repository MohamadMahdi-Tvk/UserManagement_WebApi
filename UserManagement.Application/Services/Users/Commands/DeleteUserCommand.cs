using AutoMapper;
using MediatR;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.Users.Commands;

namespace UserManagement.Application.Services.Users.Commands;

public record DeleteUserCommand(DeleteUserRequest Command, CancellationToken CancellationToken) : IRequest<DeleteUserResponse>;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public DeleteUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {

        try
        {
            var user = _mapper.Map<DeleteUserRequest, User>(request.Command);

            await _unitOfWork.UserRepository.DeleteUser(user.Id);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new DeleteUserResponse(IsSuccess: true);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}