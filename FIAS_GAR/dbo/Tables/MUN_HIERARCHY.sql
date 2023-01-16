CREATE TABLE [dbo].[MUN_HIERARCHY] (
    [ID]          BIGINT        NOT NULL,
    [OBJECTID]    BIGINT        NOT NULL,
    [PARENTOBJID] BIGINT        NULL,
    [CHANGEID]    BIGINT        NOT NULL,
    [OKTMO]       VARCHAR (11)  NULL,
    [PREVID]      BIGINT        NULL,
    [NEXTID]      BIGINT        NULL,
    [UPDATEDATE]  DATETIME      NOT NULL,
    [STARTDATE]   DATETIME      NOT NULL,
    [ENDDATE]     DATETIME      NOT NULL,
    [ISACTIVE]    BIT           NOT NULL,
    [PATH]        VARCHAR (MAX) NULL,
    CONSTRAINT [PK_MUN_HIERARCHY] PRIMARY KEY CLUSTERED ([ID] ASC)
);








GO
EXECUTE sp_addextendedproperty @name = N'CanImport', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MUN_HIERARCHY';

