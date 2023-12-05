-- =============================================
-- Author:		Artyom
-- Create date:	26.09.2023
-- Description:	Получить наименование населенного пункта (Дом+)
-- =============================================
CREATE FUNCTION [adm].[SUF_VillageNameFull](
	@ObjectGUID CHAR(36))
RETURNS VARCHAR(1000)
AS
BEGIN
	DECLARE @Result VARCHAR(1000)

	SELECT TOP (1)
		@Result = [H].[NameFull]
	FROM
		[adm].[UF_Hierarchy](@ObjectGUID) [H]
	WHERE [H].[Level] IN(4, 5, 6)
	ORDER BY
		[H].[Level] DESC

	RETURN @Result
END