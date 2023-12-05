-- =============================================
-- Author:		Artyom
-- Create date:	22.03.2022
-- Description:	Получить наименование населенного пункта
-- =============================================
CREATE FUNCTION [mun].[SUF_VillageName](
	@ObjectGUID CHAR(36))
RETURNS VARCHAR(1000)
AS
BEGIN
	DECLARE @Result VARCHAR(1000)

	SELECT TOP (1)
		@Result = [H].[Type] + ' ' + [H].[Name]
	FROM
		[mun].[UF_Hierarchy](@ObjectGUID) [H]
	WHERE [H].[Level] IN(4, 5, 6)
	ORDER BY
		[H].[Level] DESC

	RETURN @Result
END