-- =============================================
-- Author:		Artyom
-- Create date: 07.11.2022
-- Description:	Поиск объекта по выражению
-- =============================================
CREATE FUNCTION [mun].[SUF_Search](
	@Search     VARCHAR(1000),
	@Level      INT           = 0,
	@OnlySingle BIT           = 0)
RETURNS CHAR(36)
AS
BEGIN
	IF @Search IS NULL
		RETURN NULL
	DECLARE @Result CHAR(36), @Count INT

	SELECT TOP (1)
		@Result = [R].[ObjectGUID]
	  , @Count = COUNT(*) OVER()
	FROM
		[mun].[A_IndexRegistry] [R]
	WHERE CONTAINS([R].[AddressFull], @Search) AND
		  (@Level = 0 OR [R].[Level] = @Level)
	ORDER BY
		LEN([R].[AddressFull])
	  , [R].[AddressFull]

	-- Вернуть если найден только один
	IF @OnlySingle = 1 AND @Count <> 1
		RETURN NULL

	RETURN @Result

END