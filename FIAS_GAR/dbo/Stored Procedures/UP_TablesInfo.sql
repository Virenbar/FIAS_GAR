-- =============================================
-- Author:		Artyom
-- Create date: 25.05.2022
-- Description:	Информация о таблицах
-- exec UP_TablesInfo
-- =============================================
CREATE PROCEDURE [dbo].[UP_TablesInfo]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		[T].[TableName]                                                                 [Name]
	  , [T].[RowCount]                                                                  [RowCount]
	  , [T].[TotalMB]
	  , [T].[UsedMB]
	  , [T].[UnusedMB]
	  , ISNULL(CAST([dbo].[SUF_TableProperty]([T].[TableName], 'CanImport') AS BIT), 0) [CanImport]
	  , CAST([dbo].[SUF_TableProperty]([T].[TableName], 'LastImport') AS DATETIME)      [LastImport]
	FROM
		[dbo].[UF_TablesInfo]() [T]
	WHERE [T].[ObjectType] = 'TABLE' AND
		  [T].[TableName] IN('ADDR_OBJ', 'ADDR_OBJ_DIVISION', 'ADDR_OBJ_TYPES', 'ADM_HIERARCHY', 'APARTMENTS', 'APARTMENT_TYPES', 'CARPLACES', 'CHANGE_HISTORY', 'HOUSES', 'HOUSE_TYPES', 'MUN_HIERARCHY', 'NORMATIVE_DOCS_KINDS', 'NORMATIVE_DOCS_TYPES', 'OBJECT_LEVELS', 'OPERATION_TYPES', 'PARAMS', 'PARAM_TYPES', 'REESTR_OBJECTS', 'ROOMS', 'ROOM_TYPES', 'ADDHOUSE_TYPES', 'STEADS', 'NORMATIVE_DOCS')

END