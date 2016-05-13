SET QUOTED_IDENTIFIER OFF;
GO
USE [InvoiceReminderDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DocCategoriesDocuments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Documents] DROP CONSTRAINT [FK_DocCategoriesDocuments];
GO
IF OBJECT_ID(N'[dbo].[FK_RemindersDocuments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Documents] DROP CONSTRAINT [FK_RemindersDocuments];
GO
IF OBJECT_ID(N'[dbo].[FK_Invoices_inherits_Documents]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Documents_Invoices] DROP CONSTRAINT [FK_Invoices_inherits_Documents];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Documents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Documents];
GO
IF OBJECT_ID(N'[dbo].[DocumentTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentTypes];
GO
IF OBJECT_ID(N'[dbo].[Reminders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reminders];
GO
IF OBJECT_ID(N'[dbo].[Documents_Invoices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Documents_Invoices];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------
CREATE TABLE [dbo].[DocumentTypes] (
    [Id]   TINYINT           NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[Reminders] (
    [Id]               SMALLINT      NOT NULL,
    [Name]         NVARCHAR (50) NOT NULL,
    [StartDate]        DATETIME NOT NULL,
    [EndDate]          DATETIME NULL,
    [ReminderInterval] INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO


CREATE TABLE [dbo].[Documents] (
    [Id]           INT           NOT NULL,
    [Name]         NVARCHAR (50) NOT NULL,
    [SubmitedDate] DATETIME      NOT NULL,
    [FileHash]     NVARCHAR (50) NULL,
    [TypeId]       TINYINT       NOT NULL,
    [ReminderId]   SMALLINT      NULL,
    [NetAmount] REAL NULL, 
    [TaxRate] TINYINT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Documents_ToDocumentTypes] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[DocumentTypes] ([Id]),
    CONSTRAINT [FK_Documents_ToReminders] FOREIGN KEY ([ReminderId]) REFERENCES [dbo].[Reminders] ([Id])
);
GO


-- --------------------------------------------------
-- Insert default system data
-- --------------------------------------------------
INSERT INTO [dbo].[DocumentTypes]
VALUES (0, N'standard'), (1, N'invoice');
GO

-- --------------------------------------------------
-- Insert test data
-- --------------------------------------------------
INSERT INTO [dbo].[Reminders]
VALUES (0, N'every 30 days', GETDATE(), NULL, 2592000);
GO

INSERT INTO [dbo].[Documents]
VALUES 
(0, N'first default document', GETDATE(), N'testHash', 0, NULL, NULL, NULL),
(1, N'first invoice', GETDATE(), N'someHash', 1, 0, 5432, 23),
(2, N'second invoice', GETDATE(), N'someHash2', 1, 0, 321, 8);
GO