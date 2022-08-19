CREATE TABLE [dbo].[ADDR_OBJ_DIVISION] (
    [ID]       BIGINT NOT NULL,
    [PARENTID] BIGINT NOT NULL,
    [CHILDID]  BIGINT NOT NULL,
    [CHANGEID] BIGINT NOT NULL,
    CONSTRAINT [PK_ADDR_OBJ_DIVISION] PRIMARY KEY CLUSTERED ([ID] ASC)
);






GO
EXECUTE sp_addextendedproperty @name = N'CanImport', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ADDR_OBJ_DIVISION';

