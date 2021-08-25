CREATE PROCEDURE [dbo].[DeletePhoto]
	@id int

AS
begin

	delete  from [Photos]  where [Id] = @id
end
