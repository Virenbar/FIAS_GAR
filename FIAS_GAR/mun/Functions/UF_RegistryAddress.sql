-- =============================================
-- Author:		Artyom
-- Create date: 01.11.2024
-- Description:	Рекурсивно(от субъекта) выводит все полные адреса объектов
-- =============================================
CREATE FUNCTION [mun].[UF_RegistryAddress]()
RETURNS TABLE
AS
RETURN
WITH [Address](
	[ParentGUID]
  , [ObjectGUID]
  , [Level]
  , [Type]
  , [Name]
  , [NameFull]
  , [AddressFull])
	 AS (SELECT
			 [R].[ParentGUID]
		   , [R].[ObjectGUID]
		   , [R].[Level]
		   , [R].[Type]
		   , [R].[Name]
		   , [R].[NameFull]
		   , CAST([R].[NameFull] AS VARCHAR(1000)) [AddressFull]
		 FROM
			 [mun].[A_IndexRegistry] [R]
		 WHERE [R].[ParentGUID] IS NULL AND [Level] = 1
		 UNION ALL
		 SELECT
			 [R].[ParentGUID]
		   , [R].[ObjectGUID]
		   , [R].[Level]
		   , [R].[Type]
		   , [R].[Name]
		   , [R].[NameFull]
		   , CAST(([A].[AddressFull] + ', ' + [R].[NameFull]) AS VARCHAR(1000)) [AddressFull]
		 FROM
			 [Address] [A]
		 JOIN [mun].[A_IndexRegistry] [R] ON [R].[ParentGUID] = [A].[ObjectGUID])
	 --
	 SELECT
		 [A].[ObjectGUID]
	   , [A].[Level]
	   , [A].[Type]
	   , [A].[Name]
	   , [A].[NameFull]
	   , [A].[AddressFull]
	 FROM
		 [Address] [A]