-- =============================================
-- Author:		Artyom
-- Create date: 05.12.2021
-- Description:	Поиск в реестре
-- =============================================
CREATE PROCEDURE [mun].[UP_SearchRegistry]
	@Search VARCHAR(500),
	@Level  INT          = 0,
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
		[mun].[A_IndexRegistry] [R]
	WHERE(@Level = 0 OR [R].[Level] = @Level) AND
		 CONTAINS([R].[AddressFull], @Search)
	ORDER BY
		LEN([R].[AddressFull])
	  , [R].[AddressFull]

END