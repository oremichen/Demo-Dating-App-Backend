CREATE TABLE [dbo].[Photos]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [Url] NVARCHAR NOT NULL,
    [IsMain] bit NULL,
    [PublicId] int NULL,
    [UserId] int Not null
)
