CREATE TABLE [dbo].[A_IndexApartment] (
    [ApartmentGUID] VARCHAR (36)  NOT NULL,
    [ApartmentName] VARCHAR (250) NOT NULL,
    [AddressFull]   VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_A_IndexApartment] PRIMARY KEY CLUSTERED ([ApartmentGUID] ASC)
);

