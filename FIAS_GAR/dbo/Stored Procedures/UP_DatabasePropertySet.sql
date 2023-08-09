-- =============================================
-- Author:		Artyom
-- Create date: 13.06.2023
-- Description:	Установка свойства базы данных
-- =============================================
CREATE PROCEDURE [dbo].[UP_DatabasePropertySet]
	@Name  SYSNAME,
	@Value SQL_VARIANT
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS
	   (SELECT
			NULL
		FROM
			[SYS].[EXTENDED_PROPERTIES]
		WHERE [name] = @Name AND [major_id] = 0 AND [minor_id] = 0)
		EXEC [sp_addextendedproperty]
			@name = @Name
		  , @value = @Value;
	ELSE
		EXEC [sp_updateextendedproperty]
			@name = @Name
		  , @value = @Value;

END