-- =============================================
-- Author:		Artyom
-- Create date: 09.12.2021
-- Description:	
-- =============================================
CREATE FUNCTION [mun].[UF_Hierarchy](
	@ObjectGUID CHAR(36))
RETURNS @Hierarchy TABLE(
	[GUID]     CHAR(36),
	[Level]    INT,
	[Type]     VARCHAR(50),
	[Name]     VARCHAR(250),
	[NameFull] VARCHAR(1000))
AS
BEGIN
	WITH Hierarchy(
		[Parent]
	  , [GUID]
	  , [Level]
	  , [Type]
	  , [Name]
	  , [NameFull])
		 AS (SELECT
				 [R].[ParentGUID]
			   , [R].[ObjectGUID]
			   , [R].[Level]
			   , [R].[Type]
			   , [R].[Name]
			   , CAST([R].[NameFull] AS VARCHAR(1000))
			 FROM
				 [mun].[A_IndexRegistry] [R]
			 WHERE [R].[ObjectGUID] = @ObjectGUID
			 UNION ALL
			 SELECT
				 [R].[ParentGUID]
			   , [R].[ObjectGUID]
			   , [R].[Level]
			   , [R].[Type]
			   , [R].[Name]
			   , CAST(([R].[NameFull] + ', ' + [H].[NameFull]) AS VARCHAR(1000)) [NameFull]
			 FROM
				 [mun].[A_IndexRegistry] [R]
			 JOIN [Hierarchy] [H] ON [H].[Parent] = [R].[ObjectGUID]
			 WHERE [H].[Parent] IS NOT NULL)

		 INSERT INTO @Hierarchy(
			 [GUID]
		   , [Level]
		   , [Type]
		   , [Name]
		   , [NameFull])
		 SELECT
			 [H].[GUID]
		   , [H].[Level]
		   , [H].[Type]
		   , [H].[Name]
		   , [H].[NameFull]
		 FROM
			 [Hierarchy] [H]
		 ORDER BY
			 [H].[Level] DESC

	RETURN
END