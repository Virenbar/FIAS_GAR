-- =============================================
-- Author:		Artyom
-- Create date: 05.12.2021
-- Description:	Обновить индекс
-- =============================================
CREATE PROCEDURE [dbo].[UP_RefreshIndex]
AS
BEGIN
	SET NOCOUNT ON;

	TRUNCATE TABLE [A_IndexVillage]
	INSERT INTO [A_IndexVillage](
		[VillageGUID]
	  , [VillageName]
	  , [AddressFull])
	SELECT DISTINCT
		[V].[VillageGUID]
	  , [V].[VillageFull]
	  , [V].[AddressFull]
	FROM
		[adm].[UF_VillageAggregateFull]() [V]

	TRUNCATE TABLE [A_IndexStreet]
	INSERT INTO [A_IndexStreet](
		[StreetGUID]
	  , [StreetName]
	  , [AddressFull])
	SELECT DISTINCT
		[S].[StreetGUID]
	  , [S].[StreetFull]
	  , [S].[AddressFull]
	FROM
		[adm].[UF_StreetAggregateFull]() [S]

	TRUNCATE TABLE [A_IndexHouse]
	INSERT INTO [A_IndexHouse](
		[HouseGUID]
	  , [HouseName]
	  , [AddressFull])
	SELECT DISTINCT
		[H].[HouseGUID]
	  , [H].[HouseFull]
	  , [H].[AddressFull]
	FROM
		[adm].[UF_HouseAggregateFull]() [H]

	TRUNCATE TABLE [A_IndexApartment]
	INSERT INTO [A_IndexApartment](
		[ApartmentGUID]
	  , [ApartmentName]
	  , [AddressFull])
	SELECT DISTINCT
		[A].[ApartmentGUID]
	  , [A].[ApartmentFull]
	  , [A].[AddressFull]
	FROM
		[adm].[UF_ApartmentsAggregateFull]() [A]
END