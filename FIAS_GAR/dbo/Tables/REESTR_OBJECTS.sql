CREATE TABLE [dbo].[REESTR_OBJECTS] (
    [OBJECTID]   BIGINT        NOT NULL,
    [CREATEDATE] DATETIME      NOT NULL,
    [CHANGEID]   BIGINT        NOT NULL,
    [LEVELID]    BIGINT        NOT NULL,
    [UPDATEDATE] DATETIME      NOT NULL,
    [OBJECTGUID] VARCHAR (MAX) NOT NULL,
    [ISACTIVE]   BIT           NOT NULL,
    CONSTRAINT [PK_REESTR_OBJECTS] PRIMARY KEY CLUSTERED ([OBJECTID] ASC)
);






GO
EXECUTE sp_addextendedproperty @name = N'CanImport', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'REESTR_OBJECTS';

