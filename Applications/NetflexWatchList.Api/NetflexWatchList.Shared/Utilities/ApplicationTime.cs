namespace NetflexWatchList.Shared.Utilities
{
    using NetflexWatchList.Shared.Utilities.Interface;
    using System;

    /// <summary>
    /// The ApplicationTime implementation.
    /// </summary>
    /// <seealso cref="NetflexWatchList.Shared.Utilities.Interface.IApplicationTime" />
    public class ApplicationTime : IApplicationTime
    {
        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <returns>
        /// return datetime.
        /// </returns>
        public DateTime GetDate()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// Gets the UTC time.
        /// </summary>
        /// <returns>
        /// return UTCDateTime.
        /// </returns>
        public DateTime GetUTCTime()
        {
            return DateTime.UtcNow;
        }
    }
}
