CREATE PROCEDURE [dbo].[CreateUsers]
	@name nchar(50),
	@email nvarchar(50),
    @passwordHash nvarchar(MAX),
    @passwordSalt nvarchar(MAX),
	@datecreated DateTime2

AS 
BEGIN

	INSERT INTO Users
	([Name],[Email], [PasswordHash], [PasswordSalt], [DateCreated])

	output inserted.Id

	values
	(@name, @email, @passwordHash, @passwordSalt, @datecreated)

end
