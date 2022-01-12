-- =============================================
-- Author:		Artyom
-- Create date:	11.11.2021
-- Description:	Полный адрес дома
-- =============================================
CREATE FUNCTION [adm].[UF_FullHouse](
	@HouseID BIGINT)
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @Full VARCHAR(MAX)

	SELECT
		@Full = [VillageType] + ' ' + [VillageName] + ', ' + ISNULL([StreetType] + ' ' + [StreetName] + ', ', '') + ISNULL([HouseType] + ' ' + [HouseNumber], '') + ISNULL(' ' + [HouseAType1] + ' ' + [HouseANumber1], '') + ISNULL(' ' + [HouseAType2] + ' ' + [HouseANumber2], '')
	FROM
		[adm].[UF_HouseAggregate]() [H]
	WHERE [H].[HouseID] = @HouseID

	RETURN replace(@Full, '..', '.')

END