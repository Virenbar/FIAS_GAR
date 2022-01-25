-- =============================================
-- Author:		Artyom
-- Create date: 10.01.2022
-- Description:	Поиск в реестре по GUID
-- =============================================
CREATE PROCEDURE [dbo].[UP_SearchRegistryByGUID]
	@GUID  CHAR(36),
	@Level INT      = 0,
	@Limit INT      = 10
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP (@Limit)
		[R].*
	FROM
		[dbo].[A_IndexRegistry] [R]
	WHERE(@Level = 0 OR [R].[Level] = @Level) AND
		 ([R].[ParentGUID] = @GUID OR [R].[ObjectGUID] = @GUID)
	ORDER BY
		LEN([R].[AddressFull])
	  , [R].[AddressFull]

END