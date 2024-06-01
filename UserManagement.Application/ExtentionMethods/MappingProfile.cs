using AutoMapper;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.ViewModels.Users.Commands;
using UserManagement.DataAccess.ViewModels.Users.Queries;

namespace UserManagement.Application.ExtentionMethods;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region User
        CreateMap<CreateUserRequest, User>().ReverseMap();
        CreateMap<UsersRequest, User>().ReverseMap();
        CreateMap<GetUserByIdRequest, User>().ReverseMap();
        #endregion

    }
}
