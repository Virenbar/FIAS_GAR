-- =============================================
-- Author:		Artyom
-- Create date: 15.12.2021
-- Description:	
-- =============================================
CREATE FUNCTION [adm].[UF_SearchRegistry](
	@Search VARCHAR(1000))
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
	   WHERE CONTAINS([R].[AddressFull], @Search)
   ORDER BY
		   LEN([R].[AddressFull])
	   UNION ALL
	   SELECT
		   NULL
		 , NULL
		 , 0) [T])
