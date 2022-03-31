-- =============================================
-- Author:		Artyom
-- Create date:	16.03.2022
-- Description:
-- Подготовка адреса для полнотекстового поиска
-- Замена всех лишних символов на пробелы
-- Prepare UrAnus
-- =============================================
CREATE FUNCTION [dbo].[SUF_PrepareAddress](
	@Address VARCHAR(500))
RETURNS VARCHAR(500)
AS
BEGIN
	DECLARE @Result VARCHAR(500)
	--
	SET @Address = REPLACE(@Address, '5я', '5')
	SET @Address = REPLACE(@Address, 'Килачевское', 'Килачёвское')
	--
	SET @Address = REPLACE(@Address, '-го', ' ')
	SET @Address = REPLACE(@Address, 'г.', ' ')
	SET @Address = REPLACE(@Address, 'г ', ' ')
	SET @Address = REPLACE(@Address, 'ст.', ' ')
	SET @Address = REPLACE(@Address, 'п.', ' ')
	SET @Address = REPLACE(@Address, 'пр-д.', ' ')
	SET @Address = REPLACE(@Address, 'пр-д ', ' ')
	--SET @Address = REPLACE(@Address, 'пер.', ' ')
	--SET @Address = REPLACE(@Address, 'пер ', ' ')
	--SET @Address = REPLACE(@Address, 'ул.', ' ')
	--SET @Address = REPLACE(@Address, 'ул ', ' ')
	SET @Address = REPLACE(@Address, 'д.', ' ')
	SET @Address = REPLACE(@Address, 'д ', ' ')
	SET @Address = REPLACE(@Address, 'дом ', ' ')
	SET @Address = REPLACE(@Address, '-я', ' ')

	SET @Address = REPLACE(@Address, '1-й', ' ')
	SET @Address = REPLACE(@Address, '2-й', ' ')
	-- Половинки домов
	SET @Address = REPLACE(@Address, '_1', ' ')
	SET @Address = REPLACE(@Address, '_2', ' ')
	SET @Address = REPLACE(@Address, '/1', ' ')
	SET @Address = REPLACE(@Address, '/2', ' ')
	SET @Address = REPLACE(@Address, 'кв1', ' ')
	SET @Address = REPLACE(@Address, 'кв2', ' ')
	-- Замена лишних пробелов
	SET @Address = REPLACE(@Address, '  ', ' ')
	SET @Address = REPLACE(@Address, '  ', ' ')
	SET @Address = REPLACE(@Address, '  ', ' ')
	SET @Address = REPLACE(@Address, '  ', ' ')

	SET @Address = LTRIM(RTRIM(@Address))

	RETURN @Address

END