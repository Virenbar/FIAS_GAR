-- =============================================
-- Author:		Artyom
-- Create date:	14.05.2024
-- Description:	Проверка наличия букв в строке
-- =============================================
CREATE FUNCTION [dbo].[SUF_HasLetter](
	@String VARCHAR(500))
RETURNS BIT
AS
BEGIN
	RETURN IIF(@String LIKE '%[a-zA-Zа-яА-Я]%', 1, 0)
END