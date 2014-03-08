CREATE TABLE [dbo].[OrderDetails] (
    [OrderID]   INT             NOT NULL,
    [ProductID] INT             NOT NULL,
    [Price]     DECIMAL (10, 2) NULL,
    [Quantity]  DECIMAL (10, 4) NULL,
    PRIMARY KEY CLUSTERED ([OrderID] ASC, [ProductID] ASC),
    CONSTRAINT [OrderDetails_Order] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([OrderID]),
    CONSTRAINT [OrderDetails_Product] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID])
);

