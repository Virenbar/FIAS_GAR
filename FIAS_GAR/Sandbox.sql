/****** Скрипт для команды SelectTopNRows из среды SSMS  ******/
SELECT TOP (1000) [LEVEL]
      ,[NAME]
      ,[SHORTNAME]
      ,[UPDATEDATE]
      ,[STARTDATE]
      ,[ENDDATE]
      ,[ISACTIVE]
  FROM [FIAS_GAR].[dbo].[OBJECT_LEVELS]

--  85c6fd64-b630-408a-9c35-8462366f1ed3 обл Свердловская, р-н Ирбитский, п Рябиновый, ул Тихая, д. 2
 -- 476f70e2-5b63-4bf9-a213-f826ac1d3a8e обл Свердловская, г Красноуфимск, пер Рябиновый, д. 12

SELECT
	*
FROM
	[adm].[UF_GetHierarchy]('177c10d7-f36f-449e-a94b-5f7f45a0dbc8')

SELECT
	*
FROM
	[mun].[UF_GetHierarchy]('177c10d7-f36f-449e-a94b-5f7f45a0dbc8')


	select mun.SUF_AreaName('85c6fd64-b630-408a-9c35-8462366f1ed3')
	select mun.SUF_VillageName('85c6fd64-b630-408a-9c35-8462366f1ed3')
	select mun.SUF_HouseNameFull('85c6fd64-b630-408a-9c35-8462366f1ed3')
	select adm.SUF_AreaName('85c6fd64-b630-408a-9c35-8462366f1ed3')
	select adm.SUF_VillageName('85c6fd64-b630-408a-9c35-8462366f1ed3')
	select adm.SUF_HouseNameFull('85c6fd64-b630-408a-9c35-8462366f1ed3')

SELECT	* FROM	[adm].[UF_GetHierarchy]('476f70e2-5b63-4bf9-a213-f826ac1d3a8e')

SELECT	* FROM	[mun].[UF_GetHierarchy]('476f70e2-5b63-4bf9-a213-f826ac1d3a8e')

select *,mun.SUF_AreaName(FIAS_GUID) from TechPris.dbo.S_Address
where  mun.SUF_AreaGUID(FIAS_GUID)='8d80baaf-fe7c-4021-87f5-e8b2826aa6ab'
	

SELECT DISTINCT
	[FIAS_GAR].[mun].[SUF_AreaName]([FIAS_GUID])
  , [FIAS_GAR].[mun].[SUF_AreaGUID]([FIAS_GUID])
  , [FIAS_GAR].[adm].[SUF_AreaName]([FIAS_GUID])
  , [FIAS_GAR].[adm].[SUF_AreaGUID]([FIAS_GUID])
FROM
	[S_Address]
WHERE [FIAS_GUID] IS NOT NULL

-- Поиск GUID адреса
SELECT
	[mun].[SUF_Search]([dbo].[SUF_ExpressionNEAR]('Екатеринбург Екатеринбург Уральска 5'), 10, DEFAULT) [GUID]

SELECT
	[A].*
  , [R].[AddressFull]
FROM
   (SELECT
	   [Name]
	 , [mun].[SUF_Search]([dbo].[SUF_ExpressionNEAR]([Name]), 10, DEFAULT) [GUID]
	FROM
	   (VALUES('Екатеринбург Екатеринбург Уральска 5'), ('Екатеринбург Екатеринбург Уральска 1')) [Address]([Name])) [A]
LEFT JOIN [mun].[A_IndexRegistry] [R] ON [R].[ObjectGUID] = [A].[GUID]

SELECT
	[A].*
  , [R].[AddressFull]
FROM
	(VALUES('Екатеринбург Екатеринбург Уральска 5'), ('Екатеринбург Екатеринбург Уральска 1')) [A]([Name])
LEFT JOIN [mun].[A_IndexRegistry] [R] ON [R].[ObjectGUID] = [mun].[SUF_Search]([dbo].[SUF_ExpressionNEAR]([A].[Name]), 10, DEFAULT)