CREATE PROCEDURE [dbo].[GetPhotosByUserId]
	@userId int 
AS
	SELECT * from Photos
	where @userId = [UserId]