CREATE PROCEDURE [dbo].[AddMessage]
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
BEGIN

	INSERT INTO Message
	([MessageSent], [RecepientId], [RecepientName], [SenderId], [SenderUsername], [RecipientDeleted], [SenderDeleted],
	[Content], [DateRead])

	output inserted.Id

	values
	(@messageSent, @recepientId, @recepientName, @senderId, @senderUsername, @recipientDeleted,
	@senderDeleted, @content, @deateRead)

end
