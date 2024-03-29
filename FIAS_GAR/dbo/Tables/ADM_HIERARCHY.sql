﻿CREATE TABLE [dbo].[ADM_HIERARCHY] (
    [ID]          BIGINT        NOT NULL,
    [OBJECTID]    BIGINT        NOT NULL,
    [PARENTOBJID] BIGINT        NULL,
    [CHANGEID]    BIGINT        NOT NULL,
    [REGIONCODE]  VARCHAR (4)   NULL,
    [AREACODE]    VARCHAR (4)   NULL,
    [CITYCODE]    VARCHAR (4)   NULL,
    [PLACECODE]   VARCHAR (4)   NULL,
    [PLANCODE]    VARCHAR (4)   NULL,
    [STREETCODE]  VARCHAR (4)   NULL,
    [PREVID]      BIGINT        NULL,
    [NEXTID]      BIGINT        NULL,
    [UPDATEDATE]  DATETIME      NOT NULL,
    [STARTDATE]   DATETIME      NOT NULL,
    [ENDDATE]     DATETIME      NOT NULL,
    [ISACTIVE]    BIT           NOT NULL,
    [PATH]        VARCHAR (MAX) NULL,
    CONSTRAINT [PK_ADM_HIERARCHY] PRIMARY KEY NONCLUSTERED ([ID] ASC)
);








GO
CREATE CLUSTERED INDEX [ClusteredIndex-20211110-144134]
    ON [dbo].[ADM_HIERARCHY]([OBJECTID] ASC, [PARENTOBJID] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'CanImport', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ADM_HIERARCHY';

