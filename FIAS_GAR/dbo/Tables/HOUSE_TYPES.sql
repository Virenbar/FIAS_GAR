﻿CREATE TABLE [dbo].[HOUSE_TYPES] (
    [ID]         BIGINT        NOT NULL,
    [NAME]       VARCHAR (50)  NOT NULL,
    [SHORTNAME]  VARCHAR (50)  NULL,
    [DESC]       VARCHAR (250) NULL,
    [UPDATEDATE] DATETIME      NOT NULL,
    [STARTDATE]  DATETIME      NOT NULL,
    [ENDDATE]    DATETIME      NOT NULL,
    [ISACTIVE]   BIT           NOT NULL
);

