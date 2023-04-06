CREATE PROCEDURE [dbo].[DeleteMessage]
	@id int

AS
begin
	delete  from [Message]  where [Id] = @id
end
