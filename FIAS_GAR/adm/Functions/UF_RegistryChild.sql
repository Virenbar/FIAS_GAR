-- =============================================
-- Author:		Artyom
-- Create date:	09.02.2024
-- Description:	Получить все дочерние объекты по GUID
-- =============================================
CREATE FUNCTION [adm].[UF_RegistryChild](
	@ObjectGUID CHAR(36),
	@Level      INT      = 0)
RETURNS @Hierarchy TABLE(
	[GUID]     CHAR(36),
	[Level]    INT,
	[Type]     VARCHAR(50),
	[Name]     VARCHAR(250),
	[NameFull] VARCHAR(1000))
AS
BEGIN
	WITH Hierarchy(
		[ParentGUID]
	  , [ObjectGUID]
	  , [Level]
	  , [Type]
	  , [Name]
	  , [AddressFull])
		 AS (SELECT
				 [R].[ParentGUID]
			   , [R].[ObjectGUID]
			   , [R].[Level]
			   , [R].[Type]
			   , [R].[Name]
			   , CAST([R].[AddressFull] AS VARCHAR(1000))
			 FROM
				 [FIAS_GAR].[adm].[A_IndexRegistry] [R]
			 WHERE [R].[ParentGUID] = @ObjectGUID
			 UNION ALL
			 SELECT
				 [R].[ParentGUID]
			   , [R].[ObjectGUID]
			   , [R].[Level]
			   , [R].[Type]
			   , [R].[Name]
			   , [R].[AddressFull]
			 FROM
				 [FIAS_GAR].[adm].[A_IndexRegistry] [R]
			 JOIN [Hierarchy] [H] ON [H].[ObjectGUID] = [R].[ParentGUID]
			 WHERE [H].[ObjectGUID] IS NOT NULL)

		 INSERT INTO @Hierarchy(
			 [GUID]
		   , [Level]
		   , [Type]
		   , [Name]
		   , [NameFull])
		 SELECT
			 [H].[ObjectGUID]
		   , [H].[Level]
		   , [H].[Type]
		   , [H].[Name]
		   , [H].[AddressFull]
		 FROM
			 [Hierarchy] [H]
		 WHERE @Level = 0 OR [H].[Level] = @Level
		 ORDER BY
			 [H].[Level] DESC

	RETURN
END