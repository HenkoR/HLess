CREATE TABLE [dbo].[Schema]
(
	[SchemaId] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Definition] NVARCHAR(MAX) NOT NULL, 
    [DraftDefinition] NVARCHAR(MAX) NULL, 
    [CreatedBy] BIGINT NOT NULL, 
    [CreatedAt] DATETIME NOT NULL, 
    [LastModified] DATETIMEOFFSET NULL, 
    [FirstPublished] DATETIMEOFFSET NULL, 
    [LastPublished] DATETIMEOFFSET NULL, 
    [ApplicationId] BIGINT NOT NULL
    CONSTRAINT [FK_CreatedBy_Schema_User] FOREIGN KEY ([CreatedBy]) REFERENCES [User]([Id])
    CONSTRAINT [FK_Schema_Application] FOREIGN KEY ([ApplicationId]) REFERENCES [Application]([AppId])
)