﻿-- =============================================
-- Author:		Artyom
-- Create date:	22.03.2022
-- Description:	Получить наименование района
-- =============================================
CREATE FUNCTION [adm].[SUF_AreaName](
	@ObjectGUID CHAR(36))
RETURNS VARCHAR(1000)
AS
BEGIN
	DECLARE @Result VARCHAR(1000)

	SELECT TOP (1)
		@Result = [H].[Type] + ' ' + [H].[Name]
	FROM
		[adm].[UF_Hierarchy](@ObjectGUID) [H]
	WHERE [H].[Level] IN(2, 3)
	ORDER BY
		[H].[Level] DESC

	RETURN @Result
END