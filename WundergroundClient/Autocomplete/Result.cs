using System;

namespace WundergroundClient.Autocomplete
{
    abstract class Result
    {
        public String Name;

        /// <summary>
        /// A link that can be used with other APIs to obtain
        /// further information about this object.
        /// 
        /// This corresponds to the "l" field returned by the
        /// API.
        /// </summary>
        public String Link;
    }
}
