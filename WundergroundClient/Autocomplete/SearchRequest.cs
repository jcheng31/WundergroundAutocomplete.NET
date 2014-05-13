﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WundergroundClient.Autocomplete
{
    enum ResultFilter
    {
        CitiesOnly,
        HurricanesOnly,
        CitiesAndHurricanes
    }

    class SearchRequest
    {
        private const String BaseUrl = "http://autocomplete.wunderground.com/";

        private readonly String _searchString;
        private readonly ResultFilter _filter;
        private readonly String _countryCode;

        /// <summary>
        /// Creates a request to search for cities.
        /// </summary>
        /// <param name="city">The full or partial name of a city to look for.</param>
        public SearchRequest(String city) : this(city, ResultFilter.CitiesOnly, null)
        {
        }

        /// <summary>
        /// Creates a general query for cities, hurricanes, or both.
        /// </summary>
        /// <param name="query">The full or partial name to be looked up.</param>
        /// <param name="filter">The types of results that are expected.</param>
        public SearchRequest(String query, ResultFilter filter) : this(query, filter, null)
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
        public SearchRequest(String query, ResultFilter filter, String countryCode)
        {
            _searchString = query;
            _filter = filter;
            _countryCode = countryCode;
        }

        public async Task<SearchResponse> ExecuteAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                String filter;
                switch (_filter)
                {
                    case ResultFilter.CitiesOnly:
                        filter = "cities=1&h=0";
                        break;
                    case ResultFilter.HurricanesOnly:
                        filter = "cities=0&h=1";
                        break;
                    case ResultFilter.CitiesAndHurricanes:
                        filter = "cities=1&h=1";
                        break;
                    default:
                        filter = "";
                        break;
                }

                String query;
                if (_countryCode != null)
                {
                    query = String.Format("aq?query={0}&{1}&{2}", _searchString, _countryCode, filter);
                }
                else
                {
                    query = String.Format("aq?query={0}&{1}", _searchString, filter);
                }

                var response = await client.GetAsync(query);

                bool isSuccessful = response.IsSuccessStatusCode;
                var results = new SearchResponse(isSuccessful);

                if (isSuccessful)
                {
                    results.Results = new List<Result>();

                }

                return results;
            }
        }
    }
}