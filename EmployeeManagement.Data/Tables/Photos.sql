CREATE TABLE [dbo].[Photos]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [Url] NVARCHAR(MAX) NOT NULL,
    [IsMain] bit NULL,
    [PublicId] NVARCHAR(MAX) NULL,
    [UserId] int Not null
)
