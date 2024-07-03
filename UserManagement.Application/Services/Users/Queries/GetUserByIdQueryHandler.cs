using AutoMapper;
using Dapper;
using MediatR;
using System.Data;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.Users.Queries;

namespace UserManagement.Application.Services.Users.Queries;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;

    }

    public async Task<GetUserByIdResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            //var user = await _unitOfWork.UserRepository.GetUserById(request.Query.Id);

            //var userMapped = _mapper.Map<User, GetUserByIdResponse>(user);

            var parameters = new DynamicParameters();
            parameters.Add("Id", request.Query.Id);

            var user = await _unitOfWork.ApplicationReadDbConnection.QueryFirstAsync<GetUserByIdResponse>("GetUserById", parameters, null, CommandType.StoredProcedure, cancellationToken);

            return user;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }
}
