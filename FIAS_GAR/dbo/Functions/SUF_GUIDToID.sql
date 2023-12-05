-- =============================================
-- Author:		Artyom
-- Create date:	16.12.2022
-- Description:	Получить ID объекта по GUID
-- =============================================
CREATE FUNCTION [dbo].[SUF_GUIDToID](
	@GUID CHAR(36))
RETURNS BIGINT
AS
BEGIN
	DECLARE @Result BIGINT

	SELECT TOP 1
		@Result = [R].[OBJECTID]
	FROM
		[dbo].[REESTR_OBJECTS] [R]
	WHERE [R].[ObjectGUID] = @GUID AND [R].[ISACTIVE] = 1

	RETURN @Result
END