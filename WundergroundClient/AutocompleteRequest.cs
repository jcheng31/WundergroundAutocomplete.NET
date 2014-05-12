using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundergroundClient
{
    enum ResultFilter
    {
        CitiesOnly,
        HurricanesOnly,
        CitiesAndHurricanes
    }

    class AutocompleteRequest
    {
        private String _searchString;
        private ResultFilter _filter = ResultFilter.CitiesOnly;
        private String _countryCode = null;

        public AutocompleteRequest(String searchString)
        {
            _searchString = searchString;
        }

        public AutocompleteRequest(String query, ResultFilter filter)
        {
            _searchString = query;
            _filter = filter;
        }

        public AutocompleteRequest(String searchString, ResultFilter filter, string countryCode)
        {
            _searchString = searchString;
            _filter = filter;
            _countryCode = countryCode;
        }
    }
}
