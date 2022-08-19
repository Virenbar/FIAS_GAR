CREATE TABLE [dbo].[NORMATIVE_DOCS_KINDS] (
    [ID]   BIGINT        NOT NULL,
    [NAME] VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_NORMATIVE_DOCS_KINDS] PRIMARY KEY CLUSTERED ([ID] ASC)
);






GO
EXECUTE sp_addextendedproperty @name = N'CanImport', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'NORMATIVE_DOCS_KINDS';

