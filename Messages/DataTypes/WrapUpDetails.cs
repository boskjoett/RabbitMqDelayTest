using System;

namespace Messages.DataTypes
{
    /// <summary>
    /// Wrapup details containing extra wrapup information.
    /// </summary>
    public class WrapUpDetails
    {
        /// <summary>
        /// The base wrapup duration.
        /// </summary>
        public TimeSpan Duration { get; private set; }
        /// <summary>
        /// The start time of wrapup in utc.
        /// </summary>
        public DateTime WrapUpStartedAtUtc { get; private set; }

        /// <summary>
        /// Number of time wrapup has been extended.
        /// </summary>
        public int WrapUpExtendedCount { get; private set; }

        /// <summary>
        /// Details about reason codes associated with this wrap up.
        /// </summary>
        public ReasonCodesDetails? ReasonCodesDetails { get; private set; }

        /// <summary>
        /// Create wrapup detauls.
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="wrapUpStartedAtUtc"></param>
        /// <param name="wrapUpExtendedCount"></param>
        /// <param name="reasonCodesDetails"></param>
        public WrapUpDetails(TimeSpan duration, DateTime wrapUpStartedAtUtc, int wrapUpExtendedCount, ReasonCodesDetails? reasonCodesDetails = null)
        {
            Duration = duration;
            WrapUpStartedAtUtc = wrapUpStartedAtUtc;
            WrapUpExtendedCount = wrapUpExtendedCount;
            ReasonCodesDetails = reasonCodesDetails;
        }
    }
}
