using Dapper;
using MediatR;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.Posts.Queries;
using System.Data;

namespace UserManagement.Application.Services.Posts.Queries;

public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, Paginated<GetAllPostsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPostsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Paginated<GetAllPostsResponse>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var parameters = new DynamicParameters();

            parameters.Add("PageNumber", request.Query.PageNumber);
            parameters.Add("PageSize", request.Query.PageSize);
            parameters.Add("Query", request.Query.Query);

            parameters.Add("totalRow", 0, null, ParameterDirection.Output);

            var model = await _unitOfWork.ApplicationReadDbConnection.QueryAsync<GetAllPostsResponse>("GetAllPosts", parameters, null, CommandType.StoredProcedure, cancellationToken);

            var totalRow = parameters.Get<int>("totalRow");

            return new Paginated<GetAllPostsResponse>
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
