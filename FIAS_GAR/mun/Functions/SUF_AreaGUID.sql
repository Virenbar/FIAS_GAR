﻿-- =============================================
-- Author:		Artyom
-- Create date:	22.03.2022
-- Description:	Получить код района
-- =============================================
CREATE FUNCTION [mun].[SUF_AreaGUID](
	@ObjectGUID CHAR(36))
RETURNS CHAR(36)
AS
BEGIN
	DECLARE @Result CHAR(36)

	SELECT TOP (1)
		@Result = [H].[GUID]
	FROM
		[mun].[UF_Hierarchy](@ObjectGUID) [H]
	WHERE [H].[Level] IN(2, 3)
	ORDER BY
		[H].[Level] DESC

	RETURN @Result
END