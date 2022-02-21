


GO
CREATE FULLTEXT INDEX ON [dbo].[A_IndexStreet]
    ([AddressFull] LANGUAGE 1049)
    KEY INDEX [PK_A_IndexStreet]
    ON [IndexCatalog]
    WITH STOPLIST OFF;


GO
CREATE FULLTEXT INDEX ON [dbo].[A_IndexHouse]
    ([AddressFull] LANGUAGE 1049)
    KEY INDEX [PK_A_IndexHouse]
    ON [IndexCatalog]
    WITH STOPLIST OFF;


GO
CREATE FULLTEXT INDEX ON [dbo].[A_IndexApartment]
    ([AddressFull] LANGUAGE 1049)
    KEY INDEX [PK_A_IndexApartment]
    ON [IndexCatalog]
    WITH STOPLIST OFF;


GO
CREATE FULLTEXT INDEX ON [mun].[A_IndexRegistry]
    ([AddressFull] LANGUAGE 1049)
    KEY INDEX [PK_A_IndexRegistry]
    ON [IndexCatalog]
    WITH STOPLIST OFF;


GO
CREATE FULLTEXT INDEX ON [adm].[A_IndexRegistry]
    ([AddressFull] LANGUAGE 1049)
    KEY INDEX [PK_A_IndexRegistry]
    ON [IndexCatalog]
    WITH STOPLIST OFF;

