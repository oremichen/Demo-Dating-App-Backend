CREATE PROCEDURE [dbo].[GetRoleByRoleId]
	@roleId int
AS
BEGIN
	SELECT * from [Roles] where @roleId = [RoleId] 
END
