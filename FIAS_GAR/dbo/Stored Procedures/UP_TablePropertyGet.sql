-- =============================================
-- Author:		Artyom
-- Create date: 26.02.2021
-- Description:	Считывает свойство таблицы
-- =============================================
CREATE PROCEDURE [dbo].[UP_TablePropertyGet]
	@Table SYSNAME,
	@Name  SYSNAME
AS
BEGIN
	SELECT
		[EP].value
	FROM
		[fn_listextendedproperty](@Name, 'schema', 'dbo', 'table', @Table, DEFAULT, DEFAULT) [EP]
END