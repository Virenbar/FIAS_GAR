-- =============================================
-- Author:		Artyom
-- Create date:	09.11.2021
-- Description:	Все квартиры
-- =============================================
CREATE FUNCTION [adm].[UF_ApartmentsAggregateFull]()
RETURNS TABLE
AS
RETURN
   (
   SELECT DISTINCT
	   [A].*
	 , [ApartmentFull] = ISNULL([ApartmentType] + ' ' + [ApartmentNumber], '')
	 , [AddressFull] = ISNULL([VillageType] + ' ' + [VillageName] + ', ', '') + ISNULL([StreetType] + ' ' + [StreetName] + ', ', '') + ISNULL([HouseType] + ' ' + [HouseNumber], '') + ISNULL(' ' + [HouseAType1] + ' ' + [HouseANumber1], '') + ISNULL(' ' + [HouseAType2] + ' ' + [HouseANumber2], '') + ISNULL(', ' + [ApartmentType] + ' ' + [ApartmentNumber], '')
   FROM
	   [adm].[UF_ApartmentsAggregate]() [A])