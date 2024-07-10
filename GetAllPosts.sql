Use UserManagementDb
GO
Set ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllPosts]
 @PageNumber AS INT,
 @PageSize AS INT,
 @Query NVARCHAR(MAX),
 @totalRow INT OUTPUT
AS
BEGIN
	SELECT P.[Id]
		  ,P.[Title]
		  ,P.[Description]
		  ,U.[FirstName] + ' '+ U.LastName AS [UserInsert]
		  FROM Posts P INNER JOIN Users U
		  ON P.UserId = U.Id
		  WHERE P.IsDeleted = 0 AND P.[Title] + '#' + P.[Description] LIKE '%' + @Query + '%'
		  Order By U.Id
		  OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS Only
	      Set @totalRow = (Select COUNT(*) 
		  From Posts P INNER JOIN Users U 
		  ON P.UserId = U.Id
	      Where U.IsDeleted = 0 AND P.[Title] + '#' + P.[Description] LIKE '%' +@Query + '%')
End