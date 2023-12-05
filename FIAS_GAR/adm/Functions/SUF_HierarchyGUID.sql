-- =============================================
-- Author:		Artyom
-- Create date:	18.03.2022
-- Description:	Получить GUID определенного уровня из иеархии объекта
-- =============================================
CREATE FUNCTION [adm].[SUF_HierarchyGUID](
	@ObjectGUID CHAR(36),
	@Level      INT)
RETURNS CHAR(36)
AS
BEGIN
	IF @ObjectGUID IS NULL
		RETURN NULL
	DECLARE @Result CHAR(36)

	SELECT TOP (1)
		@Result = [H].[GUID]
	FROM
		[adm].[UF_Hierarchy](@ObjectGUID) [H]
	WHERE [H].[Level] <= @Level
	ORDER BY
		[H].[Level] DESC

	RETURN @Result
END