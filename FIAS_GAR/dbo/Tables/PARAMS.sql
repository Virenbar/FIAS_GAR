CREATE TABLE [dbo].[PARAMS] (
    [ID]          BIGINT         NOT NULL,
    [OBJECTID]    BIGINT         NOT NULL,
    [CHANGEID]    BIGINT         NULL,
    [CHANGEIDEND] BIGINT         NOT NULL,
    [TYPEID]      BIGINT         NOT NULL,
    [VALUE]       VARCHAR (8000) NOT NULL,
    [UPDATEDATE]  DATETIME       NOT NULL,
    [STARTDATE]   DATETIME       NOT NULL,
    [ENDDATE]     DATETIME       NOT NULL,
    CONSTRAINT [PK_PARAMS] PRIMARY KEY CLUSTERED ([ID] ASC)
);






GO
EXECUTE sp_addextendedproperty @name = N'CanImport', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PARAMS';

