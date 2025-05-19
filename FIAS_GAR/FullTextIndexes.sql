


GO



GO



GO



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

