CREATE PROCEDURE [dbo].[GetUserLikeByUserIdLikedBy]
	 @userId int, 
	 @likedBy int
	AS
BEGIN
	SELECT * FROM [UserLike]
	where [UserId] = @userId and [LikedBy] = @likedBy
END

