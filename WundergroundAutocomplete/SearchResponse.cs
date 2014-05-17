using System;
using System.Collections.Generic;

namespace WundergroundAutocomplete
{
    public class SearchResponse
    {
        public Boolean IsSuccessful { get; private set; }
        public IList<Result> Results;

        public SearchResponse(bool isSuccessful)
        {
            IsSuccessful = isSuccessful;
        }
    }
}
