-- =============================================
-- Author:		Artyom
-- Create date: 05.12.2021
-- Description:	Обновить реестр все объектов
-- =============================================
CREATE PROCEDURE [dbo].[UP_RefreshRegistry]
AS
BEGIN
	SET NOCOUNT ON;
	RAISERROR('Очистка реестра', 0, 1) WITH NOWAIT
	TRUNCATE TABLE [A_IndexRegistry]

	RAISERROR('Добавление планировочных объектов', 0, 1) WITH NOWAIT
	INSERT INTO [A_IndexRegistry](
		[ParentGUID]
	  , [ObjectGUID]
	  , [Level]
	  , [Type]
	  , [Name]
	  , [NameFull])
	SELECT
		[AOPR].[OBJECTGUID]
	  , [AO].[OBJECTGUID]
	  , [AO].[LEVEL]
	  , [AO].[TYPENAME]
	  , ISNULL([AO].[NAME], '')
	  , ISNULL([AO].[TYPENAME] + ' ' + [AO].[NAME], '')
	FROM
		[ADDR_OBJ] [AO]
	LEFT JOIN [ADM_HIERARCHY] [AOP] ON [AOP].[OBJECTID] = [AO].[OBJECTID] AND
									   [AOP].[ISACTIVE] = 1
	LEFT JOIN [REESTR_OBJECTS] [AOPR] ON [AOPR].[OBJECTID] = [AOP].[PARENTOBJID] AND
										 [AOPR].[ISACTIVE] = 1
	WHERE [AO].[ENDDATE] > GETDATE() AND [AO].[ISACTIVE] = 1

	-- Активные дома
	RAISERROR('Добавление домов', 0, 1) WITH NOWAIT
	INSERT INTO [A_IndexRegistry](
		[ParentGUID]
	  , [ObjectGUID]
	  , [Level]
	  , [Type]
	  , [Name]
	  , [NameFull])
	SELECT
		[HPR].[OBJECTGUID]
	  , [H].[OBJECTGUID]
	  , [HR].[LEVELID]
	  , [HT].[SHORTNAME]
	  , ISNULL([H].[HOUSENUM], '') + ISNULL(' ' + [HT1].[SHORTNAME] + ' ' + [H].[ADDNUM1], '') + ISNULL(' ' + [HT2].[SHORTNAME] + ' ' + [H].[ADDNUM2], '')
	  , ISNULL([HT].[SHORTNAME] + ' ' + [H].[HOUSENUM], '') + ISNULL(' ' + [HT1].[SHORTNAME] + ' ' + [H].[ADDNUM1], '') + ISNULL(' ' + [HT2].[SHORTNAME] + ' ' + [H].[ADDNUM2], '')
	FROM
		[HOUSES] [H]
	JOIN [ADM_HIERARCHY] [HP] ON [HP].[OBJECTID] = [H].[OBJECTID] AND
								 [HP].[ISACTIVE] = 1
	JOIN [REESTR_OBJECTS] [HR] ON [HR].[OBJECTID] = [H].[OBJECTID] AND
								  [HR].[ISACTIVE] = 1
	JOIN [REESTR_OBJECTS] [HPR] ON [HPR].[OBJECTID] = [HP].[PARENTOBJID] AND
								   [HPR].[ISACTIVE] = 1
	-- Полное наименование типов
	LEFT JOIN [HOUSE_TYPES] [HT] ON [HT].[ID] = [H].[HOUSETYPE]
	LEFT JOIN [ADDHOUSE_TYPES] [HT1] ON [HT1].[ID] = [H].[ADDTYPE1]
	LEFT JOIN [ADDHOUSE_TYPES] [HT2] ON [HT2].[ID] = [H].[ADDTYPE2]
	WHERE [H].[ENDDATE] > GETDATE() AND [H].[ISACTIVE] = 1

	-- Активные квартиры
	RAISERROR('Добавление квартир', 0, 1) WITH NOWAIT
	INSERT INTO [A_IndexRegistry](
		[ParentGUID]
	  , [ObjectGUID]
	  , [Level]
	  , [Type]
	  , [Name]
	  , [NameFull])
	SELECT
		[APR].[OBJECTGUID]
	  , [A].[OBJECTGUID]
	  , [AR].[LEVELID]
	  , [AT].[SHORTNAME]
	  , [A].[NUMBER]
	  , ISNULL([AT].[SHORTNAME] + ' ', '') + [A].[NUMBER]
	FROM
		[APARTMENTS] [A]
	JOIN [ADM_HIERARCHY] [AP] ON [AP].[OBJECTID] = [A].[OBJECTID] AND
								 [AP].[ISACTIVE] = 1
	JOIN [REESTR_OBJECTS] [AR] ON [AR].[OBJECTID] = [A].[OBJECTID] AND
								  [AR].[ISACTIVE] = 1
	JOIN [REESTR_OBJECTS] [APR] ON [APR].[OBJECTID] = [AP].[PARENTOBJID] AND
								   [APR].[ISACTIVE] = 1
	-- Полное наименование типов
	LEFT JOIN [APARTMENT_TYPES] [AT] ON [AT].[ID] = [A].[APARTTYPE]
	WHERE [A].[ENDDATE] > GETDATE() AND [A].[ISACTIVE] = 1

	--Активные комнаты
	RAISERROR('Добавление комнат', 0, 1) WITH NOWAIT
	INSERT INTO [A_IndexRegistry](
		[ParentGUID]
	  , [ObjectGUID]
	  , [Level]
	  , [Type]
	  , [Name]
	  , [NameFull])
	SELECT
		[RPR].[OBJECTGUID]
	  , [R].[OBJECTGUID]
	  , [RR].[LEVELID]
	  , [RT].[SHORTNAME]
	  , [R].[NUMBER]
	  , ISNULL([RT].[SHORTNAME] + ' ', '') + [R].[NUMBER]
	FROM
		[ROOMS] [R]
	JOIN [ADM_HIERARCHY] [RP] ON [RP].[OBJECTID] = [R].[OBJECTID] AND
								 [RP].[ISACTIVE] = 1
	JOIN [REESTR_OBJECTS] [RR] ON [RR].[OBJECTID] = [R].[OBJECTID] AND
								  [RR].[ISACTIVE] = 1
	JOIN [REESTR_OBJECTS] [RPR] ON [RPR].[OBJECTID] = [RP].[PARENTOBJID] AND
								   [RPR].[ISACTIVE] = 1
	-- Полное наименование типов
	LEFT JOIN [ROOM_TYPES] [RT] ON [RT].[ID] = [R].[ROOMTYPE]
	WHERE [R].[ENDDATE] > GETDATE() AND [R].[ISACTIVE] = 1

	--Активные парко места
	RAISERROR('Добавление парко-мест', 0, 1) WITH NOWAIT
	INSERT INTO [A_IndexRegistry](
		[ParentGUID]
	  , [ObjectGUID]
	  , [Level]
	  , [Type]
	  , [Name]
	  , [NameFull])
	SELECT
		[CPR].[OBJECTGUID]
	  , [C].[OBJECTGUID]
	  , [CR].[LEVELID]
	  , NULL
	  , [C].[NUMBER]
	  , [C].[NUMBER]
	FROM
		[CARPLACES] [C]
	JOIN [ADM_HIERARCHY] [CP] ON [CP].[OBJECTID] = [C].[OBJECTID] AND
								 [CP].[ISACTIVE] = 1
	JOIN [REESTR_OBJECTS] [CR] ON [CR].[OBJECTID] = [C].[OBJECTID] AND
								  [CR].[ISACTIVE] = 1
	JOIN [REESTR_OBJECTS] [CPR] ON [CPR].[OBJECTID] = [CP].[PARENTOBJID] AND
								   [CPR].[ISACTIVE] = 1
	WHERE [C].[ENDDATE] > GETDATE() AND [C].[ISACTIVE] = 1

	--Активные участки
	RAISERROR('Добавление участков', 0, 1) WITH NOWAIT
	INSERT INTO [A_IndexRegistry](
		[ParentGUID]
	  , [ObjectGUID]
	  , [Level]
	  , [Type]
	  , [Name]
	  , [NameFull])
	SELECT
		[SPR].[OBJECTGUID]
	  , [S].[OBJECTGUID]
	  , [SR].[LEVELID]
	  , NULL
	  , [S].[NUMBER]
	  , [S].[NUMBER]
	FROM
		[STEADS] [S]
	JOIN [ADM_HIERARCHY] [SP] ON [SP].[OBJECTID] = [S].[OBJECTID] AND
								 [SP].[ISACTIVE] = 1
	JOIN [REESTR_OBJECTS] [SR] ON [SR].[OBJECTID] = [S].[OBJECTID] AND
								  [SR].[ISACTIVE] = 1
	JOIN [REESTR_OBJECTS] [SPR] ON [SPR].[OBJECTID] = [SP].[PARENTOBJID] AND
								   [SPR].[ISACTIVE] = 1
	WHERE [S].[ENDDATE] > GETDATE() AND [S].[ISACTIVE] = 1

	-- Обновить полные адреса для всех объектов
	RAISERROR('Обновление полных адресов', 0, 1) WITH NOWAIT
	UPDATE [A_IndexRegistry] SET
		[AddressFull] = [adm].[SUF_GetFullAddress]([ObjectGUID])

END