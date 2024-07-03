using AutoMapper;
using Dapper;
using MediatR;
using System.Data;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.Users.Queries;

namespace UserManagement.Application.Services.Users.Queries;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UsersResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<UsersResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
       
        try
        {

            var parameters = new DynamicParameters();

            var model = await _unitOfWork.ApplicationReadDbConnection.QueryAsync<UsersResponse>("GetAllUsers", parameters, null, CommandType.StoredProcedure, cancellationToken);

            return model;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

