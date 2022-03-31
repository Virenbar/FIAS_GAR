-- =============================================
-- Author:		Artyom
-- Create date: 22.03.2022
-- Description:	Получить наименование района
-- =============================================
CREATE FUNCTION [mun].[SUF_AreaName](
	@ObjectGUID CHAR(36))
RETURNS CHAR(36)
AS
BEGIN
	DECLARE @Result CHAR(36)

	SELECT TOP (1)
		@Result = [H].[Type] + ' ' + [H].[Name]
	FROM
		[mun].[UF_GetHierarchy](@ObjectGUID) [H]
	WHERE [H].[Level] IN(2, 3)
	ORDER BY
		[H].[Level] DESC

	RETURN @Result
END