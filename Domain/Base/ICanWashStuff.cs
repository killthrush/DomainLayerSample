namespace Domain.Base
{
    /// <summary>
    /// Feature interface for containers that can wash items.
    /// The mechanism for washing (and the quality) depends on the implementation.
    /// </summary>
    public interface ICanWashStuff
    {
        /// <summary>
        /// Washes all items currently being held
        /// </summary>
        void StartWashing();

        /// <summary>
        /// Event handler(s) for when the average dirt rating for objects being washed improves.
        /// </summary>
        event DirtRatingImprovementEvent.EventHandler NotifyWhenDirtRatingImproves;

        /// <summary>
        /// Event handler(s) for when all objects being washed are squeaky clean.
        /// </summary>
        event ItemsAreTotallyCleanEvent.EventHandler NotifyWhenItemsAreTotallyClean;
    }
}