﻿-- =============================================
-- Author:		Artyom
-- Create date: 15.12.2021
-- Description:	Минимизация адреса для сравнения с другим адресом
-- =============================================
CREATE FUNCTION [dbo].[SUF_MinifyAddress](
	@Address VARCHAR(500))
RETURNS VARCHAR(500)
AS
BEGIN

	DECLARE @Result VARCHAR(500)
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
	-- Половинки домов
	SET @Address = REPLACE(@Address, '_1', ' ')
	SET @Address = REPLACE(@Address, '_2', ' ')
	SET @Address = REPLACE(@Address, '/1', ' ')
	SET @Address = REPLACE(@Address, '/2', ' ')
	SET @Address = REPLACE(@Address, '''', ' ')
	SET @Address = REPLACE(@Address, '-', ' ')
	SET @Address = REPLACE(@Address, '"', ' ')
	SET @Address = REPLACE(@Address, ',', ' ')
	SET @Address = REPLACE(@Address, '.', ' ')
	-- Убрать все лишние пробелы
	SET @Address = REPLACE(@Address, '  ', ' ')
	SET @Address = REPLACE(@Address, '  ', ' ')
	SET @Address = REPLACE(@Address, '  ', ' ')
	SET @Address = REPLACE(@Address, '  ', ' ')

	SET @Address = LTRIM(RTRIM(@Address))

	RETURN @Address

END