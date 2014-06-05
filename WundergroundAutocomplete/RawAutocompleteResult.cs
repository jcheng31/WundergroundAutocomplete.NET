using System;
using System.Runtime.Serialization;

namespace WundergroundAutocomplete
{
// ReSharper disable InconsistentNaming
    [DataContract]
    public class RawAutocompleteResult
    {
        [DataMember] public RawResult[] RESULTS;
    }

    [DataContract]
    public class RawResult
    {
        [DataMember] public String name;
        [DataMember] public String type;
        [DataMember] public String l;

        // Hurricane Fields
        [DataMember] public String date;
        [DataMember] public String strmnum;
        [DataMember] public String basin;
        [DataMember] public String damage;
        [DataMember] public String start_epoch;
        [DataMember] public String end_epoch;
        [DataMember] public String sw_lat;
        [DataMember] public String sw_lon;
        [DataMember] public String ne_lat;
        [DataMember] public String ne_lon;
        [DataMember] public String maxcat;

        // City Fields
        [DataMember] public String c;
        [DataMember] public String zmw;
        [DataMember] public String tz;
        [DataMember] public String tzs;
        [DataMember] public String ll;
        [DataMember] public String lat;
        [DataMember] public String lon;
    }
}