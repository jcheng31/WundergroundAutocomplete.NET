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
    /// 
    /// Corresponds to the "basin" field.
    /// </summary>
    public enum TropicalCycloneBasin
    {
        NorthAtlantic, // "at"
        EasternPacific, // "ep"
        WesternPacific, // "wp"
        NorthIndian, // "ni"
        SouthIndian, // "si"
        Unknown
    }
    public class Hurricane : Result
    {
        /// <summary>
        /// The date on which this hurricane occurred. The time properties of this 
        /// field should be ignored.
        /// 
        /// Corresponds to the "date" field.
        /// </summary>
        public DateTime Date;

        /// <summary>
        /// The Tropical Cyclone Basin that this hurricane occurred in.
        /// 
        /// Corresponds to the "basin" field.
        /// </summary>
        public TropicalCycloneBasin Basin;

        /// <summary>
        /// The Tropical Depression number of this hurricane.
        /// 
        /// Corresponds to the "strmnum" field.
        /// </summary>
        public int StormNumber;

        /// <summary>
        /// Damages caused by this hurricane, in millions of USD.
        ///
        /// Note: this value is sometimes unknown. In that case, this field
        /// will be -1.
        /// 
        /// Corresponds to the "damage" field.
        /// </summary>
        public int Damage;

        /// <summary>
        /// The highest category this hurricane reached on the Saffir-Simpson scale.
        /// 
        /// Corresponds to the "maxcat" field.
        /// </summary>
        public int PeakCategory;

        /// <summary>
        /// Corresponds to the "sw_lat" field.
        /// </summary>
        public double SouthWestLatitude;

        /// <summary>
        /// Corresponds to the "sw_lon" field.
        /// </summary>
        public double SouthWestLongitude;

        /// <summary>
        /// Corresponds to the "ne_lat" field.
        /// </summary>
        public double NorthEastLatitude;

        /// <summary>
        /// Corresponds to the "ne_lon" field.
        /// </summary>
        public double NorthEastLongitude;

        /// <summary>
        /// The date this hurricane formed. The time properties of this field
        /// should be ignored.
        /// 
        /// Note: this date is sometimes unknown. In this case, FormationDate
        /// and DissipationDate will be equal to DateTime.MinValue.
        /// 
        /// Corresponds to the "start_epoch" field.
        /// </summary>
        public DateTime FormationDate;

        /// <summary>
        /// The date this hurricane dissipated. The time properties of this field
        /// should be ignored.
        ///
        /// Note: this date is sometimes unknown. In this case, FormationDate
        /// and DissipationDate will be equal to DateTime.MinValue.
        /// 
        /// Corresponds to the "end_epoch" field.
        /// </summary>
        public DateTime DissipationDate;
    }
}
