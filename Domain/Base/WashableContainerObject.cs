namespace Domain.Base
{
    /// <summary>
    /// Represents a container item that's washable.  In other words, if can both hold stuff and be washed.
    /// </summary>
    public abstract class WashableContainerObject : ContainerObject, IWashableObject
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
        /// Creates an instance of WashableContainerObject.  Called by derived classes.
        /// </summary>
        /// <param name="maxStorageCapacity">Indicates the max storage limit for this container</param>
        /// <remarks>
        /// This constructor is internal, because only domain objects in the same assembly should use it.
        /// </remarks>
        internal WashableContainerObject(int maxStorageCapacity) : base(maxStorageCapacity)
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
