CREATE TABLE [dbo].[A_IndexStreet] (
    [StreetGUID]  VARCHAR (36)  NOT NULL,
    [StreetName]  VARCHAR (250) NOT NULL,
    [AddressFull] VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_A_IndexStreet] PRIMARY KEY CLUSTERED ([StreetGUID] ASC)
);

