using AutoMapper;
using Dapper;
using MediatR;
using System.Data;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.Roles.Queries;

namespace UserManagement.Application.Services.Roles.Queries;

public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, GetRoleByIdResponse>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetRoleByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetRoleByIdResponse> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            //var role = await _unitOfWork.RoleRepository.GetRoleById(request.Query.Id);

            //var roleMapped = _mapper.Map<Role, GetRoleByIdResponse>(role);

            //return roleMapped;

            var parameters = new DynamicParameters();
            parameters.Add("Id", request.Query.Id);
            
            var role = await _unitOfWork.ApplicationReadDbConnection.QueryFirstAsync<GetRoleByIdResponse>("GetRoleById", parameters, null, CommandType.StoredProcedure, cancellationToken);

            return role;



        }

        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}

