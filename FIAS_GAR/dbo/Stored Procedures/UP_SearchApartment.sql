-- =============================================
-- Author:		Artyom
-- Create date: 05.12.2021
-- Description:	Поиск в индексе квартир
-- =============================================
CREATE PROCEDURE [dbo].[UP_SearchApartment]
	@Search VARCHAR(500),
	@Limit  INT          = 10
AS
BEGIN
	SET NOCOUNT ON;

	SET @Search = REPLACE(@Search, '.', ' ')
	SET @Search = REPLACE(@Search, ',', ' ')
	SET @Search = REPLACE(@Search, '  ', ' ')

	DECLARE @SQL NVARCHAR(1000)
	SET @SQL = '
	SELECT TOP (@Limit)
		[A].*
	FROM
		[FIAS_GAR]..[A_IndexApartment] [A]
	WHERE CONTAINS([A].[AddressFull], ''"' + REPLACE(@Search, ' ', '*" AND "') + '*"'')
	ORDER BY
		LEN([A].[AddressFull])'

	--SET @SQL = '
	--SELECT TOP (@Limit)
	--	[A].*
	--FROM
	--	[FIAS_GAR]..[A_IndexApartment] [A]
	--WHERE [A].[AddressFull] LIKE ''%' + REPLACE(@Search, ' ', '%'' AND [A].[AddressFull] LIKE ''%') + '%''
	--ORDER BY
	--	LEN([A].[AddressFull])'
	EXEC [sp_executesql]
		@SQL
	  , N'@Limit INT'
	  , @Limit = @Limit

END