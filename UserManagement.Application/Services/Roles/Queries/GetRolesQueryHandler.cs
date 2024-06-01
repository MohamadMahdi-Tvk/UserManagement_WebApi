using AutoMapper;
using MediatR;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.Roles.Queries;

namespace UserManagement.Application.Services.Roles.Queries;

public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<GetRolesResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetRolesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<GetRolesResponse>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var roles = await _unitOfWork.RoleRepository.GetAllRoles();

            return roles;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

}

