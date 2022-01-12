CREATE TABLE [dbo].[A_IndexHouse] (
    [HouseGUID]   VARCHAR (36)  NOT NULL,
    [HouseName]   VARCHAR (250) NOT NULL,
    [AddressFull] VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_A_IndexHouse] PRIMARY KEY NONCLUSTERED ([HouseGUID] ASC)
);


GO
CREATE UNIQUE CLUSTERED INDEX [ClusteredIndex-20211209-094648]
    ON [dbo].[A_IndexHouse]([HouseGUID] ASC, [AddressFull] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'Описание', @value = N'Индекс для поиска GIUD дома по адресу', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'A_IndexHouse';

