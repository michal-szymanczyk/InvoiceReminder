SET QUOTED_IDENTIFIER OFF;
GO
USE [InvoiceReminderDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Documents_ToDocumentTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Documents] DROP CONSTRAINT [FK_Documents_ToDocumentTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_Documents_ToReminders]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Documents] DROP CONSTRAINT [FK_Documents_ToReminders];
GO
IF OBJECT_ID(N'[dbo].[FK_Invoices_ToDocuments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Invoices] DROP CONSTRAINT [FK_Invoices_ToDocuments];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Invoices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Invoices];
GO
IF OBJECT_ID(N'[dbo].[Documents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Documents];
GO
IF OBJECT_ID(N'[dbo].[DocumentTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentTypes];
GO
IF OBJECT_ID(N'[dbo].[Reminders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reminders];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------
CREATE TABLE [dbo].[DocumentTypes] (
    [Id]   TINYINT           IDENTITY(1,1),
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

-- Reminder Interval values:
-- 1 - every day
-- 2 - every week
-- 3 - monthly
CREATE TABLE [dbo].[Reminders] (
    [Id]               SMALLINT      IDENTITY(1,1),
    [Name]         NVARCHAR (50) NOT NULL,
    [StartDate]        DATETIME NOT NULL,
    [EndDate]          DATETIME NULL,
    [ReminderInterval] TINYINT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[Documents] (
    [Id]           INT           IDENTITY(1,1),
    [Name]         NVARCHAR (50) NOT NULL,
    [SubmitedDate] DATETIME      NOT NULL,
    [FileHash]     NVARCHAR (50) NULL,
    [TypeId]       TINYINT       NOT NULL,
    [ReminderId]   SMALLINT      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Documents_ToDocumentTypes] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[DocumentTypes] ([Id]),
    CONSTRAINT [FK_Documents_ToReminders] FOREIGN KEY ([ReminderId]) REFERENCES [dbo].[Reminders] ([Id])
);
GO

CREATE TABLE [dbo].[Invoices] (
    [DocumentId]           INT           NOT NULL UNIQUE,
    [NetAmount] REAL NOT NULL, 
    [TaxRate] TINYINT NOT NULL,
    CONSTRAINT [FK_Invoices_ToDocuments] FOREIGN KEY ([DocumentId]) REFERENCES [dbo].[Documents] ([Id])
);
GO

-- --------------------------------------------------
-- Insert default system data
-- --------------------------------------------------


INSERT INTO dbo.DocumentTypes VALUES (N'default'); -- should be id = 1
INSERT INTO dbo.DocumentTypes VALUES (N'invoice'); -- should be id = 2

INSERT INTO dbo.Reminders VALUES (N'monthly reminder', GETDATE(), NULL, 3);
INSERT INTO dbo.Reminders VALUES (N'weekly reminder', GETDATE(), NULL, 2);
INSERT INTO dbo.Reminders VALUES (N'daily reminder', GETDATE(), NULL, 1);
INSERT INTO dbo.Reminders VALUES (N'no reminder', GETDATE(), NULL, 1);


DECLARE @stdDocTypeId AS TINYINT;
DECLARE @invoiceTypeId AS TINYINT;
DECLARE @monthlyReminderId AS TINYINT;

SET @stdDocTypeId = (SELECT TOP(1) Id FROM DocumentTypes WHERE Name = N'default');
SET @invoiceTypeId = (SELECT TOP(1) Id FROM DocumentTypes WHERE Name = N'invoice');
SET @monthlyReminderId = (SELECT TOP(1) Id FROM Reminders WHERE Name = N'monthly reminder');

INSERT INTO Documents VALUES 
(N'first standard document', GETDATE(), N'someHASH', @stdDocTypeId, @monthlyReminderId),
(N'first invoice', GETDATE(), N'someHASH2', @invoiceTypeId, @monthlyReminderId),
(N'second invoice', GETDATE(), N'someHASH3', @invoiceTypeId, @monthlyReminderId);


INSERT INTO Invoices SELECT Id, 123, 23 FROM Documents WHERE TypeId = @invoiceTypeId;

GO