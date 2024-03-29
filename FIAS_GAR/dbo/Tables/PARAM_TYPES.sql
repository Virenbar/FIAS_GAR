﻿CREATE TABLE [dbo].[PARAM_TYPES] (
    [ID]         BIGINT        NOT NULL,
    [NAME]       VARCHAR (50)  NOT NULL,
    [CODE]       VARCHAR (50)  NOT NULL,
    [DESC]       VARCHAR (120) NULL,
    [UPDATEDATE] DATETIME      NOT NULL,
    [STARTDATE]  DATETIME      NOT NULL,
    [ENDDATE]    DATETIME      NOT NULL,
    [ISACTIVE]   BIT           NOT NULL,
    CONSTRAINT [PK_PARAM_TYPES] PRIMARY KEY CLUSTERED ([ID] ASC)
);






GO
EXECUTE sp_addextendedproperty @name = N'CanImport', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PARAM_TYPES';

