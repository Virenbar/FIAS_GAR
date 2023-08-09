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
		@Date = MAX(CAST([dbo].[SUF_TableProperty]([T].[TableName], 'LastImport') AS DATETIME))
	FROM
		[dbo].[UF_TablesInfo]() [T]

	RETURN @Date

END