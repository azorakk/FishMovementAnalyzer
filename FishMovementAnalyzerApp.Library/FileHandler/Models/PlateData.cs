using MiniExcelLibs.Attributes;

namespace FishMovementAnalyzerApp.Library.FileHandler.Models
{
    public record SecondResolutionData : PlateData;
    public record OneMinuteResolutionData : PlateData;
    public record FiveMinuteResolutionData : PlateData;
    public record CycleData : PlateData;
    public record PlateData
    {
        /// <summary>
        /// The location of the fish.
        /// Based on the file sample the place is in column 0.
        /// </summary>
        [ExcelColumnIndex("A")]
        public string? LocationId { get; set; }

        /// <summary>
        /// An is used for filtering.
        /// Based on the file sample the place is in column 4.
        /// </summary>
        [ExcelColumnIndex("E")]
        public int? An { get; set; }

        /// <summary>
        /// DataType is used for filtering.
        /// Based on the file sample the place is in column 5.
        /// </summary>
        [ExcelColumnIndex("F")]
        public string? DataType { get; set; }

        /// <summary>
        /// Start time in second when the tracking starts measuring.
        /// Based on the file sample the place is in column 6.
        /// </summary>
        [ExcelColumnIndex("G")]
        public int? StartTimeInSecond { get; set; }

        public TimeSpan StartTime
        {
            get { return TimeSpan.FromSeconds((double)StartTimeInSecond); }
            set
            {
                _ = value;
            }
        }

        /// <summary>
        /// End time in second when the tracking ends.
        /// Based on the file sample the place is in column 7.
        /// </summary>
        [ExcelColumnIndex("H")]
        public int? EndTimeInSecond { get; set; }

        public TimeSpan EndTime
        {
            get { return TimeSpan.FromSeconds((double)EndTimeInSecond); }
            set
            {
                _ = value;
            }
        }

        /// <summary>
        /// Minor movements of the fish in the time period.
        /// Based on the file sample the place is in column 11.
        /// </summary>
        [ExcelColumnIndex("L")]
        public int? Inactivity { get; set; }

        /// <summary>
        /// Inactive duration of minor movement of the fish.
        /// Based on the file sample the place is in column 12.
        /// </summary>
        [ExcelColumnIndex("M")]
        public double? InactiveDuration { get; set; }

        /// <summary>
        /// Distance moved during minor movement.
        /// Based on the file sample the place is in column 13.
        /// </summary>
        [ExcelColumnIndex("N")]
        public double? InactiveDistance { get; set; }

        /// <summary>
        /// Small movements of the fish in the time period.
        /// Based on the file sample the place is in column 14.
        /// </summary>
        [ExcelColumnIndex("O")]
        public int? SmallActivity { get; set; }

        /// <summary>
        /// Duration of small movement of the fish.
        /// Based on the file sample the place is in column 15.
        /// </summary>
        [ExcelColumnIndex("P")]
        public double? SmallDuration { get; set; }

        /// <summary>
        /// Distance moved during small movement.
        /// Based on the file sample the place is in column 16.
        /// </summary>
        [ExcelColumnIndex("Q")]
        public double? SmallDistance { get; set; }

        /// <summary>
        /// Large movements of the fish in the time period.
        /// Based on the file sample the place is in column 17.
        /// </summary>
        [ExcelColumnIndex("R")]
        public int? LargeActivity { get; set; }

        /// <summary>
        /// Duration of large movement of the fish.
        /// Based on the file sample the place is in column 18.
        /// </summary>
        [ExcelColumnIndex("S")]
        public int? LargeDuration { get; set; }

        /// <summary>
        /// Distance moved during large movement.
        /// Based on the file sample the place is in column 19.
        /// </summary>
        [ExcelColumnIndex("T")]
        public int? LargeDistance { get; set; }

        public int TotalActivity
        {
            get { return Inactivity.GetValueOrDefault(0) + SmallActivity.GetValueOrDefault(0) + LargeActivity.GetValueOrDefault(0); }
            set
            {
                _ = value;
            }
        }

        public double TotalDistance
        {
            get { return InactiveDistance.GetValueOrDefault(0) + SmallDistance.GetValueOrDefault(0) + LargeDistance.GetValueOrDefault(0); }
            set
            {
                _ = value;
            }
        }

        public double TotalDuration 
        {
            get { return InactiveDuration.GetValueOrDefault(0) + SmallDuration.GetValueOrDefault(0) + LargeDuration.GetValueOrDefault(0); }
            set
            {
                _ = value;
            }
        }

        public int BigActivity
        {
            get { return SmallActivity.GetValueOrDefault(0) + LargeActivity.GetValueOrDefault(0); }
            set
            {
                _ = value;
            }
        }

        public double BigDistance 
        {
            get { return SmallDistance.GetValueOrDefault(0) + LargeDistance.GetValueOrDefault(0); }
            set
            {
                _ = value;
            }
        }
        public double BigDuration 
        {
            get { return SmallDuration.GetValueOrDefault(0) + LargeDuration.GetValueOrDefault(0); }
            set
            {
                _ = value;
            }
        }

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
            StartTime = TimeSpan.FromSeconds(GetDoubleValue(rowValues[6]).Value);
            EndTimeInSecond = GetIntValue(rowValues[7]);
            EndTime = TimeSpan.FromSeconds(GetDoubleValue(rowValues[7]).Value);
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
            return int.TryParse(value, out var _value) ? _value : null;
        }

        private double? GetDoubleValue(string? value)
        {
            return double.TryParse(value, out var _value) ? Math.Round(_value, 2) : null;
        }

    }

    public enum CycleType
    {
        Light,
        Dark
    }
}
