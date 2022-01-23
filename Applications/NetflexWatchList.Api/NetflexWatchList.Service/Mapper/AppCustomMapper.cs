namespace NetflexWatchList.Service.Mapper
{
    using NetflexWatchList.Data.Entities;
    using NetflexWatchList.Shared.ExternalModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The Application custom mapper.
    /// </summary>
    public static class AppCustomMapper
    {
        /// <summary>
        /// Converts to entity.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The TvShow.</returns>
        public static TvShow ToEntity(this ImdbShow data, string userId)
        {
            if (data == null) { return null; }

            var entity = new TvShow()
            {
                IMDbId = data.Id,
                Title = data.Title,
                FullTitle = data.FullTitle,
                Image = data.Image,
                Plot = data.Plot,
                Description = data.Description,
                ReleaseDate = data.ReleaseDate,
                Genres = data.Genres,
                IsActive = true,

                CreatedBy = Guid.Parse(userId),
            };

            entity.ShowEpisodes = new List<ShowEpisode>();

            MapEpisodes(data, userId, entity);

            return entity;
        }

        /// <summary>
        /// Converts to servicemodel.
        /// </summary>
        /// <param name="tvShow">The tv show.</param>
        /// <returns></returns>
        public static ImdbShow ToServiceModel(this TvShow tvShow)
        {
            if (tvShow == null) { return null; }

            var showModel = new ImdbShow()
            {
                Id = tvShow.IMDbId,
                Title = tvShow.Title,
                FullTitle = tvShow.FullTitle,
                Image = tvShow.Image,
                ReleaseDate = tvShow.ReleaseDate,
                Plot = tvShow.Plot,
                Description = tvShow.Description,
                Genres = tvShow.Genres
            };

            MapSeasonAndEpisodes(tvShow, showModel);

            return showModel;
        }

        /// <summary>
        /// Converts to servicemodel.
        /// </summary>
        /// <param name="episode">The episode.</param>
        /// <returns>The ImdbEpisode.</returns>
        public static ImdbEpisode ToServiceModel(this ShowEpisode episode)
        {
            if (episode == null) { return null; }

            return new ImdbEpisode()
            {
                Id = episode.EpisodeId,
                Number = episode.EpisodeNumber.ToString(),
                Title = episode.EpisodeTitle,
                Image = episode.Image,
                ReleaseDate = episode.ReleaseData,
                Plot = episode.Plot
            };
        }

        /// <summary>
        /// Maps the season and episodes.
        /// </summary>
        /// <param name="tvShow">The tv show.</param>
        /// <param name="showModel">The show model.</param>
        private static void MapSeasonAndEpisodes(TvShow tvShow, ImdbShow showModel)
        {
            foreach (var groupBySeason in tvShow.ShowEpisodes.GroupBy(x => x.SeasonNumber))
            {
                var season = new ImdbSeason()
                {
                    SeasonNumber = groupBySeason.Key,
                };

                foreach (var episode in groupBySeason)
                {
                    season.Episodes.Add(episode.ToServiceModel());
                }

                showModel.Seasons.Add(season);
            }
        }

        /// <summary>
        /// Maps the episodes.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="entity">The entity.</param>
        private static void MapEpisodes(ImdbShow data, string userId, TvShow entity)
        {
            foreach (var season in data.Seasons)
            {
                foreach (var episode in season.Episodes)
                {
                    entity.ShowEpisodes.Add(new ShowEpisode()
                    {
                        ShowId = entity.Id,
                        SeasonNumber = season.SeasonNumber,
                        EpisodeId = episode.Id,
                        EpisodeNumber = int.Parse(episode.Number),
                        EpisodeTitle = episode.Title,
                        Image = episode.Image,
                        ReleaseData = episode.ReleaseDate,
                        Plot = episode.Plot,
                        IsActive = true,
                        IsWatched = false,
                        CreatedBy = Guid.Parse(userId)
                    });
                }
            }
        }
    }
}
