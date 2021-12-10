CREATE TABLE [dbo].[Content]
(
	[ContentId] BIGINT NOT NULL PRIMARY KEY, 
    [SchemaId] BIGINT NOT NULL, 
    [Content] NVARCHAR(MAX) NOT NULL, 
    [Draft] NVARCHAR(MAX) NULL, 
    [CreatedBy] BIGINT NOT NULL, 
    [CreatedAt] DATETIMEOFFSET NOT NULL, 
    [LastModified] DATETIMEOFFSET NULL, 
    [FirstPublished] DATETIMEOFFSET NULL, 
    [LastPublished] DATETIMEOFFSET NULL,
    CONSTRAINT [FK_CreatedBy_Content_User] FOREIGN KEY ([CreatedBy]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_Content_Schema] FOREIGN KEY ([SchemaId]) REFERENCES [Schema]([SchemaId])
)
