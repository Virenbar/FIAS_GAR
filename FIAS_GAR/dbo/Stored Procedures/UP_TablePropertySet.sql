-- =============================================
-- Author:		Artyom
-- Create date: 26.07.2021
-- Description:	Установка свойства таблице
-- =============================================
CREATE PROCEDURE [dbo].[UP_TablePropertySet]
	@Table SYSNAME,
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
		WHERE [major_id] = OBJECT_ID(@Table) AND
			  [name] = @Name AND
			  [minor_id] = 0)
		EXEC [sp_addextendedproperty]
			@name = @Name
		  , @value = @Value
		  , @level0type = N'SCHEMA'
		  , @level0name = N'dbo'
		  , @level1type = N'TABLE'
		  , @level1name = @Table;
	ELSE
		EXEC [sp_updateextendedproperty]
			@name = @Name
		  , @value = @Value
		  , @level0type = N'SCHEMA'
		  , @level0name = N'dbo'
		  , @level1type = N'TABLE'
		  , @level1name = @Table;

END