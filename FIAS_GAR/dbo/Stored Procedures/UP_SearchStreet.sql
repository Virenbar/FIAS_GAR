-- =============================================
-- Author:		Artyom
-- Create date: 05.12.2021
-- Description:	Поиск в индексе улиц
-- =============================================
CREATE PROCEDURE [dbo].[UP_SearchStreet]
	@Search VARCHAR(500),
	@Limit  INT          = 10
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @SQL NVARCHAR(1000)
	SET @SQL = '
	SELECT TOP (@Limit)
		[S].*
	FROM
		[FIAS_GAR]..[A_IndexStreet] [S]
	WHERE [S].[AddressFull] LIKE ''%' + REPLACE(@Search, ' ', '%'' AND [S].[AddressFull] LIKE ''%') + '%''
	ORDER BY
		LEN([S].[AddressFull])'
	EXEC [sp_executesql]
		@SQL
	  , N'@Limit INT'
	  , @Limit = @Limit

END