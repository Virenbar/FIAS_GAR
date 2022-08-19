CREATE TABLE [dbo].[NORMATIVE_DOCS_TYPES] (
    [ID]        BIGINT        NOT NULL,
    [NAME]      VARCHAR (500) NOT NULL,
    [STARTDATE] DATETIME      NOT NULL,
    [ENDDATE]   DATETIME      NOT NULL,
    CONSTRAINT [PK_NORMATIVE_DOCS_TYPES] PRIMARY KEY CLUSTERED ([ID] ASC)
);






GO
EXECUTE sp_addextendedproperty @name = N'CanImport', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'NORMATIVE_DOCS_TYPES';

