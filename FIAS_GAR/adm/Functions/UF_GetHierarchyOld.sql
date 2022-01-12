-- =============================================
-- Author:		Artyom
-- Create date: 09.12.2021
-- Description:	
-- =============================================
CREATE FUNCTION [adm].[UF_GetHierarchyOld](
	@ObjectGUID CHAR(36))
RETURNS @Hierarchy TABLE(
	[GUID]  CHAR(36),
	[Level] INT,
	[Type]  VARCHAR(50),
	[Name]  VARCHAR(250))
AS
BEGIN
	SET @ObjectGUID = [adm].[SUF_GetParentGUID](@ObjectGUID);

	WITH Hierarchy(
		[GUID]
	  , [Level]
	  , [Type]
	  , [Name]
	  , [Parent])
		 AS (SELECT
				 [AO].[OBJECTGUID]
			   , [AO].[LEVEL]
			   , [AO].[TYPENAME]
			   , [AO].[NAME]
			   , [adm].[SUF_GetParentGUID]([AO].[OBJECTGUID])
			 FROM
				 [ADDR_OBJ] [AO]
			 WHERE [ao].[ISACTIVE] = 1 AND [AO].[OBJECTGUID] = @ObjectGUID
			 UNION ALL
			 SELECT
				 [AO].[OBJECTGUID]
			   , [AO].[LEVEL]
			   , [AO].[TYPENAME]
			   , [AO].[NAME]
			   , [adm].[SUF_GetParentGUID]([AO].[OBJECTGUID])
			 FROM
				 [ADDR_OBJ] [AO]
			 JOIN [Hierarchy] [H] ON [H].[Parent] = [AO].[OBJECTGUID]
			 WHERE [AO].[ISACTIVE] = 1 AND [H].[Parent] IS NOT NULL)

		 INSERT INTO @Hierarchy(
			 [GUID]
		   , [Level]
		   , [Type]
		   , [Name])
		 SELECT
			 [H].[GUID]
		   , [H].[Level]
		   , [H].[Type]
		   , [H].[Name]
		 FROM
			 [Hierarchy] [H]
		 ORDER BY
			 [H].[Level] DESC

	RETURN
END