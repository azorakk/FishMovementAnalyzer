namespace FishMovementAnalyzerApp.Models
{
    internal class PlateData
    {
        /// <summary>
        /// The location of the fish.
        /// Based on the file sample the place is in column 1.
        /// </summary>
        public string? LocationId { get; set; }

        /// <summary>
        /// An is used for filtering.
        /// Based on the file sample the place is in column 5.
        /// </summary>
        public int An { get; set; }

        /// <summary>
        /// DataType is used for filtering.
        /// Based on the file sample the place is in column 5.
        /// </summary>
        public string? DataType { get; set; }

        /// <summary>
        /// Start time in second when the tracking starts measuring.
        /// Based on the file sample the place is in column 7.
        /// </summary>
        public int? StartTimeInSecond { get; set; }

        /// <summary>
        /// End time in second when the tracking ends.
        /// Based on the file sample the place is in column 8.
        /// </summary>
        public int? EndTimeInSecont { get; set; }

        /// <summary>
        /// Minor movements of the fish in the time period.
        /// Based on the file sample the place is in column 12.
        /// </summary>
        public int? Inactivity { get; set; }

        /// <summary>
        /// Inactive duration of minor movement of the fish.
        /// Based on the file sample the place is in column 13.
        /// </summary>
        public int? InactiveDuration { get; set; }

        /// <summary>
        /// Distance moved during minor movement.
        /// Based on the file sample the place is in column 14.
        /// </summary>
        public int? InactiveDistance { get; set; }

        /// <summary>
        /// Small movements of the fish in the time period.
        /// Based on the file sample the place is in column 15.
        /// </summary>
        public int? SmallActivity { get; set; }

        /// <summary>
        /// Duration of small movement of the fish.
        /// Based on the file sample the place is in column 16.
        /// </summary>
        public int? SmallDuration { get; set; }

        /// <summary>
        /// Distance moved during small movement.
        /// Based on the file sample the place is in column 17.
        /// </summary>
        public int? SmallDistance { get; set; }

        /// <summary>
        /// Large movements of the fish in the time period.
        /// Based on the file sample the place is in column 18.
        /// </summary>
        public int? LargeActivity { get; set; }

        /// <summary>
        /// Duration of large movement of the fish.
        /// Based on the file sample the place is in column 19.
        /// </summary>
        public int? LargeDuration { get; set; }

        /// <summary>
        /// Distance moved during large movement.
        /// Based on the file sample the place is in column 20.
        /// </summary>
        public int? LargeDistance { get; set; }

    }
}
