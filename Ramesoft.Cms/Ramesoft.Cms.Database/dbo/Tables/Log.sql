CREATE TABLE [dbo].[Log] (
    [LogId]          INT           IDENTITY (1, 1) NOT NULL,
    [CreateDate]     DATETIME2 (7) NOT NULL,
    [LogLevel]       VARCHAR (50)  NOT NULL,
    [Message]        VARCHAR (200) NOT NULL,
    [Exception]      VARCHAR (200) NOT NULL,
    [StackTrace]     VARCHAR (MAX) NULL,
    [InnerException] INT           NULL,
    PRIMARY KEY CLUSTERED ([LogId] ASC),
    CONSTRAINT [FK_Log_ToLog] FOREIGN KEY ([InnerException]) REFERENCES [dbo].[Log] ([LogId])
);

