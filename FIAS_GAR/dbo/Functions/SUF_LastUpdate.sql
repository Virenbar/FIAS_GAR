-- =============================================
-- Author:		Artyom
-- Create date: 28.09.2022
-- Description:	Дата последнего изменения в БД
-- =============================================
CREATE FUNCTION [dbo].[SUF_LastUpdate]()
RETURNS DATETIME
AS
BEGIN
	DECLARE @Date DATETIME
	SELECT
		@Date = MAX([LU].[Date])
	FROM
	   (SELECT
			MAX([CHANGEDATE]) Date
		FROM
			[CHANGE_HISTORY]
		UNION ALL
		SELECT
			MAX([UPDATEDATE]) Date
		FROM
			[REESTR_OBJECTS]
		UNION ALL
		SELECT
			MAX([CREATEDATE]) Date
		FROM
			[REESTR_OBJECTS]) [LU]

	RETURN @Date

END