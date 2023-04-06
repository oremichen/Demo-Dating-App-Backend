CREATE PROCEDURE [dbo].[UpdateMessage]
	@id int,
	@messageSent DateTime2, 
	@recepientId int, 
	@recepientName nvarchar(512), 
	@senderId int, 
	@senderUsername nvarchar(512),
	@recipientDeleted bit, 
	@senderDeleted bit, 
	@content nvarchar(max), 
	@dateRead DateTime2
AS
begin
	UPDATE [dbo].[Message] SET
		[MessageSent] = @messageSent, 
		[RecepientId]= @recepientId,
		[RecepientName] = @recepientName,
		[SenderId] = @senderId,
		[SenderUsername] = @senderUsername,
		[RecipientDeleted] = @recipientDeleted,
		[SenderDeleted] = @senderDeleted,
		[Content] = @content,
		[DateRead] = @dateRead

WHERE Id = @id
END
