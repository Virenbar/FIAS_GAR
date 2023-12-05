-- =============================================
-- Author:		Artyom
-- Create date: 26.09.2023
-- Description:	Получить наименование адреса от указаного уровня
-- =============================================
CREATE FUNCTION [mun].[SUF_AddressPart](
	@ObjectGUID CHAR(36),
	@Level      INT)
RETURNS VARCHAR(1000)
AS
BEGIN
	DECLARE @Result VARCHAR(1000)

	SELECT TOP (1)
		@Result = [H].[NameFull]
	FROM
		[mun].[UF_Hierarchy](@ObjectGUID) [H]
	WHERE [H].[Level] >= @Level
	ORDER BY
		[H].[Level] ASC

	RETURN @Result
END