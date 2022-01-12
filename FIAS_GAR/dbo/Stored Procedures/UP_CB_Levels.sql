-- =============================================
-- Author:		Artyom
-- Create date: 12.12.2021
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[UP_CB_Levels]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		[LEVEL] [Level]
	  , [NAME]  [Name]
	FROM
		[OBJECT_LEVELS]
	WHERE [ENDDATE] > GETDATE()
	UNION ALL
	SELECT
		0       [Level]
	  , 'Любой' [Name]
END
