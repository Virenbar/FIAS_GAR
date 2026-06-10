-- =============================================
-- Author:		Artyom
-- Create date:	15.05.2026
-- Description:	Субъекты РФ
-- =============================================
CREATE PROCEDURE [dbo].[UP_Subjects]
AS
BEGIN
	-- EXEC dbo.[UP_Subjects]
	SET NOCOUNT ON;

	SELECT
		NULL                                            [ParentGUID]
	  , [RO].[OBJECTGUID]                               [ObjectGUID]
	  , CAST([RO].[LEVELID] AS INT)                     [Level]
	  , [AO].[TYPENAME]                                 [Type]
	  , [AO].[NAME]                                     [Name]
	  , ISNULL([AO].[TYPENAME] + ' ', '') + [AO].[NAME] [NameFull]
	  , ISNULL([AO].[TYPENAME] + ' ', '') + [AO].[NAME] [AddressFull]
	FROM
		[dbo].[REESTR_OBJECTS] [RO]
	JOIN [dbo].[ADDR_OBJ] [AO] ON [AO].[OBJECTID] = [RO].[OBJECTID] AND
								  [AO].[ISACTUAL] = 1
	WHERE [LEVELID] = 1 AND [RO].[ISACTIVE] = 1

END