CREATE TABLE [dbo].[History] (
    [HistoryId]        INT           IDENTITY (1, 1) NOT NULL,
    [UserId]           INT           NULL,
    [CompanyId]        INT           NULL,
    [ModuleName]       VARCHAR (30)  NOT NULL,
    [PropertyName]     VARCHAR (30)  NULL,
    [OldValue]         VARCHAR (MAX) NULL,
    [NewValue]         VARCHAR (MAX) NULL,
    [ModificationTime] DATETIME2 (7) NOT NULL,
    [ModificationType] CHAR (1)      NOT NULL,
    PRIMARY KEY CLUSTERED ([HistoryId] ASC)
);

