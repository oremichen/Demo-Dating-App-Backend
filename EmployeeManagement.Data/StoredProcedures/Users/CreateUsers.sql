CREATE PROCEDURE [dbo].[CreateUsers]
	@name nchar(50),
	@email nvarchar(50),
    @passwordHash nvarchar(MAX),
    @passwordSalt nvarchar(MAX),
	@datecreated DateTime2,
	@dateofbirth  DateTime2, 
	@age int,
	@knownas  nvarchar(MAX),
	@lastActive DateTime2,
	@gender nvarchar(10),
	@introduction nvarchar(MAX),
	@lookingfor nvarchar(MAX),
	@interests nvarchar(MAX),
	@city  nvarchar(MAX)
	

AS 
BEGIN

	INSERT INTO Users
	([Name],[Email], [PasswordHash], [PasswordSalt], [DateCreated], [DateOfBirth], [Age], [KnownAs], [LastActive], [Gender], [Introduction], [LookingFor], [Interests], [City])

	output inserted.Id

	values
	(@name, @email, @passwordHash, @passwordSalt, @datecreated, @dateofbirth, @age, @knownas,@lastActive, @gender, @introduction, @lookingfor,  @interests, @city)

end
