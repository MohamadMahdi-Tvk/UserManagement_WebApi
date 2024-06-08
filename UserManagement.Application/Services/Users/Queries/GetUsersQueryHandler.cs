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
        //var users = await _unitOfWork.UserRepository.GetUsers();

        //var usersMapped = _mapper.Map<IEnumerable<User>, IEnumerable<UsersResponse>>(users);

        //return usersMapped;
        try
        {
            //We wont use text sql due to data expose danger!
            //string sqlCommands = "some query";
            var parameters = new DynamicParameters();
            parameters.Add("PageNumber", request.Query.PageNumber);
            parameters.Add("PageSize", request.Query.PageSize);
            parameters.Add("Query", request.Query.Query);
            parameters.Add("totalrow", 0, null, ParameterDirection.Output);

            var users = await _unitOfWork.ApplicationReadDbConnection.QueryAsync<UsersResponse>("GetAllUsers", parameters, null, CommandType.StoredProcedure, cancellationToken);
            return users;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

