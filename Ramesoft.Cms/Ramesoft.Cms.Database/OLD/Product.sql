CREATE TABLE [old].[Product] (
    [ProductId]     INT          IDENTITY (1, 1) NOT NULL,
    [ProductName]   VARCHAR (50) NOT NULL,
    [SubCategoryId] INT          NOT NULL,
    [CompanyId]     INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([ProductId] ASC),
    CONSTRAINT [FK_Product_ToCompany] FOREIGN KEY ([CompanyId]) REFERENCES [old].[Company] ([CompanyId]),
    CONSTRAINT [FK_Product_ToSubCategory] FOREIGN KEY ([SubCategoryId]) REFERENCES [old].[SubCategory] ([SubCategoryId])
);

