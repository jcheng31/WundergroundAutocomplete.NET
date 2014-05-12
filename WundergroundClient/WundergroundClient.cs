using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WundergroundClient
{
    public class WundergroundClient
    {
        private const String BaseUrl = "http://api.wunderground.com/api";

        private String _apiKey;

        public WundergroundClient(string apiKey)
        {
            _apiKey = apiKey;
        }
    }
}
