-- =============================================
-- Author:		Artyom
-- Create date:	11.11.2021
-- Description:	Полный адрес квартиры
-- =============================================
CREATE FUNCTION [adm].[UF_FullApartment](
	@ApartmentID BIGINT)
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @Full VARCHAR(MAX)

	SELECT
		@Full = [A].[VillageType] + '.' + [VillageName] + ',' + ISNULL([StreetType] + '.' + [StreetName] + ',', ',') + ISNULL([HouseType] + [HouseNumber], '') + ISNULL([HouseAType1] + [HouseANumber1], '') + ISNULL([HouseAType2] + [HouseANumber2], '') + ',' + [ApartmentType] + '.' + [ApartmentNumber]
	FROM
		[adm].[UF_ApartmentsAggregate]() [A]
	WHERE [A].[ApartmentID] = @ApartmentID

	RETURN replace(@Full, '..', '.')

END
