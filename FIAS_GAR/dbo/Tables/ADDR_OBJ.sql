CREATE TABLE [dbo].[ADDR_OBJ] (
    [ID]         BIGINT        NOT NULL,
    [OBJECTID]   BIGINT        NOT NULL,
    [OBJECTGUID] VARCHAR (MAX) NOT NULL,
    [CHANGEID]   BIGINT        NOT NULL,
    [NAME]       VARCHAR (250) NOT NULL,
    [TYPENAME]   VARCHAR (50)  NOT NULL,
    [LEVEL]      VARCHAR (10)  NOT NULL,
    [OPERTYPEID] BIGINT        NOT NULL,
    [PREVID]     BIGINT        NULL,
    [NEXTID]     BIGINT        NULL,
    [UPDATEDATE] DATETIME      NOT NULL,
    [STARTDATE]  DATETIME      NOT NULL,
    [ENDDATE]    DATETIME      NOT NULL,
    [ISACTUAL]   BIT           NOT NULL,
    [ISACTIVE]   BIT           NOT NULL,
    CONSTRAINT [PK_ADDR_OBJ] PRIMARY KEY NONCLUSTERED ([ID] ASC)
);








GO
CREATE CLUSTERED INDEX [ClusteredIndex-20211206-181151]
    ON [dbo].[ADDR_OBJ]([OBJECTID] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'CanImport', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ADDR_OBJ';



