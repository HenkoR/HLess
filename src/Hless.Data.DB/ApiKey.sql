CREATE TABLE [dbo].[ApiKey]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Key] VARCHAR(50) NOT NULL, 
    [UserId] BIGINT NOT NULL, 
    [ApplicationId] BIGINT NOT NULL, 
    CONSTRAINT [FK_ApiKey_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_ApiKey_Application] FOREIGN KEY ([ApplicationId]) REFERENCES [Application]([AppId])
)