CREATE PROCEDURE [dbo].[GetUserById]
	
	@Id int
	AS
BEGIN
	SELECT * FROM [Users]
	where [Id] = @Id
END
