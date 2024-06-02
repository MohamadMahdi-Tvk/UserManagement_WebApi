using AutoMapper;
using MediatR;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.UserRoles.Commands;

namespace UserManagement.Application.Services.UserRoles.Commands;

public class DeleteUserRoleCommandHandler : IRequestHandler<DeleteUserRoleCommand, DeleteUserRoleResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteUserRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<DeleteUserRoleResponse> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.UserRoleRepository.DeleteUserRole(request.Command.Id);

        await _unitOfWork.CommitAsync(cancellationToken);

        return new DeleteUserRoleResponse(IsSuccess: true);
    }
}

