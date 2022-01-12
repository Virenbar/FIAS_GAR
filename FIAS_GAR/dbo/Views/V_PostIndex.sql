
CREATE VIEW [dbo].[V_PostIndex]
AS
SELECT        ID, OBJECTID, VALUE
FROM            dbo.PARAM
WHERE        (ENDDATE > GETDATE()) AND (TYPEID = 5)
