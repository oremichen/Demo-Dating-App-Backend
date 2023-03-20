CREATE PROCEDURE [dbo].[GetMessageThread]
	 @currentUserId int, 
	 @recepientId int
AS
BEGIN
	SELECT * FROM [Message]
	where ([SenderId] = @currentUserId and [RecepientId] = @recepientId) or
	([SenderId] = @recepientId and [RecepientId] = @currentUserId)
	ORDER BY [MessageSent]
END
