-- =============================================
-- Author:		Artyom
-- Create date:	10.01.2022
-- Description:	Дочерние объекты по GUID родителя
-- =============================================
CREATE PROCEDURE [dbo].[UP_RegistrySelectChild]
	@GUID CHAR(36)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		[R].*
	FROM
		[dbo].[A_IndexRegistry] [R]
	WHERE [R].[ParentGUID] = @GUID
	ORDER BY
		[R].[Name]

END