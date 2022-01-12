-- =============================================
-- Author:		Artyom
-- Create date:	09.11.2021
-- Description:	Все улицы
-- =============================================
CREATE FUNCTION [adm].[UF_StreetAggregateFull]()
RETURNS TABLE
AS
RETURN
   (
   SELECT DISTINCT
	   [S].*
	 , [StreetFull] = ISNULL([StreetType] + ' ' + [StreetName], '')
	 , [AddressFull] = [VillageType] + ' ' + [VillageName] + ', ' + ISNULL([StreetType] + ' ' + [StreetName], '')
   FROM
	   [adm].[UF_StreetAggregate]() [S])