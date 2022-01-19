-- =============================================
-- Author:		Artyom
-- Create date: 19.01.2022
-- Description:	Поиск в реестре (Выводит всегда 1 строку)
-- =============================================
CREATE FUNCTION [adm].[UF_SearchRegistryByLevel](
	@Search VARCHAR(1000),
	@Level  INT           = 0)
RETURNS TABLE
AS
RETURN
   (
   SELECT TOP (1)
	   [T].*
   FROM
	  (SELECT TOP (1)
		   [R].[ObjectGUID]
		 , [R].[AddressFull]
		 , COUNT(*) OVER() [Count]
	   --, IIF(COUNT(*) > 1, 0, 1) [OnlyOne]
	   FROM
		   [dbo].[A_IndexRegistry] [R]
	   WHERE CONTAINS([R].[AddressFull], @Search) AND
			 (@Level = 0 OR [R].[Level] = @Level)
   ORDER BY
		   LEN([R].[AddressFull])
	   UNION ALL
	   SELECT
		   NULL
		 , NULL
		 , 0) [T])