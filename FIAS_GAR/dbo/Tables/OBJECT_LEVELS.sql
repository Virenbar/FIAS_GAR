CREATE TABLE [dbo].[OBJECT_LEVELS] (
    [LEVEL]      BIGINT        NOT NULL,
    [NAME]       VARCHAR (250) NOT NULL,
    [SHORTNAME]  VARCHAR (50)  NULL,
    [UPDATEDATE] DATETIME      NOT NULL,
    [STARTDATE]  DATETIME      NOT NULL,
    [ENDDATE]    DATETIME      NOT NULL,
    [ISACTIVE]   BIT           NOT NULL,
    CONSTRAINT [PK_OBJECT_LEVELS] PRIMARY KEY CLUSTERED ([LEVEL] ASC)
);






GO
EXECUTE sp_addextendedproperty @name = N'CanImport', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OBJECT_LEVELS';

