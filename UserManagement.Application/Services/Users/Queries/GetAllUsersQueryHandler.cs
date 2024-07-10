using AutoMapper;
using Dapper;
using MediatR;
using System.Data;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.Users.Queries;

namespace UserManagement.Application.Services.Users.Queries;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Paginated<GetAllUsersResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Paginated<GetAllUsersResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
       
        try
        {

            var parameters = new DynamicParameters();
            parameters.Add("PageNumber", request.Query.PageNumber);
            parameters.Add("PageSize",request.Query.PageSize);
            parameters.Add("Query", request.Query.Query);
            parameters.Add("totalRow", 0, null, ParameterDirection.Output);

            var model = await _unitOfWork.ApplicationReadDbConnection.QueryAsync<GetAllUsersResponse>("GetAllUsers", parameters, null, CommandType.StoredProcedure, cancellationToken);

            var totalRow = parameters.Get<int>("totalRow");

            return new Paginated<GetAllUsersResponse>
            {
                Data = model,
                PageIndex = request.Query.PageNumber,
                TotalItems = totalRow,
                TotalPages = (int)Math.Ceiling(totalRow / (double)request.Query.PageSize)
            };
            
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

