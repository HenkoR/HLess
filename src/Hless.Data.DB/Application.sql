CREATE TABLE [dbo].[Application]
(
	[AppId] BIGINT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [OwnerId] BIGINT NOT NULL, 
    [CreatedBy] BIGINT NOT NULL, 
    [CreatedAt] DATETIMEOFFSET NOT NULL, 
    [LastModified] DATETIMEOFFSET NULL
)
