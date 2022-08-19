CREATE TABLE [dbo].[STEADS] (
    [ID]         BIGINT        NOT NULL,
    [OBJECTID]   BIGINT        NOT NULL,
    [OBJECTGUID] VARCHAR (MAX) NOT NULL,
    [CHANGEID]   BIGINT        NOT NULL,
    [NUMBER]     VARCHAR (250) NULL,
    [OPERTYPEID] VARCHAR (2)   NOT NULL,
    [PREVID]     BIGINT        NULL,
    [NEXTID]     BIGINT        NULL,
    [UPDATEDATE] DATETIME      NOT NULL,
    [STARTDATE]  DATETIME      NOT NULL,
    [ENDDATE]    DATETIME      NOT NULL,
    [ISACTUAL]   BIT           NOT NULL,
    [ISACTIVE]   BIT           NOT NULL,
    CONSTRAINT [PK_STEADS] PRIMARY KEY CLUSTERED ([ID] ASC)
);








GO
EXECUTE sp_addextendedproperty @name = N'CanImport', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'STEADS';

