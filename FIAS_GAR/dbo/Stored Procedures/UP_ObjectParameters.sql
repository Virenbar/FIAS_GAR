-- =============================================
-- Author:		Artyom
-- Create date:	12.02.2024
-- Description:	Параметры объекта
-- =============================================
CREATE PROCEDURE [dbo].[UP_ObjectParameters]
	@GUID CHAR(36)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ID BIGINT
	SET @ID = [dbo].[SUF_GUIDToID](@GUID)

	SELECT
		[P].[NAME]  [Name]
	  , [P].[VALUE] [Value]
	FROM
		[V_Parameters] [P]
	WHERE [P].[OBJECTID] = @ID
	-- EXEC [UP_ObjectParameters] 'f31f9c11-a888-41c2-9cb2-9f86c486fecc'
END