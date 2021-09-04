CREATE PROCEDURE [dbo].[CreateUsers]
	@name nchar(50),
	@email nvarchar(50),
    @passwordHash nvarchar(MAX),
    @passwordSalt nvarchar(MAX),
	@datecreated DateTime2,
	@dateofbirth  DateTime2, 
	@age int,
	@knownas  nvarchar(MAX), 
	@city  nvarchar(MAX), 
	@gender nvarchar(10)

AS 
BEGIN

	INSERT INTO Users
	([Name],[Email], [PasswordHash], [PasswordSalt], [DateCreated], [DateOfBirth], [Age], [KnownAs], [City], [Gender])

	output inserted.Id

	values
	(@name, @email, @passwordHash, @passwordSalt, @datecreated, @dateofbirth, @age, @knownas, @city, @gender)

end
