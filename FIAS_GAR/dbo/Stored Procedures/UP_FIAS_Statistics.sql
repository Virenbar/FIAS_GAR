-- =============================================
-- Author:		Artyom
-- Create date: 10.01.2022
-- Description:	Статистика по 
-- =============================================
CREATE PROCEDURE [dbo].[UP_FIAS_Statistics]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		'LastUpdate'                                  [Key]
	  , 'Дата'                                        [Name]
	  , CONVERT(VARCHAR, MAX([RO].[UPDATEDATE]), 104) [Value]
	FROM
		[REESTR_OBJECTS] [RO]
	UNION ALL
	SELECT
		'Level-' + Format([OL].[LEVEL], 'D2') [Key]
	  , [OL].[NAME]                           [Name]
	  , FORMAT(COUNT(*), 'N0')                [Value]
	FROM
		[ADDR_OBJ] [AO]
	JOIN [OBJECT_LEVELS] [OL] ON [OL].[LEVEL] = [AO].[LEVEL]
	WHERE [OL].[ENDDATE] > GETDATE() AND
		  [ao].[ISACTIVE] = 1 AND
		  [ao].[ENDDATE] > GETDATE()
	GROUP BY
		[OL].[LEVEL]
	  , [OL].[NAME]
	UNION ALL
	SELECT
		'Level-' + FORMAT([OL].[LEVEL], 'D2') [Key]
	  , [OL].[NAME]                           [Name]
	  , [H].[Value]                           [Value]
	FROM
	   (SELECT
			9                      [Level]
		  , FORMAT(COUNT(*), 'N0') [Value]
		FROM
			[STEADS] [S]
		WHERE [S].[ISACTIVE] = 1 AND [S].[ENDDATE] > GETDATE()
		UNION ALL
		SELECT
			10                     [Level]
		  , FORMAT(COUNT(*), 'N0') [Value]
		FROM
			[HOUSES] [H]
		WHERE [H].[ISACTIVE] = 1 AND [H].[ENDDATE] > GETDATE()
		UNION ALL
		SELECT
			11                     [Level]
		  , FORMAT(COUNT(*), 'N0') [Value]
		FROM
			[APARTMENTS] [A]
		WHERE [A].[ISACTIVE] = 1 AND [A].[ENDDATE] > GETDATE()
		UNION ALL
		SELECT
			12                     [Level]
		  , FORMAT(COUNT(*), 'N0') [Value]
		FROM
			[ROOMS] [R]
		WHERE [R].[ISACTIVE] = 1 AND [R].[ENDDATE] > GETDATE()
		UNION ALL
		SELECT
			17                     [Level]
		  , FORMAT(COUNT(*), 'N0') [Value]
		FROM
			[CARPLACES] [CP]
		WHERE [CP].[ISACTIVE] = 1 AND [CP].[ENDDATE] > GETDATE()) [H]
	JOIN [OBJECT_LEVELS] [OL] ON [OL].[LEVEL] = [H].[Level]
	ORDER BY
		[Key] ASC
END