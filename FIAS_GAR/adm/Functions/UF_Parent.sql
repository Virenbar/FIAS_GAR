-- =============================================
-- Author:		Artyom
-- Create date: 08.12.2021
-- Description:	
-- =============================================
CREATE FUNCTION [adm].[UF_Parent](
	@ObjectGUID CHAR(36))
RETURNS TABLE
AS
RETURN
   (
   SELECT TOP (1)
	   [AO].*
   FROM
	   [ADDR_OBJ] [AO]
   JOIN [ADM_HIERARCHY] [P] ON [P].[PARENTOBJID] = [AO].[OBJECTID]
   JOIN [REESTR_OBJECTS] [RO] ON [RO].[OBJECTID] = [P].[OBJECTID]
   WHERE [RO].[OBJECTGUID] = @ObjectGUID)