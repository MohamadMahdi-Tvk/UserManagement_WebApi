Use UserManagementDb
Go

Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

Create Procedure [dbo].[GetAllUsers]
 @PageNumber INT,
 @PageSize INT,
 @Query NVARCHAR(MAX),
 @totalRow INT OUTPUT
 
AS
Begin
	Select U.[Id],
		   U.[FirstName],	
		   U.[LastName],
		   U.[UserName],
		   U.[InsertDate],
		   U.[IsDeleted],
		   R.[Title]
		From Users U INNER JOIN
		UserRoles UR 
		On U.Id = UR.UserId INNER JOIN
		Roles R 
		On UR.RoleId = R.Id
	Where U.IsDeleted = 0 AND U.FirstName +'#'+ U.LastName +'#' + U.UserName + '#' + R.Title +'#' LIKE '%' +@Query + '%'
	Order By U.Id
	OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS Only
	Set @totalRow = (Select COUNT(*) From Users U INNER JOIN
		UserRoles UR 
		On U.Id = UR.UserId INNER JOIN
		Roles R 
		On UR.RoleId = R.Id
	Where U.IsDeleted = 0 AND U.FirstName +'#'+ U.LastName +'#' + U.UserName + '#' + R.Title +'#' LIKE '%' +@Query + '%')
End