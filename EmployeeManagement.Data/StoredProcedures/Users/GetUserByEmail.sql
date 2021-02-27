CREATE PROCEDURE [dbo].[GetUserByEmail]
	
	@email nvarchar(MAX)
	AS
BEGIN
	SELECT * FROM [Users]
	where [Email] = @email
END
