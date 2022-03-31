-- =============================================
-- Author:		Artyom
-- Create date:	16.03.2022
-- Description: Создает выражение для полнотекстового поиска испольхуя AND
-- =============================================
CREATE FUNCTION [dbo].[SUF_ExpressionAND](
	@Address VARCHAR(500))
RETURNS VARCHAR(500)
AS
BEGIN
	DECLARE @Result VARCHAR(500), @Prefix VARCHAR(500)
	DECLARE @I INT
	SET @I = CHARINDEX('|', @Address)
	IF @I > 0
	BEGIN
		SET @Prefix = SUBSTRING(@Address, 1, @I - 1)
		SET @Address = SUBSTRING(@Address, @I + 1, LEN(@Address))
	END

	SET @Address = [dbo].[SUF_RemoveSpecialChars](@Address)
	SET @Prefix = [dbo].[SUF_RemoveSpecialChars](@Prefix)

	SET @Result = ISNULL('"' + REPLACE(@Prefix, ' ', '" AND "') + '"' + ' AND ', '') + '"' + REPLACE(@Address, ' ', '*" AND "') + '"'
	RETURN @Result
END