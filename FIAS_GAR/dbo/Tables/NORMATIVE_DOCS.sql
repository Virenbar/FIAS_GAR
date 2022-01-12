﻿CREATE TABLE [dbo].[NORMATIVE_DOCS] (
    [ID]         BIGINT         NOT NULL,
    [NAME]       VARCHAR (8000) NOT NULL,
    [DATE]       DATETIME       NOT NULL,
    [NUMBER]     VARCHAR (150)  NOT NULL,
    [TYPE]       BIGINT         NOT NULL,
    [KIND]       BIGINT         NOT NULL,
    [UPDATEDATE] DATETIME       NOT NULL,
    [ORGNAME]    VARCHAR (255)  NULL,
    [REGNUM]     VARCHAR (100)  NULL,
    [REGDATE]    DATETIME       NULL,
    [ACCDATE]    DATETIME       NULL,
    [COMMENT]    VARCHAR (8000) NULL
);

