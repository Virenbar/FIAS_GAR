-- =============================================
-- Author:		Artyom
-- Create date: 17.01.2022
-- Description:	Иеархия для объекта
-- =============================================
CREATE PROCEDURE [adm].[UP_GetHierarchy]
	@GUID CHAR(36)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		[H].[GUID]                                [ObjectGUID]
	  , [H].[Level]                               [Level]
	  , [H].[Type]                                [Type]
	  , [H].[Name]                                [Name]
	  , ISNULL([H].[Type] + ' ', '') + [H].[Name] [NameFull]
	FROM
		[adm].[UF_GetHierarchy](@GUID) [H]
	ORDER BY
		[H].[Level]

END