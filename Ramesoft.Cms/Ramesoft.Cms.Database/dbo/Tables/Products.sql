CREATE TABLE [dbo].[Products] (
    [ProductID]         INT             NOT NULL,
    [ProductName]       VARCHAR (50)    NOT NULL,
    [CategoryID]        INT             NULL,
    [UnitName]          VARCHAR (20)    NULL,
    [UnitScale]         SMALLINT        NULL,
    [InStock]           INT             NULL,
    [Price]             DECIMAL (10, 2) NULL,
    [DiscontinuedPrice] DECIMAL (10, 2) NULL,
    [Discontinued]      BIT             NULL,
    [CompanyId] INT NULL, 
    PRIMARY KEY CLUSTERED ([ProductID] ASC),
    CONSTRAINT [Products_Category] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Category] ([CategoryID]), 
    CONSTRAINT [FK_Products_ToCompany] FOREIGN KEY ([COmpanyId]) REFERENCES [Company]([COmpanyId])
);

