CREATE PROCEDURE [dbo].[CreateUserRegistration]
	
	 @name NVARCHAR(50),  
     @email NVARCHAR(50), 
     @passwordEncrypted NVARCHAR(Max), 
     @password NVARCHAR(50), 
     @dateCreated DATETIME2,
     @DateOfBirth DATETIME2,
     @gender nvarchar(10)

AS 
BEGIN

	INSERT INTO Registration
	([Name],[Email],  [PasswordEncrypted], [Password], [DateCreated], [DateOfBirth], [Gender])

	output inserted.Id

	values
	(@name, @email, @passwordEncrypted, @password, @dateCreated, @DateOfBirth, @gender)

end