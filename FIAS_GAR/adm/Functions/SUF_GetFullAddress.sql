-- =============================================
-- Author:		Artyom
-- Create date: 08.12.2021
-- Description:	
-- =============================================
CREATE FUNCTION [adm].[SUF_GetFullAddress](
	@ObjectGUID CHAR(36))
RETURNS VARCHAR(1000)
AS
BEGIN
	DECLARE @Result VARCHAR(1000)

	SELECT TOP (1)
		@Result = [H].[NameFull]
	FROM
		[adm].[UF_GetHierarchy](@ObjectGUID) [H]
	WHERE [H].[Level] = 1

	RETURN @Result

END