using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WundergroundClient.Autocomplete
{
    /// <summary>
    /// Tropical Cyclone Basins used by Wunderground.
    ///
    /// Though NorthIndian and SouthIndian are referred to in 
    /// the "currenthurricane" feature documentation, 
    /// Autocomplete doesn't appear to return any hurricanes 
    /// that fall into these basins.
    /// </summary>
    enum TropicalCycloneBasin
    {
        NorthAtlantic, // "at"
        EasternPacific, // "ep"
        WesternPacific, // "wp"
        NorthIndian, // "ni"
        SouthIndian // "si"
    }
    class Hurricane : AutocompleteResponseObject
    {
        /// <summary>
        /// The date on which this hurricane occurred.
        /// The time properties of this field should be ignored;
        /// Wunderground does not provide timing information.
        /// </summary>
        public DateTime Date;

        /// <summary>
        /// The Tropical Cyclone Basin that this hurricane occurred in.
        /// </summary>
        public TropicalCycloneBasin Basin;

        /// <summary>
        /// The Tropical Depression number of this hurricane.
        /// </summary>
        public int StormNumber;

        /// <summary>
        /// Damages caused by this hurricane, in millions of USD.
        /// Note: Wunderground sometimes returns a negative number here - possibly
        /// if the amount was not recorded.
        /// </summary>
        public int Damage;
    }
}
