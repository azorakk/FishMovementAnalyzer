namespace FishMovementAnalyzerApp.Models
{
    internal class PlateData
    {
        /// <summary>
        /// The location of the fish.
        /// Based on the file sample the place is in column 0.
        /// </summary>
        public string? LocationId { get; set; }

        /// <summary>
        /// An is used for filtering.
        /// Based on the file sample the place is in column 4.
        /// </summary>
        public int? An { get; set; }

        /// <summary>
        /// DataType is used for filtering.
        /// Based on the file sample the place is in column 5.
        /// </summary>
        public string? DataType { get; set; }

        /// <summary>
        /// Start time in second when the tracking starts measuring.
        /// Based on the file sample the place is in column 6.
        /// </summary>
        public int? StartTimeInSecond { get; set; }

        /// <summary>
        /// End time in second when the tracking ends.
        /// Based on the file sample the place is in column 7.
        /// </summary>
        public int? EndTimeInSecond { get; set; }

        /// <summary>
        /// Minor movements of the fish in the time period.
        /// Based on the file sample the place is in column 11.
        /// </summary>
        public int? Inactivity { get; set; }

        /// <summary>
        /// Inactive duration of minor movement of the fish.
        /// Based on the file sample the place is in column 12.
        /// </summary>
        public double? InactiveDuration { get; set; }

        /// <summary>
        /// Distance moved during minor movement.
        /// Based on the file sample the place is in column 13.
        /// </summary>
        public double? InactiveDistance { get; set; }

        /// <summary>
        /// Small movements of the fish in the time period.
        /// Based on the file sample the place is in column 14.
        /// </summary>
        public int? SmallActivity { get; set; }

        /// <summary>
        /// Duration of small movement of the fish.
        /// Based on the file sample the place is in column 15.
        /// </summary>
        public double? SmallDuration { get; set; }

        /// <summary>
        /// Distance moved during small movement.
        /// Based on the file sample the place is in column 16.
        /// </summary>
        public double? SmallDistance { get; set; }

        /// <summary>
        /// Large movements of the fish in the time period.
        /// Based on the file sample the place is in column 17.
        /// </summary>
        public int? LargeActivity { get; set; }

        /// <summary>
        /// Duration of large movement of the fish.
        /// Based on the file sample the place is in column 18.
        /// </summary>
        public int? LargeDuration { get; set; }

        /// <summary>
        /// Distance moved during large movement.
        /// Based on the file sample the place is in column 19.
        /// </summary>
        public int? LargeDistance { get; set; }

        public CycleType? CycleType { get; set; } = null;

        public PlateData()
        {

        }

        public PlateData(string[] rowValues)
        {
            LocationId = rowValues[0];
            An = GetIntValue(rowValues[4]);
            DataType = rowValues[5];
            StartTimeInSecond = GetIntValue(rowValues[6]);
            EndTimeInSecond = GetIntValue(rowValues[7]);
            Inactivity = GetIntValue(rowValues[11]);
            InactiveDuration = GetDoubleValue(rowValues[12]);
            InactiveDistance = GetDoubleValue(rowValues[13]);
            SmallActivity = GetIntValue(rowValues[14]);
            SmallDuration = GetDoubleValue(rowValues[15]);
            SmallDistance = GetDoubleValue(rowValues[16]);
            LargeActivity = GetIntValue(rowValues[17]);
            LargeDuration = GetIntValue(rowValues[18]);
            LargeDistance = GetIntValue(rowValues[19]);
        }

        private int? GetIntValue(string? value)
        {
            return int.TryParse(value, out var _value) ? _value : (int?)null;
        }

        private int? GetDoubleValue(string? value)
        {
            return int.TryParse(value, out var _value) ? _value : (int?)null;
        }

    }

    public enum CycleType
    {
        Light,
        Dark
    }
}
