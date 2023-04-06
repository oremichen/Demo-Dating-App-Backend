CREATE PROCEDURE [dbo].[GetAllUserLiked]
	 @id int	 
	AS
BEGIN
	SELECT * FROM Users s
	left Join UserLike u on s.Id = u.UserId 
	order by s.Name
	
	END
