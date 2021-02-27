CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [Name] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(50) NULL, 
    [PasswordHash] NVARCHAR(MAX) NULL,
    [PasswordSalt] NVARCHAR(MAX) NULL,
    [DateCreated] DATETIME2 NULL
)
