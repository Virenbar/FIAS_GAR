CREATE TABLE [dbo].[CHANGE_HISTORY] (
    [CHANGEID]    BIGINT        NOT NULL,
    [OBJECTID]    BIGINT        NOT NULL,
    [ADROBJECTID] VARCHAR (MAX) NOT NULL,
    [OPERTYPEID]  BIGINT        NOT NULL,
    [NDOCID]      BIGINT        NULL,
    [CHANGEDATE]  DATETIME      NOT NULL,
    CONSTRAINT [PK_CHANGE_HISTORY] PRIMARY KEY CLUSTERED ([CHANGEID] ASC)
);






GO
EXECUTE sp_addextendedproperty @name = N'CanImport', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CHANGE_HISTORY';

