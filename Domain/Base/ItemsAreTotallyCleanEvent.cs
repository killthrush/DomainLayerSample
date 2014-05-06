namespace Domain.Base
{
    /// <summary>
    /// Class used for building events for washing objects.
    /// This one deals with the event when all objects in a container are fully washed.
    /// </summary>
    public class ItemsAreTotallyCleanEvent
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
            /// The total number of minutes that it took to wash the items
            /// </summary>
            public int TotalMinutesElapsed { get; set; }
        }
    }
}