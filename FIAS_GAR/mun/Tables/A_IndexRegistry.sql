CREATE TABLE [mun].[A_IndexRegistry] (
    [ParentGUID]  CHAR (36)      NULL,
    [ObjectGUID]  CHAR (36)      NOT NULL,
    [Level]       INT            NOT NULL,
    [Type]        VARCHAR (50)   NULL,
    [Name]        VARCHAR (250)  NOT NULL,
    [NameFull]    VARCHAR (250)  NOT NULL,
    [AddressFull] VARCHAR (1000) NULL,
    CONSTRAINT [PK_A_IndexRegistry] PRIMARY KEY CLUSTERED ([ObjectGUID] ASC)
);






GO
CREATE UNIQUE NONCLUSTERED INDEX [NCI_ParentObject]
    ON [mun].[A_IndexRegistry]([ParentGUID] ASC, [ObjectGUID] ASC);


GO
CREATE NONCLUSTERED INDEX [NCI_Include]
    ON [mun].[A_IndexRegistry]([ParentGUID] ASC)
    INCLUDE([ObjectGUID], [Level], [Type], [Name], [NameFull]);

