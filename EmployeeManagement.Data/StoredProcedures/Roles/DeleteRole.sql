CREATE PROCEDURE [dbo].[DeleteRole]
	@roleid int
AS
begin
	delete from [Roles] where RoleId = @roleid
end
