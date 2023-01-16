
CREATE VIEW [dbo].[V_CadastrNumber]
AS
SELECT
	[P].[ID]
  , [P].[OBJECTID]
  , [P].VALUE
FROM
	[dbo].[PARAM] [P]
WHERE([ENDDATE] > GETDATE()) AND ([TYPEID] = 8)