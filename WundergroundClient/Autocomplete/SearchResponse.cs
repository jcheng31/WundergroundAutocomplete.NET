using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WundergroundClient.Autocomplete
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
