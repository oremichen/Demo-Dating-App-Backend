CREATE PROCEDURE [dbo].[UpdateRoles]
@roleid int,
@rolecode nchar(10), 
@rolename nvarchar(50) 

AS 
BEGIN 
UPDATE[dbo].[Roles] SET
[RoleCode] = @rolecode, 
[RoleName]= @rolename

WHERE RoleId = @roleid
END