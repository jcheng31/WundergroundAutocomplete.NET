using System;

namespace WundergroundClient.Autocomplete
{
    enum ResultFilter
    {
        CitiesOnly,
        HurricanesOnly,
        CitiesAndHurricanes
    }

    class AutocompleteRequest
    {
        private const String BaseUrl = "http://autocomplete.wunderground.com/";

        private readonly String _searchString;
        private readonly ResultFilter _filter;
        private readonly String _countryCode;

        /// <summary>
        /// Creates a request to search for cities.
        /// </summary>
        /// <param name="city">The full or partial name of a city to look for.</param>
        public AutocompleteRequest(String city) : this(city, ResultFilter.CitiesOnly, null)
        {
        }

        /// <summary>
        /// Creates a general query for cities, hurricanes, or both.
        /// </summary>
        /// <param name="query">The full or partial name to be looked up.</param>
        /// <param name="filter">The types of results that are expected.</param>
        public AutocompleteRequest(String query, ResultFilter filter) : this(query, filter, null)
        {
        }

        /// <summary>
        /// Creates a query for cities, hurricanes, or both,
        /// restricted to a particular country.
        /// 
        /// Note: Wunderground does not use the standard ISO country codes.
        /// See http://www.wunderground.com/weather/api/d/docs?d=resources/country-to-iso-matching
        /// </summary>
        /// <param name="query">The full or partial name to be looked up.</param>
        /// <param name="filter">The types of results that are expected.</param>
        /// <param name="countryCode">The Wunderground country code to restrict results to.</param>
        public AutocompleteRequest(String query, ResultFilter filter, String countryCode)
        {
            _searchString = query;
            _filter = filter;
            _countryCode = countryCode;
        }

        //public async Task<String> ExecuteAsync()
        //{
            
        //}
    }
}
