-- =============================================
-- Author:		Artyom
-- Create date: 14.05.2025
-- Description:	Агрегат реестра - все записи
-- =============================================
CREATE FUNCTION [dbo].[UF_ReestrAggregateAll]()
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
	 , [AO].[STARTDATE]  [StartDate]
	 , [AO].[UPDATEDATE] [UpdateDate]
	 , [AO].[ENDDATE]    [EndDate]
	 , [AO].[ISACTIVE]   [IsActive]
	 , [AO].[ISACTUAL]   [IsActual]
   FROM
	   [dbo].[REESTR_OBJECTS] [RO]
   JOIN [dbo].[ADDR_OBJ] [AO] ON [AO].[OBJECTID] = [RO].[OBJECTID]
   UNION ALL

   -- Активные участки
   SELECT
	   [RO].[OBJECTID]
	 , [RO].[OBJECTGUID]
	 , [RO].[LEVELID]
	 , [T].[SHORTNAME]
	 , [S].[NUMBER]
	 , [S].[STARTDATE]
	 , [S].[UPDATEDATE]
	 , [S].[ENDDATE]
	 , [S].[ISACTIVE]
	 , [S].[ISACTUAL]
   FROM
	   [dbo].[REESTR_OBJECTS] [RO]
   JOIN [dbo].[STEADS] [S] ON [S].[OBJECTID] = [RO].[OBJECTID]
   -- Наименование типов
   JOIN [dbo].[ADDR_OBJ_TYPES] [T] ON [LEVEL] = 9
   UNION ALL

   -- Активные дома
   SELECT
	   [RO].[OBJECTID]
	 , [RO].[OBJECTGUID]
	 , [RO].[LEVELID]
	 , [HT].[SHORTNAME]
	 , ISNULL([H].[HOUSENUM], '') + ISNULL(' ' + [HT1].[SHORTNAME] + ' ' + [H].[ADDNUM1], '') + ISNULL(' ' + [HT2].[SHORTNAME] + ' ' + [H].[ADDNUM2], '')
	 , [H].[STARTDATE]
	 , [H].[UPDATEDATE]
	 , [H].[ENDDATE]
	 , [H].[ISACTIVE]
	 , [H].[ISACTUAL]
   FROM
	   [dbo].[REESTR_OBJECTS] [RO]
   JOIN [dbo].[HOUSES] [H] ON [H].[OBJECTID] = [RO].[OBJECTID]
   -- Наименование типов
   LEFT JOIN [HOUSE_TYPES] [HT] ON [HT].[ID] = [H].[HOUSETYPE]
   LEFT JOIN [ADDHOUSE_TYPES] [HT1] ON [HT1].[ID] = [H].[ADDTYPE1]
   LEFT JOIN [ADDHOUSE_TYPES] [HT2] ON [HT2].[ID] = [H].[ADDTYPE2]
   UNION ALL

   -- Активные квартиры
   SELECT
	   [RO].[OBJECTID]
	 , [RO].[OBJECTGUID]
	 , [RO].[LEVELID]
	 , [AT].[SHORTNAME]
	 , [A].[NUMBER]
	 , [A].[STARTDATE]
	 , [A].[UPDATEDATE]
	 , [A].[ENDDATE]
	 , [A].[ISACTIVE]
	 , [A].[ISACTUAL]
   FROM
	   [dbo].[REESTR_OBJECTS] [RO]
   JOIN [dbo].[APARTMENTS] [A] ON [A].[OBJECTID] = [RO].[OBJECTID]
   -- Наименование типов
   LEFT JOIN [APARTMENT_TYPES] [AT] ON [AT].[ID] = [A].[APARTTYPE]
   UNION ALL

   -- Активные комнаты
   SELECT
	   [RO].[OBJECTID]
	 , [RO].[OBJECTGUID]
	 , [RO].[LEVELID]
	 , [RT].[SHORTNAME]
	 , [R].[NUMBER]
	 , [R].[STARTDATE]
	 , [R].[UPDATEDATE]
	 , [R].[ENDDATE]
	 , [R].[ISACTIVE]
	 , [R].[ISACTUAL]
   FROM
	   [dbo].[REESTR_OBJECTS] [RO]
   JOIN [dbo].[ROOMS] [R] ON [R].[OBJECTID] = [RO].[OBJECTID]
   -- Наименование типов
   LEFT JOIN [ROOM_TYPES] [RT] ON [RT].[ID] = [R].[ROOMTYPE]
   UNION ALL

   -- Активные парко места
   SELECT
	   [RO].[OBJECTID]
	 , [RO].[OBJECTGUID]
	 , [RO].[LEVELID]
	 , [T].[SHORTNAME]
	 , [C].[NUMBER]
	 , [C].[STARTDATE]
	 , [C].[UPDATEDATE]
	 , [C].[ENDDATE]
	 , [C].[ISACTIVE]
	 , [C].[ISACTUAL]
   FROM
	   [dbo].[REESTR_OBJECTS] [RO]
   JOIN [dbo].[CARPLACES] [C] ON [C].[OBJECTID] = [RO].[OBJECTID]
   -- Наименование типов
   JOIN [dbo].[ADDR_OBJ_TYPES] [T] ON [LEVEL] = 17)