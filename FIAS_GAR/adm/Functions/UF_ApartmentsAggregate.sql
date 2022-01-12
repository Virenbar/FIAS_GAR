﻿-- =============================================
-- Author:		Artyom
-- Create date:	09.11.2021
-- Description:	Все квартиры
-- =============================================
CREATE FUNCTION [adm].[UF_ApartmentsAggregate]()
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
	 , [S].[TYPENAME]    [StreetType]
	 , [S].[NAME]        [StreetName]
	 , [H].[OBJECTID]    [HouseID]
	 , [H].[OBJECTGUID]  [HouseGUID]
	 , [HT].[SHORTNAME]  [HouseType]
	 , [H].[HOUSENUM]    [HouseNumber]
	 , [HT1].[SHORTNAME] [HouseAType1]
	 , [H].[ADDNUM1]     [HouseANumber1]
	 , [HT2].[SHORTNAME] [HouseAType2]
	 , [H].[ADDNUM2]     [HouseANumber2]
	 , [A].[OBJECTID]    [ApartmentID]
	 , [A].[OBJECTGUID]  [ApartmentGUID]
	 , [AT].[SHORTNAME]  [ApartmentType]
	 , [A].[NUMBER]      [ApartmentNumber]
	 , [A].[ISACTIVE]    [ApartmentActive]
   FROM
	   [APARTMENTS] [A]
   JOIN [ADM_HIERARCHY] [AP] ON [AP].[OBJECTID] = [A].[OBJECTID] AND
								[AP].[ISACTIVE] = 1
   JOIN [HOUSES] [H] ON [H].[OBJECTID] = [AP].[PARENTOBJID] AND
						[H].[ENDDATE] > GETDATE()
   JOIN [ADM_HIERARCHY] [HP] ON [HP].[OBJECTID] = [H].[OBJECTID] AND
								[HP].[ISACTIVE] = 1
   LEFT JOIN [ADDR_OBJ] [S] ON [S].[OBJECTID] = [HP].[PARENTOBJID] AND
							   [S].[LEVEL] = 8 AND
							   [S].[ENDDATE] > GETDATE()
   LEFT JOIN [ADM_HIERARCHY] [SP] ON [SP].[OBJECTID] = [S].[OBJECTID] AND
									 [SP].[ISACTIVE] = 1
   JOIN [ADDR_OBJ] [V] ON([V].[OBJECTID] = [SP].[PARENTOBJID] OR
						  [V].[OBJECTID] = [HP].[PARENTOBJID]) AND
						 [V].[LEVEL] <> 8 AND
						 [V].[ENDDATE] > GETDATE()
   -- Полное наименование типов
   LEFT JOIN [APARTMENT_TYPES] [AT] ON AT.[ID] = [A].[APARTTYPE]
   LEFT JOIN [HOUSE_TYPES] [HT] ON [HT].[ID] = [H].[HOUSETYPE]
   LEFT JOIN [HOUSE_TYPES] [HT1] ON [HT1].[ID] = IIF([H].[ADDTYPE1] = 1, 10, [H].[ADDTYPE1] + 5)
   LEFT JOIN [HOUSE_TYPES] [HT2] ON [HT2].[ID] = IIF([H].[ADDTYPE2] = 1, 10, [H].[ADDTYPE2] + 5)
   --LEFT JOIN [ADDR_OBJ_TYPES] [ST] ON [ST].[SHORTNAME] = [S].[TYPENAME]
   --LEFT JOIN [ADDR_OBJ_TYPES] [VT] ON [VT].[SHORTNAME] = [V].[TYPENAME]
   WHERE [A].[ENDDATE] > GETDATE())