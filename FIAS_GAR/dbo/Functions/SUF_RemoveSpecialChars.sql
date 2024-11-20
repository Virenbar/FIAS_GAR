-- =============================================
-- Author:		Artyom
-- Create date:	16.03.2022
-- Description: Замена всех лишних символов на пробелы
-- =============================================
CREATE FUNCTION [dbo].[SUF_RemoveSpecialChars](
	@Address VARCHAR(500))
RETURNS VARCHAR(500)
AS
BEGIN
	-- Специальные символы
	SET @Address = REPLACE(@Address, '	', ' ')
	SET @Address = REPLACE(@Address, '''', ' ')
	SET @Address = REPLACE(@Address, '-', ' ')
	SET @Address = REPLACE(@Address, '"', ' ')
	SET @Address = REPLACE(@Address, ',', ' ')
	SET @Address = REPLACE(@Address, '.', ' ')
	SET @Address = REPLACE(@Address, '/', ' ')
	SET @Address = REPLACE(@Address, '_', ' ')
	-- Замена лишних пробелов
	SET @Address = REPLACE(@Address, '  ', ' ')
	SET @Address = REPLACE(@Address, '  ', ' ')
	SET @Address = REPLACE(@Address, '  ', ' ')
	SET @Address = REPLACE(@Address, '  ', ' ')
	--
	SET @Address = REPLACE(@Address, ' *', '*')

	SET @Address = LTRIM(RTRIM(@Address))
	RETURN @Address
END