using System;

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
        /// The date on which this hurricane occurred. The time properties of this 
        /// field should be ignored.
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
        ///
        /// Note: this value is sometimes unknown. In that case, this field
        /// will be -1.
        /// </summary>
        public int Damage;

        /// <summary>
        /// The highest category this hurricane reached on the Saffir-Simpson scale.
        /// </summary>
        public int PeakCategory;

        public double SouthWestLatitude;
        public double SouthWestLongitude;
        public double NorthEastLatitude;
        public double NorthEastLongitude;

        /// <summary>
        /// The date this hurricane formed. The time properties of this field
        /// should be ignored.
        /// 
        /// Note: this date is sometimes unknown. In this case, FormationDate
        /// and DissipationDate will be equal to DateTime.MinValue.
        /// </summary>
        public DateTime FormationDate;

        /// <summary>
        /// The date this hurricane dissipated. The time properties of this field
        /// should be ignored.
        ///
        /// Note: this date is sometimes unknown. In this case, FormationDate
        /// and DissipationDate will be equal to DateTime.MinValue.
        /// </summary>
        public DateTime DissipationDate;
    }
}
