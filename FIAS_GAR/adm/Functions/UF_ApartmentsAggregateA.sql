-- =============================================
-- Author:		Artyom
-- Create date:	09.11.2021
-- Description:	Все квартиры
-- =============================================
CREATE FUNCTION [adm].[UF_ApartmentsAggregateA]()
RETURNS TABLE
AS
RETURN
   (
   SELECT DISTINCT
	   [H].*
	 , [A].[OBJECTID]   [ApartmentID]
	 , [A].[OBJECTGUID] [ApartmentGUID]
	 , [AT].[SHORTNAME] [ApartmentType]
	 , [A].[NUMBER]     [ApartmentNumber]
   FROM
	   [APARTMENTS] [A]
   JOIN [ADM_HIERARCHY] [AP] ON [AP].[OBJECTID] = [A].[OBJECTID]
   JOIN [adm].[UF_HouseAggregate]() [H] ON [H].[HouseID] = [AP].[PARENTOBJID]
   -- Типы
   LEFT JOIN [APARTMENT_TYPES] [AT] ON AT.[ID] = [A].[APARTTYPE]
   WHERE [A].[ENDDATE] > GETDATE())