-- =============================================
-- Author:		Artyom
-- Create date:	09.11.2021
-- Description:	Параметры по по типу
-- =============================================
CREATE FUNCTION [dbo].[UF_FIAS_ParametersByType](
	@TYPE INT)
RETURNS TABLE
AS
RETURN
   (
   SELECT
	   [P].[OBJECTID]
	 , [P].[VALUE]
	 , [PT].[NAME]
	 , [PT].[DESC]
   FROM
	   [PARAM] [P]
   JOIN [PARAM_TYPES] [PT] ON [PT].[ID] = [P].[TYPEID]
   WHERE [P].[ENDDATE] > GETDATE() AND [P].[TYPEID] = @TYPE)