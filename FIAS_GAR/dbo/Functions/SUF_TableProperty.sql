
-- =============================================
-- Author:		Artyom
-- Create date: 26.02.2021
-- Description:	Cвойство таблицы
-- =============================================
CREATE FUNCTION [dbo].[SUF_TableProperty](
	@Table SYSNAME,
	@Name  SYSNAME)
RETURNS SQL_VARIANT
AS
BEGIN
	DECLARE @Result SQL_VARIANT

	SELECT
		@Result = [EP].value
	FROM
		[fn_listextendedproperty](@Name, 'schema', 'dbo', 'table', @Table, NULL, NULL) [EP]

	RETURN @Result

END