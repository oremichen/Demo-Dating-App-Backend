CREATE PROCEDURE [dbo].[CreateRoles]
	@rolecode nchar(10),
	@rolename nvarchar(50),
    @passwordHash nvarchar(MAX),
    @passwordSalt nvarchar(MAX)

AS 
BEGIN

	INSERT INTO Roles
	([RoleCode],[RoleName], [PasswordHash], [PasswordSalt])

	output inserted.RoleId

	values
	(@rolecode, @rolename, @passwordHash, @passwordSalt)

end
