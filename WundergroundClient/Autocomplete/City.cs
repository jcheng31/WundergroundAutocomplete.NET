using System;

namespace WundergroundClient.Autocomplete
{
    class City : AutocompleteResponseObject
    {
        public String Country;

        /// <summary>
        /// Corresponds to the "zmw" field used in links.
        /// </summary>
        public String Identifier;

        /// <summary>
        /// The Olson-format time zone.
        /// e.g. America/Argentina/La_Rioja
        /// </summary>
        public String TimeZone;

        /// <summary>
        /// Abbreviated time zone.
        /// e.g. ART
        /// </summary>
        public String ShortTimeZone;

        public double Latitude;
        public double Longitude;

        /// <summary>
        /// The latitude and longitude of this city, separated
        /// by a space.
        /// </summary>
        public String LatitudeLongitude;
    }
}
