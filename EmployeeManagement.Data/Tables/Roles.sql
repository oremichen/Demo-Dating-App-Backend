CREATE TABLE [dbo].[Roles]
(
	[RoleId] INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
    [RoleCode] NCHAR(10) NOT NULL, 
    [RoleName] NVARCHAR(50) NOT NULL, 
    [PasswordHash] NVARCHAR(MAX) NOT NULL, 
    [PasswordSalt] NVARCHAR(MAX) NOT NULL
)
