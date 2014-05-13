using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WundergroundClient.Autocomplete
{
    class AutocompleteResponse
    {
        public Boolean IsSuccessful { get; private set; }
        public IList<AutocompleteResponseObject> Results;

        public AutocompleteResponse(bool isSuccessful)
        {
            IsSuccessful = isSuccessful;
        }
    }
}
