-- =============================================
-- Author:		https://stackoverflow.com/questions/7892334/get-size-of-all-tables-in-database
-- Create date:	22.08.2022
-- Description:	Данные о таблицах
-- select * from dbo.UF_TablesInfo()
-- =============================================
CREATE FUNCTION [dbo].[UF_TablesInfo]()
RETURNS TABLE
AS
RETURN
   (
   SELECT
	   [t].[object_id]                                                                              [object_id]
	 , [s].[name]                                                                                   [SchemaName]
	 , [t].[name]                                                                                   [TableName]
	   -- 0=Heap; 1=Clustered; 5=Clustered Columnstore
	 , CASE
		   WHEN [i].[type] IN(0, 1, 5) THEN NULL
				  ELSE [i].[name]
	   END                                                                                          [IndexName]
	 , CASE
		   WHEN [i].[type] IN(0, 1, 5) THEN 'TABLE'
		   ELSE 'INDEX'
	   END                                                                                          [ObjectType]
	 , [i].[type_desc]                                                                              [IndexType]
	 , [p].[rows]                                                                                   [RowCount]
	 , CAST(ROUND(([au].[total_pages] * (8 / 1024.00)), 2) AS DECIMAL(36, 2))                       [TotalMB]
	 , CAST(ROUND(([au].[used_pages] * (8 / 1024.00)), 2) AS DECIMAL(36, 2))                        [UsedMB]
	 , CAST(ROUND((([au].[total_pages] - [au].[used_pages]) * (8 / 1024.00)), 2) AS DECIMAL(36, 2)) [UnusedMB]
   FROM
	   [sys].[schemas] [s]
   JOIN [sys].[tables] [t] ON [s].schema_id = [t].schema_id
   JOIN [sys].[indexes] [i] ON [t].object_id = [i].object_id
   JOIN
	  (SELECT
		  [object_id]
		, [index_id]
		, [partition_count] = COUNT(*)
		, [rows] = SUM([rows])
		, [data_compression_cnt] = COUNT(DISTINCT [data_compression])
	   FROM
		  [sys].[partitions]
	   GROUP BY
		  [object_id]
		, [index_id]) [p] ON [i].[object_id] = [p].[object_id] AND
							 [i].[index_id] = [p].[index_id]
   JOIN
	  (SELECT
		  [p].[object_id]
		, [p].[index_id]
		, [total_pages] = SUM([a].[total_pages])
		, [used_pages] = SUM([a].[used_pages])
		, [data_pages] = SUM([a].[data_pages])
	   FROM
		  [sys].[partitions] [p]
	   JOIN [sys].[allocation_units] [a] ON [p].[partition_id] = [a].[container_id]
	   GROUP BY
		  [p].[object_id]
		, [p].[index_id]) [au] ON [i].[object_id] = [au].[object_id] AND
								  [i].[index_id] = [au].[index_id]
   WHERE [t].[is_ms_shipped] = 0)