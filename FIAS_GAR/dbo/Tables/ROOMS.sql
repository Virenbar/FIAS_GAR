CREATE TABLE [dbo].[ROOMS] (
    [ID]         BIGINT        NOT NULL,
    [OBJECTID]   BIGINT        NOT NULL,
    [OBJECTGUID] VARCHAR (MAX) NOT NULL,
    [CHANGEID]   BIGINT        NOT NULL,
    [NUMBER]     VARCHAR (50)  NOT NULL,
    [ROOMTYPE]   BIGINT        NOT NULL,
    [OPERTYPEID] BIGINT        NOT NULL,
    [PREVID]     BIGINT        NULL,
    [NEXTID]     BIGINT        NULL,
    [UPDATEDATE] DATETIME      NOT NULL,
    [STARTDATE]  DATETIME      NOT NULL,
    [ENDDATE]    DATETIME      NOT NULL,
    [ISACTUAL]   BIT           NOT NULL,
    [ISACTIVE]   BIT           NOT NULL,
    CONSTRAINT [PK_ROOMS] PRIMARY KEY CLUSTERED ([ID] ASC)
);






GO
EXECUTE sp_addextendedproperty @name = N'CanImport', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ROOMS';

