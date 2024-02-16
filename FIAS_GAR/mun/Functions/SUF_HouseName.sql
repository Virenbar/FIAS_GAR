-- =============================================
-- Author:		Artyom
-- Create date:	29.01.2024
-- Description:	Получить наименование дома
-- =============================================
CREATE FUNCTION [mun].[SUF_HouseName](
	@ObjectGUID CHAR(36))
RETURNS VARCHAR(1000)
AS
BEGIN
	DECLARE @Result VARCHAR(1000)

	SELECT TOP (1)
		@Result = [H].[Type] + ' ' + [H].[Name]
	FROM
		[mun].[UF_Hierarchy](@ObjectGUID) [H]
	WHERE [H].[Level] = 10

	RETURN @Result
END