CREATE TABLE [dbo].[User] (
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_User_Id] DEFAULT (newid()) NOT NULL,
    [Name]      VARCHAR (100)    NOT NULL,
    [Email]     VARCHAR (100)    NOT NULL,
    [Password]  VARCHAR (100)    NOT NULL,
    [Address]   VARCHAR (1000)   NULL,
    [IsActive]  BIT              NOT NULL,
    [CreatedOn] DATETIME         CONSTRAINT [DF_User_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [UpdatedOn] DATETIME         NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

