CREATE TABLE [dbo].[ShowEpisode] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [ShowId]        UNIQUEIDENTIFIER NOT NULL,
    [SeasonNumber]  INT              NOT NULL,
    [EpisodeNumber] INT              NOT NULL,
    [EpisodeId]     VARCHAR (50)     NOT NULL,
    [EpisodeTitle]  VARCHAR (200)    NOT NULL,
    [Image]         VARCHAR (500)    NOT NULL,
    [ReleaseData]   VARCHAR (50)     NULL,
    [Plot]          VARCHAR (2000)   NULL,
    [IsActive]      BIT              NOT NULL,
    [CreatedOn]     DATETIME         CONSTRAINT [DF_ShowEpisode_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]     UNIQUEIDENTIFIER NOT NULL,
    [UpdatedOn]     DATETIME         NULL,
    [UpdatedBy]     UNIQUEIDENTIFIER NULL,
    [IsWatched]     BIT              NOT NULL,
    CONSTRAINT [FK_ShowEpisode_TvShow] FOREIGN KEY ([ShowId]) REFERENCES [dbo].[TvShow] ([Id]),
    CONSTRAINT [FK_ShowEpisode_User] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[User] ([Id])
);

