using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
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
        public SearchRequest(String city)
            : this(city, ResultFilter.CitiesOnly, null)
        {
        }

        /// <summary>
        /// Creates a general query for cities, hurricanes, or both.
        /// </summary>
        /// <param name="query">The full or partial name to be looked up.</param>
        /// <param name="filter">The types of results that are expected.</param>
        public SearchRequest(String query, ResultFilter filter)
            : this(query, filter, null)
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

                if (!isSuccessful)
                {
                    return results;
                }

                using (var rawResultStream = await response.Content.ReadAsStreamAsync())
                {
                    var deserializer = new DataContractJsonSerializer(typeof(RawAutocompleteResult));
                    var rawResult = (RawAutocompleteResult)deserializer.ReadObject(rawResultStream);

                    results.Results = new List<Result>();
                    foreach (var r in rawResult.RESULTS)
                    {
                        var result = GetUsableResult(r);

                        if (result != null)
                        {
                            results.Results.Add(result);
                        }
                    }
                }

                return results;
            }
        }

        private static Result GetUsableResult(RawResult r)
        {
            Result result = null;
            switch (r.type)
            {
                case "city":
                    result = ConvertRawResultToCity(r);
                    break;
                case "hurricanes":
                    result = ConvertRawResultToHurricane(r);
                    break;
            }
            return result;
        }

        private static Result ConvertRawResultToHurricane(RawResult r)
        {
            // Handle the start_epoch and end_epoch.
            DateTime start = DateTime.MinValue;
            DateTime end = DateTime.MinValue;

            bool isStartAndEndEqual = r.start_epoch.Equals(r.end_epoch);
            bool isStartValid = r.start_epoch != "-1";
            bool isEndValid = r.end_epoch != "-1";

            if (!isStartAndEndEqual && isStartValid && isEndValid)
            {
                start = Utilities.GetDateTimeFromUnixEpochTime(r.start_epoch);
                end = Utilities.GetDateTimeFromUnixEpochTime(r.end_epoch);
            }

            // Figure out which basin we're in.
            var basin = GetBasinFromRawResult(r);

            Result result = new Hurricane
            {
                Name = r.name,
                Link = r.l,
                Date = DateTime.ParseExact(r.date, "d", CultureInfo.InvariantCulture),
                StormNumber = Int32.Parse(r.strmnum, CultureInfo.InvariantCulture),
                Basin = basin,
                Damage = Int32.Parse(r.damage, CultureInfo.InvariantCulture),
                FormationDate = start,
                DissipationDate = end,
                SouthWestLatitude = Double.Parse(r.sw_lat, CultureInfo.InvariantCulture),
                SouthWestLongitude = Double.Parse(r.sw_lon, CultureInfo.InvariantCulture),
                NorthEastLatitude = Double.Parse(r.ne_lat, CultureInfo.InvariantCulture),
                NorthEastLongitude = Double.Parse(r.ne_lon, CultureInfo.InvariantCulture),
                PeakCategory = Int32.Parse(r.maxcat, CultureInfo.InvariantCulture)
            };
            return result;
        }

        private static TropicalCycloneBasin GetBasinFromRawResult(RawResult r)
        {
            TropicalCycloneBasin basin;
            switch (r.basin)
            {
                case "at":
                    basin = TropicalCycloneBasin.NorthAtlantic;
                    break;
                case "ep":
                    basin = TropicalCycloneBasin.EasternPacific;
                    break;
                case "wp":
                    basin = TropicalCycloneBasin.WesternPacific;
                    break;
                case "ni":
                    basin = TropicalCycloneBasin.NorthIndian;
                    break;
                case "si":
                    basin = TropicalCycloneBasin.SouthIndian;
                    break;
                default:
                    basin = TropicalCycloneBasin.Unknown;
                    break;
            }
            return basin;
        }

        private static Result ConvertRawResultToCity(RawResult r)
        {
            Result result = new City
            {
                Name = r.name,
                Link = r.l,
                CountryCode = r.c,
                Identifier = r.zmw,
                TimeZone = r.tz,
                ShortTimeZone = r.tzs,
                Latitude = Double.Parse(r.lat, CultureInfo.InvariantCulture),
                Longitude = Double.Parse(r.lon, CultureInfo.InvariantCulture),
                LatitudeLongitude = r.ll
            };
            return result;
        }
    }
}
