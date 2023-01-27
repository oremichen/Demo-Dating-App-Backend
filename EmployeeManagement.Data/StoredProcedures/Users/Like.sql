CREATE PROCEDURE [dbo].[Like]
	@userId int,
	@likedBy int
	
AS 
BEGIN

	INSERT INTO UserLike
	([UserId],[LikedBy])

	output inserted.Id

	values
	(@userId, @likedBy)

end

