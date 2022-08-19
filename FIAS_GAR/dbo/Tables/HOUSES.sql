CREATE TABLE [dbo].[HOUSES] (
    [ID]         BIGINT        NOT NULL,
    [OBJECTID]   BIGINT        NOT NULL,
    [OBJECTGUID] VARCHAR (MAX) NOT NULL,
    [CHANGEID]   BIGINT        NOT NULL,
    [HOUSENUM]   VARCHAR (50)  NULL,
    [ADDNUM1]    VARCHAR (50)  NULL,
    [ADDNUM2]    VARCHAR (50)  NULL,
    [HOUSETYPE]  BIGINT        NULL,
    [ADDTYPE1]   BIGINT        NULL,
    [ADDTYPE2]   BIGINT        NULL,
    [OPERTYPEID] BIGINT        NOT NULL,
    [PREVID]     BIGINT        NULL,
    [NEXTID]     BIGINT        NULL,
    [UPDATEDATE] DATETIME      NOT NULL,
    [STARTDATE]  DATETIME      NOT NULL,
    [ENDDATE]    DATETIME      NOT NULL,
    [ISACTUAL]   BIT           NOT NULL,
    [ISACTIVE]   BIT           NOT NULL,
    CONSTRAINT [PK_HOUSES] PRIMARY KEY NONCLUSTERED ([ID] ASC)
);






GO
CREATE CLUSTERED INDEX [ClusteredIndex-20211206-180904]
    ON [dbo].[HOUSES]([OBJECTID] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'CanImport', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'HOUSES';

