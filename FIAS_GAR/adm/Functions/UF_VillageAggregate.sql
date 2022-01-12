-- =============================================
-- Author:		Artyom
-- Create date:	09.11.2021
-- Description:	Все нас.пункты (Уровень 5 и 6)
-- =============================================
CREATE FUNCTION [adm].[UF_VillageAggregate]()
RETURNS TABLE
AS
RETURN
   (
   SELECT DISTINCT
	   [V].[OBJECTID]   [VillageID]
	 , [V].[OBJECTGUID] [VillageGUID]
	 , [V].[TYPENAME]   [VillageType]
	 , [V].[NAME]       [VillageName]
	 , [V].[ISACTIVE]   [VillageActive]
   FROM
	   [ADDR_OBJ] [V]
   -- Полное название типа
   --LEFT JOIN [ADDR_OBJ_TYPES] [VT] ON [VT].[SHORTNAME] = [V].[TYPENAME]
   WHERE [V].[LEVEL] IN(5, 6) AND [V].[ENDDATE] > GETDATE())