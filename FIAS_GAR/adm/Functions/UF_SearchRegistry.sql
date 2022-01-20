-- =============================================
-- Author:		Artyom
-- Create date: 19.01.2022
-- Description:	Поиск в реестре
-- =============================================
CREATE FUNCTION [adm].[UF_SearchRegistry](
	@Search VARCHAR(1000),
	@Level  INT           = 0)
RETURNS TABLE
AS
RETURN
   (SELECT TOP (1000)
		[R].*
	FROM
		[dbo].[A_IndexRegistry] [R]
	WHERE CONTAINS([R].[AddressFull], @Search) AND
		  (@Level = 0 OR [R].[Level] = @Level)
	ORDER BY
		LEN([R].[AddressFull])
	  , [R].[AddressFull])
