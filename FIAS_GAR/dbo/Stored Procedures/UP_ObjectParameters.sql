-- =============================================
-- Author:		Artyom
-- Create date:	12.02.2024
-- Description:	Параметры объекта
-- =============================================
CREATE PROCEDURE [dbo].[UP_ObjectParameters]
	@GUID CHAR(36)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ID BIGINT
	SET @ID = [dbo].[SUF_GUIDToID](@GUID)

	SELECT
		  [Name] + IIF([Count] = 1, '', ' #' + CONVERT(VARCHAR(10), [Number])) [Name]
		, [Value]                                                             
	FROM (SELECT
		  [NAME]                             [Name]
		, ROW_NUMBER() OVER(PARTITION BY [NAME]
		ORDER BY
		[VALUE])                             [Number]
		, [P].[VALUE]                        [Value]
		, COUNT(*) OVER(PARTITION BY [NAME]) [Count]
	FROM [V_Parameters] [P]
	WHERE
		[P].[OBJECTID] = @ID) [x]

-- EXEC [UP_ObjectParameters] 'f31f9c11-a888-41c2-9cb2-9f86c486fecc'
-- EXEC [UP_ObjectParameters] 'b5475007-a8ec-4a44-ae4e-b86b35921cbe'
-- EXEC [UP_ObjectParameters] 'e592bad8-b6d2-46cb-be91-0a7356327d71'
END