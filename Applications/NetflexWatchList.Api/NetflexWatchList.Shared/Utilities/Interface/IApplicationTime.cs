using System;

namespace NetflexWatchList.Shared.Utilities.Interface
{
    /// <summary>
    /// The IApplicationTime interface.
    /// </summary>
    public interface IApplicationTime
    {
        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <returns>return datetime.</returns>
        DateTime GetDate();

        /// <summary>
        /// Gets the UTC time.
        /// </summary>
        /// <returns>return UTCDateTime.</returns>
        DateTime GetUTCTime();
    }
}
