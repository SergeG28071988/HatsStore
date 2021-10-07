CREATE TABLE Orders (
	[OrderId] INT Identity NOT NULL,
	[Name] NVARCHAR(MAX) NULL,
	[Line1] NVARCHAR(MAX) NULL,
	[Line2] NVARCHAR(MAX) NULL,
	[Line3] NVARCHAR(MAX) NULL,
	[City] NVARCHAR(MAX) NULL,
	[GiftWrap] BIT NOT NULL,
	[Dispatched] BIT NOT NULL,
	CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED ([OrderId] ASC)
);

CREATE TABLE OrderLines (
	[OrderLineId] INT IDENTITY NOT NULL,
	[Quantity] INT NOT NULL,
	[Hat_HatID] INT NULL,
	[Order_OrderId] INT NULL,
	CONSTRAINT [PK_dbo.OrderLines] PRIMARY KEY CLUSTERED ([OrderLineId] ASC),
	CONSTRAINT [FK_dbo.OrderLines_dbo.Hats_HatID] FOREIGN KEY
		([Hat_HatID]) REFERENCES [dbo].[Hats] ([HatID]),
	CONSTRAINT [FK_dbo.OrderLines_dbo.Order_OrderId] FOREIGN KEY
		([Order_OrderId]) REFERENCES [dbo].[Orders] ([OrderId])
);