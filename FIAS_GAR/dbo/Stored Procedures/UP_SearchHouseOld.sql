-- =============================================
-- Author:		Artyom
-- Create date: 05.12.2021
-- Description:	Поиск в индексе домов
-- =============================================
CREATE PROCEDURE [dbo].[UP_SearchHouseOld]
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
		[H].*
	FROM
		[FIAS_GAR]..[A_IndexHouse] [H]
	WHERE [H].[AddressFull] LIKE ''%' + REPLACE(@Search, ' ', '%'' AND [H].[AddressFull] LIKE ''%') + '%''
	ORDER BY
		LEN([H].[AddressFull])'
	EXEC [sp_executesql]
		@SQL
	  , N'@Limit INT'
	  , @Limit = @Limit

END