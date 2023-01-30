CREATE PROCEDURE [dbo].[GetUserWithLike]
	 @id int	 
	AS
BEGIN
	SELECT * FROM Users s
	left Join UserLike u on s.Id = u.LikedBy 
	where s.Id = @id
	
	END
