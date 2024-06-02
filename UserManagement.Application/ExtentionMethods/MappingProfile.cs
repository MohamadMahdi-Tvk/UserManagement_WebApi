using AutoMapper;
using UserManagement.Application.Services.Roles.Queries;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.ViewModels.Roles.Commands;
using UserManagement.DataAccess.ViewModels.Roles.Queries;
using UserManagement.DataAccess.ViewModels.UserRoles.Commands;
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
        CreateMap<DeleteUserRequest,User>().ReverseMap();
        CreateMap<UpdateUserRequest,User>().ReverseMap();

        #endregion

        #region Role

        CreateMap<GetRolesRequest,Role>().ReverseMap();
        CreateMap<CreateRoleRequest,Role>().ReverseMap();
        CreateMap<GetRoleByIdRequest,Role>().ReverseMap();
        CreateMap<UpdateRoleRequest,Role>().ReverseMap();
        CreateMap<DeleteRoleRequest,Role>().ReverseMap();

        #endregion

        #region UserRole

        CreateMap<CreateUserRoleRequest,UserRole>().ReverseMap();

        #endregion

    }
}
