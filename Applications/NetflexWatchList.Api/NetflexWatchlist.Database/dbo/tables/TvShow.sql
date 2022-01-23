CREATE TABLE [dbo].[TvShow] (
    [Id]          UNIQUEIDENTIFIER CONSTRAINT [DF_TvShow_Id] DEFAULT (newid()) NOT NULL,
    [IMDbId]      VARCHAR (50)     NOT NULL,
    [Title]       VARCHAR (200)    NOT NULL,
    [FullTitle]   VARCHAR (200)    NULL,
    [Image]       VARCHAR (500)    NOT NULL,
    [Plot]        VARCHAR (2000)   NULL,
    [Description] VARCHAR (2000)   NULL,
    [ReleaseDate] VARCHAR (50)     NULL,
    [Genres]      VARCHAR (1000)   NULL,
    [IsActive]    BIT              NOT NULL,
    [CreatedOn]   DATETIME         CONSTRAINT [DF_TvShow_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]   UNIQUEIDENTIFIER NOT NULL,
    [UpdatedOn]   DATETIME         NULL,
    [UpdatedBy]   UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_TvShow] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TvShow_User] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[User] ([Id])
);

