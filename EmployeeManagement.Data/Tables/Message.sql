CREATE TABLE [dbo].[Message]
(
	[Id] INT NOT NULL PRIMARY KEY Identity (1,1), 
    [SenderId] INT NOT NULL, 
    [SenderUsername] NVARCHAR(50) NOT NULL, 
    [RecepientId] INT NOT NULL, 
    [RecepientName] NVARCHAR(50) NOT NULL, 
    [Content] NVARCHAR(MAX) NOT NULL, 
    [DateRead] DATETIME2 NULL, 
    [MessageSent] DATETIME2 NOT NULL, 
    [SenderDeleted] BIT NOT NULL, 
    [RecipientDeleted] BIT NOT NULL
)
