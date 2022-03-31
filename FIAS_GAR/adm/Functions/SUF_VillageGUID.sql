-- =============================================
-- Author:		Artyom
-- Create date: 22.03.2022
-- Description:	Получить код населенного пункта
-- =============================================
CREATE FUNCTION [adm].[SUF_VillageGUID](
	@ObjectGUID CHAR(36))
RETURNS CHAR(36)
AS
BEGIN
	DECLARE @Result CHAR(36)

	SELECT TOP (1)
		@Result = [H].[GUID]
	FROM
		[adm].[UF_GetHierarchy](@ObjectGUID) [H]
	WHERE [H].[Level] IN(4, 5, 6)
	ORDER BY
		[H].[Level] DESC

	RETURN @Result
END