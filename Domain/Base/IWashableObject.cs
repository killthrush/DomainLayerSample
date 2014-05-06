namespace Domain.Base
{
    /// <summary>
    /// Feature interface for objects that get dirty and can be washed
    /// </summary>
    public interface IWashableObject : IWorldObject
    {
        /// <summary>
        /// State for the item that measures how clean it is.
        /// </summary>
        decimal PercentClean { get; }

        /// <summary>
        /// How long it takes to make the object totally clean (varies for different implementations)
        /// </summary>
        int MinutesRequiredToClean { get; }

        /// <summary>
        /// Flag that indicates whether or not the item is dishwasher-safe
        /// </summary>
        bool IsDishwasherSafe { get; }

        /// <summary>
        /// A human-readable measurement for how clean the object is
        /// </summary>
        DirtRating DirtRating { get; }

        /// <summary>
        /// Start washing the object.  After a certain number of minutes, the object is clean.
        /// </summary>
        /// <param name="soapFactor">A scalar value that can decrease the amount of time needed to wash something</param>
        void WashForOneMinute(decimal soapFactor);
    }
}