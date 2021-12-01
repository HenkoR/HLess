CREATE TABLE [dbo].[Schema]
(
	[SchemaId] BIGINT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Definition] NVARCHAR(MAX) NOT NULL, 
    [DraftDefinition] NVARCHAR(MAX) NULL, 
    [CreatedBy] BIGINT NOT NULL, 
    [CreatedAt] DATETIMEOFFSET NOT NULL, 
    [LastModified] DATETIMEOFFSET NULL, 
    [FirstPublished] DATETIMEOFFSET NULL, 
    [LastPublished] DATETIMEOFFSET NULL, 
    [ApplicationId] BIGINT NOT NULL
)
