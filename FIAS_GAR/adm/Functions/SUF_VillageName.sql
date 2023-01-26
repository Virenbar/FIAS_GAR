-- =============================================
-- Author:		Artyom
-- Create date: 22.03.2022
-- Description:	Получить наименование населенного пункта
-- =============================================
CREATE FUNCTION [adm].[SUF_VillageName](
	@ObjectGUID CHAR(36))
RETURNS VARCHAR(100)
AS
BEGIN
	DECLARE @Result VARCHAR(100)

	SELECT TOP (1)
		@Result = [H].[Type] + ' ' + [H].[Name]
	FROM
		[adm].[UF_GetHierarchy](@ObjectGUID) [H]
	WHERE [H].[Level] IN(4, 5, 6)
	ORDER BY
		[H].[Level] DESC

	RETURN @Result
END