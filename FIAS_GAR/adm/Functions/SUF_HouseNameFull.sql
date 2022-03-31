-- =============================================
-- Author:		Artyom
-- Create date: 22.03.2022
-- Description:	Получить полное наименование дома (Улица+)
-- =============================================
CREATE FUNCTION [adm].[SUF_HouseNameFull](
	@ObjectGUID CHAR(36))
RETURNS VARCHAR(1000)
AS
BEGIN
	DECLARE @Result VARCHAR(1000)

	SELECT TOP (1)
		@Result = [H].[NameFull]
	FROM
		[adm].[UF_GetHierarchy](@ObjectGUID) [H]
	WHERE [H].[Level] = 8

	RETURN @Result
END