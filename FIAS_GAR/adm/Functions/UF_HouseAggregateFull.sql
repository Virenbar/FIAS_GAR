-- =============================================
-- Author:		Artyom
-- Create date:	09.11.2021
-- Description:	Все дома
-- =============================================
CREATE FUNCTION [adm].[UF_HouseAggregateFull]()
RETURNS TABLE
AS
RETURN
   (
   SELECT
	   [H].*
	 , [HouseFull] = ISNULL([HouseType] + ' ' + [HouseNumber], '') + ISNULL(' ' + [HouseAType1] + ' ' + [HouseANumber1], '') + ISNULL(' ' + [HouseAType2] + ' ' + [HouseANumber2], '')
	 , [AddressFull] = replace(replace([VillageType] + ' ' + [VillageName] + ', ' + ISNULL([StreetType] + ' ' + [StreetName] + ', ', '') + ISNULL([HouseType] + ' ' + [HouseNumber], '') + ISNULL(' ' + [HouseAType1] + ' ' + [HouseANumber1], '') + ISNULL(' ' + [HouseAType2] + ' ' + [HouseANumber2], ''), '..', '.'), ',,', ',')
   FROM
	   [adm].[UF_HouseAggregate]() [H])