namespace UserManagement.DataAccess.ViewModels.UserRoles.Queries;

public record GetUserRolesRequest();

public record GetUserRolesResponse(int UserRoleId, string UserFullName, string RoleTitle);

