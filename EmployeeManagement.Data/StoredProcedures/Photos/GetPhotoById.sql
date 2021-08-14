CREATE PROCEDURE [dbo].[GetPhotoById]
	@id int
AS
begin
	SELECT * from [Photos] where [Id] = @id
end
