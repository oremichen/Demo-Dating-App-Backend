CREATE PROCEDURE [dbo].[UpdateUser]
	@id int, 
	@name nvarchar(50),
	@email nvarchar(50), 
	@passwordHash nvarchar(MAX), 
	@passwordSalt nvarchar(MAX),
	@datecreated datetime2(7), 
	@dateofbirth datetime2(7),
	@age int,
    @knownas nvarchar(MAX),
	@lastactive nvarchar(MAX), 
	@gender nvarchar(3), 
	@introduction nvarchar(MAX), 
	@lookingfor nvarchar(MAX), 
	@interests nvarchar(MAX),
	@city nvarchar(MAX)
AS
	BEGIN 
	UPDATE[dbo].[Users] SET
	[Name] = @name, 
	[Email]= @email,
	[PasswordHash] = @passwordHash,
	[PasswordSalt] = @passwordSalt,
	[DateCreated] = @datecreated,
	[DateOfBirth] = @dateofbirth,
	[Age] = @age,
	[KnownAs] = @knownas,
	[LastAcvtive] = @lastactive,
	[Gender] = @gender,
	[Introduction] = @introduction,
	[LookingFor] = @lookingfor,
	[Interests] = @interests,
	[City] = @city

WHERE [Id] = @id
END
