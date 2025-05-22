-- =============================================
-- Author:		Artyom
-- Create date: 05.12.2021
-- Description:	Обновить реестр все объектов
-- =============================================
CREATE PROCEDURE [mun].[UP_RefreshRegistry]
AS
BEGIN
	-- EXEC mun.UP_RefreshRegistry
	SET NOCOUNT ON;

	RAISERROR('Очистка реестра', 0, 1) WITH NOWAIT
	TRUNCATE TABLE [mun].[A_IndexRegistry]

	RAISERROR('Заполнение реестра', 0, 1) WITH NOWAIT
	INSERT INTO [mun].[A_IndexRegistry](
		[ParentGUID]
	  , [ObjectGUID]
	  , [Level]
	  , [Type]
	  , [Name]
	  , [NameFull])
	SELECT
		[RO].[ObjectGUID]
	  , [RA].[ObjectGUID]
	  , [RA].[Level]
	  , [RA].[Type]
	  , [RA].[Name]
	  , ISNULL([RA].[Type] + ' ', '') + [RA].[Name]
	FROM
		[UF_ReestrAggregate]() [RA]
	LEFT JOIN [MUN_HIERARCHY] [H] ON [H].[OBJECTID] = [RA].[ObjectID] AND [H].[ISACTIVE] = 1
	LEFT JOIN [REESTR_OBJECTS] [RO] ON [RO].[ObjectID] = [H].[PARENTOBJID] AND
									   [RO].[ISACTIVE] = 1

	-- Обновить полные адреса для всех объектов
	RAISERROR('Обновление полных адресов', 0, 1) WITH NOWAIT
	UPDATE [R] SET
		[AddressFull] = [RA].[AddressFull]
	FROM [mun].[A_IndexRegistry] [R]
	JOIN [mun].[UF_RegistryAddress]() [RA] ON [RA].[ObjectGUID] = [R].[ObjectGUID]

END