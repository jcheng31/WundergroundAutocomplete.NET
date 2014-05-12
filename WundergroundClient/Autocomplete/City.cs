using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        // Though the API documentation includes latitude and longitude
        // coordinates, they do not appear to actually be returned in
        // the response.
    }
}
