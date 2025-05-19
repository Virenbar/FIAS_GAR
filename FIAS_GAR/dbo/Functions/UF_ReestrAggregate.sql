-- =============================================
-- Author:		Artyom
-- Create date: 14.05.2025
-- Description:	Агрегат реестра - актуальные записи
-- =============================================
CREATE FUNCTION [dbo].[UF_ReestrAggregate]()
RETURNS TABLE
AS
RETURN
   (
   -- Активные адресные объекты
   SELECT
	   [RO].[OBJECTID]   [ObjectID]
	 , [RO].[OBJECTGUID] [ObjectGUID]
	 , [RO].[LEVELID]    [Level]
	 , [AO].[TYPENAME]   [Type]
	 , [AO].[NAME]       [Name]
   FROM
	   [dbo].[REESTR_OBJECTS] [RO]
   JOIN [dbo].[ADDR_OBJ] [AO] ON [AO].[OBJECTID] = [RO].[OBJECTID] AND
								 [AO].[ISACTUAL] = 1
   WHERE [RO].[ISACTIVE] = 1
   UNION ALL
   -- Активные участки
   SELECT
	   [RO].[OBJECTID]
	 , [RO].[OBJECTGUID]
	 , [RO].[LEVELID]
	 , NULL
	 , [S].[NUMBER]
   FROM
	   [dbo].[REESTR_OBJECTS] [RO]
   JOIN [dbo].[STEADS] [S] ON [S].[OBJECTID] = [RO].[OBJECTID] AND [S].[ISACTUAL] = 1
   WHERE [RO].[ISACTIVE] = 1
   UNION ALL
   -- Активные дома
   SELECT
	   [RO].[OBJECTID]
	 , [RO].[OBJECTGUID]
	 , [RO].[LEVELID]
	 , [HT].[SHORTNAME]
	 , ISNULL([H].[HOUSENUM], '') + ISNULL(' ' + [HT1].[SHORTNAME] + ' ' + [H].[ADDNUM1], '') + ISNULL(' ' + [HT2].[SHORTNAME] + ' ' + [H].[ADDNUM2], '')
   FROM
	   [dbo].[REESTR_OBJECTS] [RO]
   JOIN [dbo].[HOUSES] [H] ON [H].[OBJECTID] = [RO].[OBJECTID] AND [H].[ISACTUAL] = 1
   -- Полное наименование типов
   LEFT JOIN [HOUSE_TYPES] [HT] ON [HT].[ID] = [H].[HOUSETYPE]
   LEFT JOIN [ADDHOUSE_TYPES] [HT1] ON [HT1].[ID] = [H].[ADDTYPE1]
   LEFT JOIN [ADDHOUSE_TYPES] [HT2] ON [HT2].[ID] = [H].[ADDTYPE2]
   WHERE [RO].[ISACTIVE] = 1
   UNION ALL
   -- Активные квартиры
   SELECT
	   [RO].[OBJECTID]
	 , [RO].[OBJECTGUID]
	 , [RO].[LEVELID]
	 , [AT].[SHORTNAME]
	 , [A].[NUMBER]
   FROM
	   [dbo].[REESTR_OBJECTS] [RO]
   JOIN [dbo].[APARTMENTS] [A] ON [A].[OBJECTID] = [RO].[OBJECTID] AND [A].[ISACTUAL] = 1
   -- Полное наименование типов
   LEFT JOIN [APARTMENT_TYPES] [AT] ON [AT].[ID] = [A].[APARTTYPE]
   WHERE [RO].[ISACTIVE] = 1
   UNION ALL
   -- Активные комнаты
   SELECT
	   [RO].[OBJECTID]
	 , [RO].[OBJECTGUID]
	 , [RO].[LEVELID]
	 , [RT].[SHORTNAME]
	 , [R].[NUMBER]
   FROM
	   [dbo].[REESTR_OBJECTS] [RO]
   JOIN [dbo].[ROOMS] [R] ON [R].[OBJECTID] = [RO].[OBJECTID] AND [R].[ISACTUAL] = 1
   -- Полное наименование типов
   LEFT JOIN [ROOM_TYPES] [RT] ON [RT].[ID] = [R].[ROOMTYPE]
   WHERE [RO].[ISACTIVE] = 1
   UNION ALL
   -- Активные парко места
   SELECT
	   [RO].[OBJECTID]
	 , [RO].[OBJECTGUID]
	 , [RO].[LEVELID]
	 , NULL
	 , [C].[NUMBER]
   FROM
	   [dbo].[REESTR_OBJECTS] [RO]
   JOIN [dbo].[CARPLACES] [C] ON [C].[OBJECTID] = [RO].[OBJECTID] AND [C].[ISACTUAL] = 1
   WHERE [RO].[ISACTIVE] = 1)