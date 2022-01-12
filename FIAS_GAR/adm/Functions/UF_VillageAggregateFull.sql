-- =============================================
-- Author:		Artyom
-- Create date:	09.11.2021
-- Description:	Все нас.пункты (Уровень 5 и 6)
-- =============================================
CREATE FUNCTION [adm].[UF_VillageAggregateFull]()
RETURNS TABLE
AS
RETURN
   (
   SELECT DISTINCT
	   [V].*
	 , [VillageFull] = [VillageType] + ' ' + [VillageName]
	 , [AddressFull] = [VillageType] + ' ' + [VillageName]
   FROM
	   [adm].[UF_VillageAggregate]() [V])