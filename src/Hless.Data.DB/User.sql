CREATE TABLE [dbo].[User]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Username] VARCHAR(50) NOT NULL, 
    [EmailAddress] VARCHAR(50) NOT NULL, 
    [Password] VARCHAR(50) NULL, 
    [admin] BIT NOT NULL, 
    [CreatedBy] BIGINT NOT NULL, 
    [UpdatedBy] BIGINT NOT NULL,
    CONSTRAINT [FK_CreatedBy_User_User] FOREIGN KEY ([CreatedBy]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_UpdatedBy_User_User] FOREIGN KEY ([UpdatedBy]) REFERENCES [User]([Id])
)
