CREATE TABLE [dbo].[Company] (
    [CompanyID]      INT           NOT NULL,
    [CompanyName]    VARCHAR (40)  NOT NULL,
    [PrimaryContact] INT           NULL,
    [Web]            VARCHAR (100) NULL,
    [Email]          VARCHAR (50)  NULL,
    [AddressTitle]   VARCHAR (120) NULL,
    [Address]        VARCHAR (60)  NULL,
    [City]           VARCHAR (30)  NULL,
    [Region]         VARCHAR (20)  NULL,
    [PostalCode]     VARCHAR (15)  NULL,
    [Country]        VARCHAR (20)  NULL,
    [Phone]          VARCHAR (25)  NULL,
    [Fax]            VARCHAR (25)  NULL,
    PRIMARY KEY CLUSTERED ([CompanyID] ASC),
    CONSTRAINT [Company_PrimaryContact] FOREIGN KEY ([PrimaryContact]) REFERENCES [dbo].[ContactPerson] ([ContactID])
);

