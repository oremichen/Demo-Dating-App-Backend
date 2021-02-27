CREATE PROCEDURE [dbo].[GetRegisteredUserByEmail]
		@email nvarchar(50)
AS
BEGIN
	SELECT * from [Registration] where @email = [Email] 
END