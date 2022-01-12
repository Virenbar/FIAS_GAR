-- =============================================
-- Author:		Artyom
-- Create date: 05.12.2021
-- Description:	Поиск в регистре
-- =============================================
CREATE PROCEDURE [dbo].[UP_SearchRegistry]
	@Search VARCHAR(500),
	@Limit  INT          = 10
AS
BEGIN
	SET NOCOUNT ON;

	SET @Search = REPLACE(@Search, '.', ' ')
	SET @Search = REPLACE(@Search, ',', ' ')
	SET @Search = REPLACE(@Search, '  ', ' ')

	SET @Search = '"' + REPLACE(@Search, ' ', '*" AND "') + '*"'
	SELECT TOP (@Limit)
		[R].*
	FROM
		[dbo].[A_IndexRegistry] [R]
	WHERE CONTAINS([R].[AddressFull], @Search)
	ORDER BY
		LEN([R].[AddressFull])

END