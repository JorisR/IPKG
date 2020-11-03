CREATE TABLE [dbo].[Route]
(
	[Reference] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[DepartureParking] nvarchar(10) not null,
	[DestinationParking] nvarchar(10) not null,
	[Distance] float not null,
	[AverageFuelConsumption] float not null
)
