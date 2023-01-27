CREATE TABLE [dbo].[UserLike]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserId] INT NOT NULL,
	[LikedBy] INT NOT NULL,

	FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]),
	FOREIGN KEY ([LikedBy]) REFERENCES [Users] ([Id])
)
