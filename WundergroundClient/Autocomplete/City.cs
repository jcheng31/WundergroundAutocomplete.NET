using System;

namespace WundergroundClient.Autocomplete
{
    public class City : Result
    {
        /// <summary>
        /// Corresponds to the "zmw" field.
        /// </summary>
        public String Identifier;

        /// <summary>
        /// The Olson-format time zone (e.g. America/Argentina/La_Rioja)
        /// 
        /// Corresponds to the "tz" field.
        /// </summary>
        public String TimeZone;

        /// <summary>
        /// Abbreviated time zone (e.g. ART)
        /// 
        /// Corresponds to the "tzs" field.
        /// </summary>
        public String ShortTimeZone;

        /// <summary>
        /// Corresponds to the "lat" field.
        /// </summary>
        public double Latitude;

        /// <summary>
        /// Corresponds to the "lon" field.
        /// </summary>
        public double Longitude;

        /// <summary>
        /// The latitude and longitude of this city, separated
        /// by a space.
        /// 
        /// Corresponds to the "ll" field.
        /// </summary>
        public String LatitudeLongitude;

        /// <summary>
        /// The country code this city is in.
        /// 
        /// Note: Wunderground uses different country codes than
        /// the standard ISO. Check http://www.wunderground.com/weather/api/d/docs?d=resources/country-to-iso-matching
        /// for mapping between this field and the ISO specification.
        /// 
        /// Corresponds to the "c" field.
        /// </summary>
        public String CountryCode;
    }
}
