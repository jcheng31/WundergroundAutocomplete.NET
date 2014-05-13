using System;

namespace WundergroundClient
{
    class Utilities
    {
        public static DateTime GetDateTimeFromUnixEpochTime(int epochTime)
        {
            var unixEpochBase = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return unixEpochBase.AddSeconds(epochTime);
        }
    }
}