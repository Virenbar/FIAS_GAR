-- =============================================
-- Author:		Artyom
-- Create date:	13.06.2023
-- Description:	Считывает свойство базы данных
-- =============================================
CREATE PROCEDURE [dbo].[UP_DatabasePropertyGet]
	@Name SYSNAME
AS
BEGIN
	SELECT
		[EP].value
	FROM
		[fn_listextendedproperty](@Name, DEFAULT, DEFAULT, DEFAULT, DEFAULT, DEFAULT, DEFAULT) [EP]
END