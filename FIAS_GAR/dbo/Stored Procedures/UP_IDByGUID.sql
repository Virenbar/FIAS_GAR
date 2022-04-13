-- =============================================
-- Author:		Artyom
-- Create date: 06.04.2022
-- Description:	ID объект по GUID
-- =============================================
CREATE PROCEDURE [dbo].[UP_IDByGUID]
	@GUID CHAR(36)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1
		[R].[OBJECTID]
	FROM
		[dbo].[REESTR_OBJECTS] [R]
	WHERE [R].[ObjectGUID] = @GUID

END