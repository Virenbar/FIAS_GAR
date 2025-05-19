-- =============================================
-- Author:		Artyom
-- Create date: 10.01.2022
-- Description:	Статистика количества объектов по уровням
-- =============================================
CREATE PROCEDURE [dbo].[UP_FIAS_Statistics]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		'LastUpdate'                                    [Key]
	  , 'Дата'                                          [Name]
	  , CONVERT(VARCHAR, [dbo].[SUF_LastUpdate](), 104) [Value]
	UNION ALL
	SELECT
		'Level-' + Format([OL].[LEVEL], 'D2') [Key]
	  , [OL].[NAME]                           [Name]
	  , FORMAT(COUNT(*), 'N0')                [Value]
	FROM
		[dbo].[REESTR_OBJECTS] [RO]
	JOIN [OBJECT_LEVELS] [OL] ON [OL].[LEVEL] = [RO].[LEVELID]
	WHERE [RO].[ISACTIVE] = 1 AND [LEVELID] NOT IN(14)
	GROUP BY
		[Level]
	  , [Name]
	ORDER BY
		[Key] ASC
END