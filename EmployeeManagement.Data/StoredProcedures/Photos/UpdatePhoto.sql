CREATE PROCEDURE [dbo].[UpdatePhoto]
	@id int,
	@url nvarchar(max),
	@ismain nvarchar(max),
    @publicId nvarchar(max),
    @userId int
AS
begin
	UPDATE [dbo].[Photos] SET
		[Url] = @url, 
		[IsMain]= @ismain,
		[PublicId] = @publicId,
		[UserId] = @userId

WHERE Id = @id
END