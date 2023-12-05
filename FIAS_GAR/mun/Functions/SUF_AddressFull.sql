-- =============================================
-- Author:		Artyom
-- Create date:	08.12.2021
-- Description:	Получить полный адрес объекта по GUID
-- =============================================
CREATE FUNCTION [mun].[SUF_AddressFull](
	@ObjectGUID CHAR(36))
RETURNS VARCHAR(1000)
AS
BEGIN
	DECLARE @Result VARCHAR(1000)

	SELECT TOP (1)
		@Result = [H].[NameFull]
	FROM
		[mun].[UF_Hierarchy](@ObjectGUID) [H]
	WHERE [H].[Level] = 1

	RETURN @Result

END