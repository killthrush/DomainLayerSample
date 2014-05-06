using System;

namespace Domain.Base
{
    /// <summary>
    /// Represents an item that's washable.  In other words, use it and it gets dirty.  After washing it for a while, it's clean again.
    /// </summary>
    public abstract class WashableObject : WorldObject, IWashableObject
    {
        /// <summary>
        /// Internal state for the item that measures how clean it is.
        /// </summary>
        public decimal PercentClean { get; internal set; }

        /// <summary>
        /// How long it takes to make the object totally clean (varies for derived objects)
        /// </summary>
        public abstract int MinutesRequiredToClean { get; }

        /// <summary>
        /// Flag that indicates whether or not the item is dishwasher-safe
        /// </summary>
        public abstract bool IsDishwasherSafe { get; }

        /// <summary>
        /// A human-readable measurement for how clean the object is
        /// </summary>
        public DirtRating DirtRating
        {
            get
            {
                return this.CalculateDirtRating();
            }
        }

        /// <summary>
        /// Creates an instance of WashableItem.  Called by derived classes.
        /// </summary>
        protected WashableObject()
        {
            PercentClean = 100;
        }

        /// <summary>
        /// Start washing the object.  After a certain number of minutes (varies by object type and soap factor), the object is clean.
        /// </summary>
        /// <param name="soapFactor">A scalar value that be used to magnify the effectiveness of washing</param>
        public void WashForOneMinute(decimal soapFactor)
        {
            PercentClean = this.CalculateCleanPercentageAfterOneMinuteWash(soapFactor);
        }
    }
}
