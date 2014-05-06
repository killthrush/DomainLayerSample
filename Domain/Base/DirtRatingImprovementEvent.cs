namespace Domain.Base
{
    /// <summary>
    /// Class used for building events for washing objects.
    /// This one deals with the event when we make measurable progress in washing items.
    /// </summary>
    public class DirtRatingImprovementEvent
    {
        /// <summary>
        /// Event handler signature
        /// </summary>
        /// <param name="sender">The object raising the event</param>
        /// <param name="args">The event arguments</param>
        public delegate void EventHandler(ICanWashStuff sender, HandlerArgs args);

        /// <summary>
        /// The event erguments
        /// </summary>
        public class HandlerArgs
        {
            /// <summary>
            /// The current average dirt rating for all items in the container
            /// </summary>
            public DirtRating AverageDirtRating { get; set; }

            /// <summary>
            /// The current average clean percentage for all items in the container
            /// </summary>
            public decimal AveragePercentageClean { get; set; }
        }
    }
}