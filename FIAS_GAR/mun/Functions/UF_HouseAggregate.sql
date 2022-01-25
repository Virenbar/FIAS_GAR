-- =============================================
-- Author:		Artyom
-- Create date:	09.11.2021
-- Description:	Все дома
-- =============================================
CREATE FUNCTION [mun].[UF_HouseAggregate]()
RETURNS TABLE
AS
RETURN
   (
   SELECT DISTINCT
	   [V].[OBJECTID]    [VillageID]
	 , [V].[OBJECTGUID]  [VillageGUID]
	 , [V].[TYPENAME]    [VillageType]
	 , [V].[NAME]        [VillageName]
	 , [S].[OBJECTID]    [StreetID]
	 , [S].[OBJECTGUID]  [StreeGUID]
	 , [ST].[SHORTNAME]  [StreetType]
	 , [S].[NAME]        [StreetName]
	 , [H].[OBJECTID]    [HouseID]
	 , [H].[OBJECTGUID]  [HouseGUID]
	 , [HT].[SHORTNAME]  [HouseType]
	 , [H].[HOUSENUM]    [HouseNumber]
	 , [HT1].[SHORTNAME] [HouseAType1]
	 , [H].[ADDNUM1]     [HouseANumber1]
	 , [HT2].[SHORTNAME] [HouseAType2]
	 , [H].[ADDNUM2]     [HouseANumber2]
   FROM
	   [HOUSES] [H]
   JOIN [MUN_HIERARCHY] [HP] ON [HP].[OBJECTID] = [H].[OBJECTID]
   LEFT JOIN [ADDR_OBJ] [S] ON [S].[OBJECTID] = [HP].[PARENTOBJID] AND
							   [S].[LEVEL] = 8 AND
							   [S].[ENDDATE] > GETDATE()
   LEFT JOIN [MUN_HIERARCHY] [SP] ON [SP].[OBJECTID] = [S].[OBJECTID]
   JOIN [ADDR_OBJ] [V] ON([V].[OBJECTID] = [SP].[PARENTOBJID] OR
						  [V].[OBJECTID] = [HP].[PARENTOBJID]) AND
						 [V].[LEVEL] <> 8 AND
						 [V].[ENDDATE] > GETDATE()
   --Типы
   LEFT JOIN [HOUSE_TYPES] [HT] ON [HT].[ID] = [H].[HOUSETYPE]
   LEFT JOIN [ADDHOUSE_TYPES] [HT1] ON [HT1].[ID] = [H].[ADDTYPE1]
   LEFT JOIN [ADDHOUSE_TYPES] [HT2] ON [HT2].[ID] = [H].[ADDTYPE2]
   LEFT JOIN [ADDR_OBJ_TYPES] [ST] ON [ST].[SHORTNAME] = [S].[TYPENAME]
   LEFT JOIN [ADDR_OBJ_TYPES] [VT] ON [VT].[SHORTNAME] = [V].[TYPENAME]
   WHERE [H].[ENDDATE] > GETDATE())