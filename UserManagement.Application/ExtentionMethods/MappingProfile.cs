using AutoMapper;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.ViewModels.Posts.Commands;
using UserManagement.DataAccess.ViewModels.Roles.Commands;
using UserManagement.DataAccess.ViewModels.Roles.Queries;
using UserManagement.DataAccess.ViewModels.UserRoles.Commands;
using UserManagement.DataAccess.ViewModels.UserRoles.Queries;
using UserManagement.DataAccess.ViewModels.Users.Commands;
using UserManagement.DataAccess.ViewModels.Users.Queries;

namespace UserManagement.Application.ExtentionMethods;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region User
        CreateMap<User, GetAllUsersResponse>().ReverseMap();

        CreateMap<GetUserByIdResponse, User>().ReverseMap();

        CreateMap<CreateUserRequest, User>().ReverseMap();

        CreateMap<DeleteUserRequest, User>().ReverseMap();

        CreateMap<UpdateUserRequest, User>().ReverseMap();

        #endregion

        #region Role

        CreateMap<Role, GetRolesResponse>().ReverseMap();

        CreateMap<GetRoleByIdResponse, Role>().ReverseMap();

        CreateMap<CreateRoleRequest, Role>().ReverseMap();

        CreateMap<DeleteRoleRequest, Role>().ReverseMap();

        CreateMap<UpdateRoleRequest, Role>().ReverseMap();

        #endregion

        #region UserRole

        CreateMap<GetUserRolesResponse, UserRole>().ReverseMap();

        CreateMap<CreateUserRoleRequest, UserRole>().ReverseMap();

        CreateMap<GetUserRoleByIdResponse, UserRole>().ReverseMap();

        CreateMap<DeleteUserRoleRequest, UserRole>().ReverseMap();

        CreateMap<UpdateUserRoleRequest, UserRole>().ReverseMap();

        #endregion

        #region Post

        CreateMap<CreatePostRequest, Post>().ReverseMap();

        #endregion

    }
}
