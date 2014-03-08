CREATE TABLE [dbo].[Category] (
    [CategoryID]     INT          NOT NULL,
    [CategoryName]   VARCHAR (20) NULL,
    [ParentCategory] INT          NULL,
    PRIMARY KEY CLUSTERED ([CategoryID] ASC),
    CONSTRAINT [ProductCategories_Parent] FOREIGN KEY ([ParentCategory]) REFERENCES [dbo].[Category] ([CategoryID])
);

