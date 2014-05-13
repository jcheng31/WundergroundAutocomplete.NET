using System;
using System.Globalization;

namespace WundergroundClient
{
    class Utilities
    {
        /// <summary>
        /// Converts a Unix epoch time string into a DateTime representation.
        /// </summary>
        /// <param name="epochTime">String containing the number of seconds since January 1, 1970.</param>
        /// <returns></returns>
        public static DateTime GetDateTimeFromUnixEpochTime(string epochTime)
        {
            int secondsSince;
            if (!Int32.TryParse(epochTime, NumberStyles.Integer, CultureInfo.InvariantCulture, out secondsSince))
            {
                throw new ArgumentException("Given String was not a number.");
            }

            return GetDateTimeFromUnixEpochTime(secondsSince);
        }

        /// <summary>
        /// Converts Unix epoch time into a DateTime representation.
        /// </summary>
        /// <param name="epochTime">The number of seconds since January 1, 1970.</param>
        /// <returns></returns>
        public static DateTime GetDateTimeFromUnixEpochTime(int epochTime)
        {
            if (epochTime < 0)
            {
                throw new ArgumentOutOfRangeException("Unix epoch time must be positive.");
            }
            var unixEpochBase = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return unixEpochBase.AddSeconds(epochTime);
        }
    }
}