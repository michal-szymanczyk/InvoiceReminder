CREATE TABLE [dbo].[DocumentTypes] (
    [Id]   TINYINT           NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Reminders] (
    [Id]               SMALLINT      NOT NULL,
    [StartDate]        DATETIME NOT NULL,
    [EndDate]          DATETIME NULL,
    [ReminderInterval] INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[Documents]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [SubmitedDate] DATETIME NOT NULL, 
    [FileHash] NVARCHAR(50) NULL, 
    [TypeId] TINYINT NOT NULL, 
    [ReminderId] SMALLINT NULL, 
    CONSTRAINT [FK_Documents_ToDocumentTypes] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[DocumentTypes]([Id]), 
    CONSTRAINT [FK_Documents_ToReminders] FOREIGN KEY ([ReminderId]) REFERENCES [dbo].[Reminders]([Id])
)