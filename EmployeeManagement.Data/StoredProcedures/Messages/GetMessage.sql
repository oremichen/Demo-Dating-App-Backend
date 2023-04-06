CREATE PROCEDURE [dbo].[GetMessage]
	@id int
	AS
BEGIN
	SELECT * FROM [Message] where [Id] = @id
END
