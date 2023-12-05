-- =============================================
-- Author:		Artyom
-- Create date:	08.12.2021
-- Description:	Получить GUID родителя по GUID объекта
-- =============================================
CREATE FUNCTION [adm].[SUF_ParentGUID](
	@ObjectGUID CHAR(36))
RETURNS CHAR(36)
AS
BEGIN
	DECLARE @Result CHAR(36)

	SELECT TOP (1)
		@Result = [ROP].[OBJECTGUID]
	FROM
		[REESTR_OBJECTS] [RO]
	JOIN [ADM_HIERARCHY] [H] ON [H].[OBJECTID] = [RO].[OBJECTID] AND [H].[ISACTIVE] = 1
	JOIN [REESTR_OBJECTS] [ROP] ON [ROP].[OBJECTID] = [H].[PARENTOBJID] AND
								   [ROP].[ISACTIVE] = 1
	WHERE [RO].[OBJECTGUID] = @ObjectGUID AND [RO].[ISACTIVE] = 1

	RETURN @Result
END