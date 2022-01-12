-- =============================================
-- Author:		Artyom
-- Create date: 08.12.2021
-- Description:	
-- =============================================
CREATE FUNCTION [adm].[SUF_GetParentGUID](
	@ObjectGUID CHAR(36))
RETURNS CHAR(36)
AS
BEGIN
	DECLARE @Result CHAR(36)

	SELECT TOP (1)
		@Result = [AO].[OBJECTGUID]
	FROM
		[ADDR_OBJ] [AO]
	JOIN [ADM_HIERARCHY] [P] ON [P].[PARENTOBJID] = [AO].[OBJECTID] AND
								[P].[ISACTIVE] = 1
	JOIN [REESTR_OBJECTS] [RO] ON [RO].[OBJECTID] = [P].[OBJECTID]
	WHERE [RO].[OBJECTGUID] = @ObjectGUID

	RETURN @Result

END