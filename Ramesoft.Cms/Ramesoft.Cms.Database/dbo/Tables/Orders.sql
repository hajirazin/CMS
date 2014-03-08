CREATE TABLE [dbo].[Orders] (
    [OrderID]       INT             NOT NULL,
    [CompanyID]     INT             NULL,
    [ContactID]     INT             NULL,
    [OrderDate]     DATE            NOT NULL,
    [Freight]       DECIMAL (10, 2) NULL,
    [ShipDate]      DATE            NULL,
    [ShipCompanyID] INT             NULL,
    [Discount]      DECIMAL (10, 2) NULL,
    PRIMARY KEY CLUSTERED ([OrderID] ASC),
    CONSTRAINT [Orders_Company] FOREIGN KEY ([CompanyID]) REFERENCES [dbo].[Company] ([CompanyID]),
    CONSTRAINT [Orders_Contact] FOREIGN KEY ([ContactID]) REFERENCES [dbo].[ContactPerson] ([ContactID]),
    CONSTRAINT [Orders_ShipCompany] FOREIGN KEY ([ShipCompanyID]) REFERENCES [dbo].[Company] ([CompanyID])
);

