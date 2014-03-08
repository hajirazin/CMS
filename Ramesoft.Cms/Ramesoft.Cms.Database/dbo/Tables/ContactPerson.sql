CREATE TABLE [dbo].[ContactPerson] (
    [ContactID]    INT           NOT NULL,
    [Title]        VARCHAR (8)   NULL,
    [FirstName]    VARCHAR (50)  NULL,
    [MiddleName]   VARCHAR (50)  NULL,
    [LastName]     VARCHAR (50)  NULL,
    [CompanyID]    INT           NULL,
    [HomePhone]    VARCHAR (25)  NULL,
    [MobilePhone]  VARCHAR (25)  NULL,
    [AddressTitle] VARCHAR (120) NULL,
    [Address]      VARCHAR (60)  NULL,
    [City]         VARCHAR (30)  NULL,
    [Region]       VARCHAR (20)  NULL,
    [PostalCode]   VARCHAR (15)  NULL,
    [Country]      VARCHAR (20)  NULL,
    [Phone]        VARCHAR (25)  NULL,
    [Fax]          VARCHAR (25)  NULL,
    [UserId] INT NULL, 
    PRIMARY KEY CLUSTERED ([ContactID] ASC),
    CONSTRAINT [PersonContact_Company] FOREIGN KEY ([CompanyID]) REFERENCES [dbo].[Company] ([CompanyID]), 
    CONSTRAINT [FK_ContactPerson_User] FOREIGN KEY (UserId) REFERENCES UserProfile(userid)
);

