CREATE PROCEDURE [dbo].[UpdateUsers]
	@id int, 
	@name nvarchar(50),
	@email nvarchar(50), 
	@passwordHash nvarchar(MAX), 
	@passwordSalt nvarchar(MAX),
	@datecreated datetime2(7), 
	@dateofbirth datetime2(7),
    @knownas nvarchar(MAX),
	@lastactive nvarchar(MAX), 
	@gender nvarchar(3), 
	@introduction nvarchar(MAX), 
	@lookingfor nvarchar(MAX), 
	@interests nvarchar(MAX),
	@city nvarchar(MAX),
	@age int
AS
	BEGIN 
	UPDATE[dbo].[Users] SET
	[Name] = @name, 
	[Email]= @email,
	[PasswordHash] = @passwordHash,
	[PasswordSalt] = @passwordSalt,
	[DateCreated] = @datecreated,
	[DateOfBirth] = @dateofbirth,
	[KnownAs] = @knownas,
	[LastActive] = @lastactive,
	[Gender] = @gender,
	[Introduction] = @introduction,
	[LookingFor] = @lookingfor,
	[Interests] = @interests,
	[City] = @city,
	[Age] = @age

	output inserted.Name

WHERE [Id] = @id;

END
