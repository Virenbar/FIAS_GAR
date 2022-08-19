CREATE TABLE [dbo].[NORMATIVE_DOCS] (
    [ID]         BIGINT         NOT NULL,
    [NAME]       VARCHAR (8000) NULL,
    [DATE]       DATETIME       NOT NULL,
    [NUMBER]     VARCHAR (150)  NOT NULL,
    [TYPE]       BIGINT         NOT NULL,
    [KIND]       BIGINT         NOT NULL,
    [UPDATEDATE] DATETIME       NOT NULL,
    [ORGNAME]    VARCHAR (255)  NULL,
    [REGNUM]     VARCHAR (100)  NULL,
    [REGDATE]    DATETIME       NULL,
    [ACCDATE]    DATETIME       NULL,
    [COMMENT]    VARCHAR (8000) NULL,
    CONSTRAINT [PK_NORMATIVE_DOCS] PRIMARY KEY CLUSTERED ([ID] ASC)
);








GO
EXECUTE sp_addextendedproperty @name = N'CanImport', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'NORMATIVE_DOCS';

