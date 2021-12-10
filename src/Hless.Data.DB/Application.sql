CREATE TABLE [dbo].[Application]
(
	[AppId] BIGINT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [OwnerId] BIGINT NOT NULL, 
    [CreatedBy] BIGINT NOT NULL, 
    [CreatedAt] DATETIMEOFFSET NOT NULL, 
    [LastModified] DATETIMEOFFSET NULL, 
    CONSTRAINT [FK_OwnerId_Application_User] FOREIGN KEY ([OwnerId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_CreatedBy_Application_User] FOREIGN KEY ([CreatedBy]) REFERENCES [User]([Id])
)
