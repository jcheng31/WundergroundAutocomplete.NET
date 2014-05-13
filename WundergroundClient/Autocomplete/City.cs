using System;

namespace WundergroundClient.Autocomplete
{
    class City : Result
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

        /// <summary>
        /// The country code this city is in.
        /// 
        /// Note: Wunderground uses different country codes than
        /// the standard ISO. Check http://www.wunderground.com/weather/api/d/docs?d=resources/country-to-iso-matching
        /// for mapping between this field and the ISO specification.
        /// </summary>
        public String CountryCode;
    }
}
