﻿CREATE TABLE [dbo].[APARTMENT_TYPES] (
    [ID]         BIGINT        NOT NULL,
    [NAME]       VARCHAR (50)  NOT NULL,
    [SHORTNAME]  VARCHAR (50)  NULL,
    [DESC]       VARCHAR (250) NULL,
    [UPDATEDATE] DATETIME      NOT NULL,
    [STARTDATE]  DATETIME      NOT NULL,
    [ENDDATE]    DATETIME      NOT NULL,
    [ISACTIVE]   BIT           NOT NULL,
    CONSTRAINT [PK_APARTMENT_TYPES] PRIMARY KEY CLUSTERED ([ID] ASC)
);






GO
EXECUTE sp_addextendedproperty @name = N'CanImport', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'APARTMENT_TYPES';

