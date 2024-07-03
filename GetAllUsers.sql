SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetAllUsers]
AS
BEGIN
	SELECT U.[Id]
		  ,U.[FirstName]
		  ,U.[LastName]
		  ,R.[Title]
		  FROM Users AS U
		  INNER JOIN UserRoles AS UR
		  ON UR.UserId = U.Id
		  INNER JOIN Roles AS R
		  ON UR.RoleId = R.Id
		  WHERE U.IsDeleted = 0 
          ORDER BY U.Id DESC
END

