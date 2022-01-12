-- =============================================
-- Author:		Artyom
-- Create date:	09.11.2021
-- Description:	Улицы по по коду родителя
-- =============================================
CREATE PROCEDURE [mun].[UP_FIAS_StreetsByParentID]
	@ParentID INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		[S].[OBJECTID]
	  , [S].[OBJECTGUID]
	  , [S].[NAME]
	  , [S].[TYPENAME]
	  , [ST].[NAME]
	  , [KLADR].[VALUE]
	FROM
		[MUN_HIERARCHY] [CC]
	JOIN [ADDR_OBJ] [S] ON [S].[OBJECTID] = [CC].[OBJECTID] AND [S].[LEVEL] = 8
	LEFT JOIN [ADDR_OBJ_TYPES] [ST] ON [ST].[SHORTNAME] = [S].[TYPENAME] AND [ST].[LEVEL] = 8
	LEFT JOIN [PARAM] [KLADR] ON [KLADR].[OBJECTID] = [S].[OBJECTID] AND
								 [KLADR].[TYPEID] = 10
	--left join V_Parameters KLADR on KLADR.OBJECTID=S.OBJECTID and KLADR.TYPEID=10
	--LEFT JOIN [UF_FIAS_ParametersByType](10) [KLADR] ON [KLADR].[OBJECTID] = [S].[OBJECTID]
	WHERE [CC].[PARENTOBJID] = @ParentID AND
		  [S].[ISACTIVE] = 1 AND
		  [S].[ENDDATE] > GETDATE() AND
		  [KLADR].[ENDDATE] > GETDATE()
	ORDER BY
		[S].[OBJECTID]
END
