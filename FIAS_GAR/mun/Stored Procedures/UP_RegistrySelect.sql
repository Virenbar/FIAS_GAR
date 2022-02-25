-- =============================================
-- Author:		Artyom
-- Create date: 10.01.2022
-- Description:	Объект из реестра по GUID
-- =============================================
CREATE PROCEDURE [mun].[UP_RegistrySelect]
	@GUID CHAR(36)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1
		[R].*
	FROM
		[mun].[A_IndexRegistry] [R]
	WHERE [R].[ObjectGUID] = @GUID

END