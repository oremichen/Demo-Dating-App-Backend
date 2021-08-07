﻿CREATE PROCEDURE [dbo].[InsertPhotos]
	@url nvarchar(max),
	@ismain nvarchar(max),
    @publicId int,
    @userId int

AS 
BEGIN

	INSERT INTO Photos
	([Url], [IsMain], [PublicId], [UserId])

	output inserted.Id

	values
	(@url, @ismain, @publicId, @userId)

end