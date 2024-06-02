using AutoMapper;
using MediatR;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.Repositories;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.Roles.Queries;

namespace UserManagement.Application.Services.Roles.Queries;

public record GetRoleByIdCommand(GetRoleByIdRequest Command, CancellationToken CancellationToken) : IRequest<GetRoleByIdResponse>;

public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdCommand, GetRoleByIdResponse>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetRoleByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetRoleByIdResponse> Handle(GetRoleByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var roleMapped = _mapper.Map<GetRoleByIdRequest, Role>(request.Command);

            var role = _unitOfWork.RoleRepository.GetRoleById(roleMapped.Id);

            return await role;

        }

        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}

