﻿CREATE TABLE [dbo].[PARAMS] (
    [ID]          BIGINT         NOT NULL,
    [OBJECTID]    BIGINT         NOT NULL,
    [CHANGEID]    BIGINT         NULL,
    [CHANGEIDEND] BIGINT         NOT NULL,
    [TYPEID]      BIGINT         NOT NULL,
    [VALUE]       VARCHAR (8000) NOT NULL,
    [UPDATEDATE]  DATETIME       NOT NULL,
    [STARTDATE]   DATETIME       NOT NULL,
    [ENDDATE]     DATETIME       NOT NULL
);

