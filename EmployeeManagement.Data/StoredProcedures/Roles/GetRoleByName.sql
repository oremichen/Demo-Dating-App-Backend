CREATE PROCEDURE [dbo].[GetRoleByName]
	@rolename nvarchar(50)
AS
BEGIN
	SELECT * from [Roles] where @rolename = [RoleName] 
END
