using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WundergroundClient.Autocomplete
{
// ReSharper disable InconsistentNaming
    [DataContract]
    internal class RawAutocompleteResult
    {
        [DataMember] internal RawResult[] RESULTS;
    }

    [DataContract]
    internal class RawResult
    {
        [DataMember] internal String name;
        [DataMember] internal String type;
        [DataMember] internal String l;

        // Hurricane Fields
        [DataMember] internal String date;
        [DataMember] internal String strmnum;
        [DataMember] internal String basin;
        [DataMember] internal String damage;
        [DataMember] internal String start_epoch;
        [DataMember] internal String end_epoch;
        [DataMember] internal String sw_lat;
        [DataMember] internal String sw_lon;
        [DataMember] internal String ne_lat;
        [DataMember] internal String ne_lon;
        [DataMember] internal String maxcat;

        // City Fields
        [DataMember] internal String c;
        [DataMember] internal String zmw;
        [DataMember] internal String tz;
        [DataMember] internal String tzs;
        [DataMember] internal String ll;
        [DataMember] internal String lat;
        [DataMember] internal String lon;
    }
}