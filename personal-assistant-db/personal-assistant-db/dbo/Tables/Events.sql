CREATE TABLE [dbo].[Events] (
    [EventId]    INT         NOT NULL IDENTITY(1,1),
	[Id]	UNIQUEIDENTIFIER DEFAULT NEWID(),
    PRIMARY KEY NONCLUSTERED ([Id] ASC),
    [Title] NVARCHAR (128) NOT NULL,
    [Date] DATETIME2 NOT NULL,
    [Description] NVARCHAR(1024) NULL, 
    [UserId] UNIQUEIDENTIFIER NULL, 
    [GroupId] UNIQUEIDENTIFIER NULL, 
    [CreatedAt] DATETIME2(3) NOT NULL DEFAULT SYSDATETIME(), 
    [ModifiedAt] DATETIME2(3) NOT NULL DEFAULT SYSDATETIME(), 
    [CreatedBy] UNIQUEIDENTIFIER NOT NULL, 
    [ModifiedBy] UNIQUEIDENTIFIER NOT NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1
    
);
GO;
CREATE CLUSTERED INDEX IX_EVENTS_EVENTID ON [dbo].[Events] ([EventId] ASC);
GO;
CREATE TRIGGER TR_EVENTS_UPDATE on [dbo].[Events] AFTER UPDATE AS
    UPDATE [dbo].[Events]
    SET ModifiedAt = SYSDATETIME()
    FROM Inserted i
    where [dbo].[Events].Id = i.Id
GO;

-- TODO Add FK for UserId and GroupId upon completion of those tables