CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [Name] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(50) NULL, 
    [PasswordHash] NVARCHAR(MAX) NULL,
    [PasswordSalt] NVARCHAR(MAX) NULL,
    [DateCreated] DATETIME2 NULL,
    [DateOfBirth] DATETIME2 NULL,
    [KnownAs] NVARCHAR(MAX) Null,
    [LastAcvtive] NVARCHAR(MAX) Null,
    [Gender] NVARCHAR(3) Null,
    [Introduction] NVARCHAR(MAX) Null,
    [LookingFor] NVARCHAR(MAX) Null,
    [Interests] NVARCHAR(MAX) Null,
    [City] NVARCHAR(MAX) Null,
    [Photos] NV
)
