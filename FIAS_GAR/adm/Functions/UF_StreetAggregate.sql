-- =============================================
-- Author:		Artyom
-- Create date:	09.11.2021
-- Description:	Все улицы
-- =============================================
CREATE FUNCTION [adm].[UF_StreetAggregate]()
RETURNS TABLE
AS
RETURN
   (
   SELECT DISTINCT
	   [V].[OBJECTID]   [VillageID]
	 , [V].[OBJECTGUID] [VillageGUID]
	 , [V].[TYPENAME]   [VillageType]
	 , [V].[NAME]       [VillageName]
	 , [S].[OBJECTID]   [StreetID]
	 , [S].[OBJECTGUID] [StreetGUID]
	 , [S].[TYPENAME]   [StreetType]
	 , [S].[NAME]       [StreetName]
	 , [S].[ISACTIVE]   [StreetActive]
   FROM
	   [ADDR_OBJ] [S]
   LEFT JOIN [ADM_HIERARCHY] [SP] ON [SP].[OBJECTID] = [S].[OBJECTID] AND
									 [SP].[ISACTIVE] = 1
   JOIN [ADDR_OBJ] [V] ON [V].[OBJECTID] = [SP].[PARENTOBJID] AND
						  [V].[ENDDATE] > GETDATE()
   -- Полное название типа
   --LEFT JOIN [ADDR_OBJ_TYPES] [ST] ON [ST].[SHORTNAME] = [S].[TYPENAME]
   --LEFT JOIN [ADDR_OBJ_TYPES] [VT] ON [VT].[SHORTNAME] = [V].[TYPENAME]
   WHERE [S].[LEVEL] = 8 AND [S].[ENDDATE] > GETDATE())