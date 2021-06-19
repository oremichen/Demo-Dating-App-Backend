CREATE TABLE [dbo].[Registration]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
    [Name] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [PasswordEncrypted] NVARCHAR(Max) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL, 
    [DateCreated] DATETIME2 NOT NULL,
    [DateOfBirth] DATETIME2 NOT NULL,
    [Gender] nvarchar(10) NOT NULL, 
    [Photos] NCHAR(10) NULL
)
