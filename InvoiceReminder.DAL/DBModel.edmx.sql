
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/11/2016 11:28:39
-- Generated from EDMX file: C:\Dev\workspace_net\InvoiceReminder\InvoiceReminder.DAL\DBModel.edmx
-- --------------------------------------------------

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

-- Creating table 'Documents'
CREATE TABLE [dbo].[Documents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [SubmitedDate] datetime  NOT NULL,
    [FileHash] nvarchar(max)  NOT NULL,
    [DocumentType_Id] int  NOT NULL,
    [Reminder_Id] int  NULL
);
GO

-- Creating table 'DocumentTypes'
CREATE TABLE [dbo].[DocumentTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Reminders'
CREATE TABLE [dbo].[Reminders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [StartDate] nvarchar(max)  NOT NULL,
    [EndDate] nvarchar(max)  NULL,
    [RemindInterval] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Documents_Invoices'
CREATE TABLE [dbo].[Documents_Invoices] (
    [NetAmount] float  NOT NULL,
    [TaxRate] float  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Documents'
ALTER TABLE [dbo].[Documents]
ADD CONSTRAINT [PK_Documents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DocumentTypes'
ALTER TABLE [dbo].[DocumentTypes]
ADD CONSTRAINT [PK_DocumentTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Reminders'
ALTER TABLE [dbo].[Reminders]
ADD CONSTRAINT [PK_Reminders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Documents_Invoices'
ALTER TABLE [dbo].[Documents_Invoices]
ADD CONSTRAINT [PK_Documents_Invoices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DocumentType_Id] in table 'Documents'
ALTER TABLE [dbo].[Documents]
ADD CONSTRAINT [FK_DocCategoriesDocuments]
    FOREIGN KEY ([DocumentType_Id])
    REFERENCES [dbo].[DocumentTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocCategoriesDocuments'
CREATE INDEX [IX_FK_DocCategoriesDocuments]
ON [dbo].[Documents]
    ([DocumentType_Id]);
GO

-- Creating foreign key on [Reminder_Id] in table 'Documents'
ALTER TABLE [dbo].[Documents]
ADD CONSTRAINT [FK_RemindersDocuments]
    FOREIGN KEY ([Reminder_Id])
    REFERENCES [dbo].[Reminders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RemindersDocuments'
CREATE INDEX [IX_FK_RemindersDocuments]
ON [dbo].[Documents]
    ([Reminder_Id]);
GO

-- Creating foreign key on [Id] in table 'Documents_Invoices'
ALTER TABLE [dbo].[Documents_Invoices]
ADD CONSTRAINT [FK_Invoices_inherits_Documents]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Documents]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------