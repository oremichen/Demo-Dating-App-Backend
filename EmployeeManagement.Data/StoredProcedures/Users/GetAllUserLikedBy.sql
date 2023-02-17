CREATE PROCEDURE [dbo].[GetAllUserLikedBy]
	 @id int	 
	AS
BEGIN
	SELECT * FROM Users s
	left Join UserLike u on s.Id = u.LikedBy 
	order by s.Name
	
	END
