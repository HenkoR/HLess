CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [EmailAddress] VARCHAR(50) NOT NULL, 
    [ApiKey] VARCHAR(50) NULL, 
    [admin] BIT NOT NULL, 
    [CreatedBy] INT NOT NULL, 
    [UpdatedBy] INT NOT NULL
)
