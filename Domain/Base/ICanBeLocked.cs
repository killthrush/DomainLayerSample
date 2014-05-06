namespace Domain.Base
{
    /// <summary>
    /// Feature interface for containers that can be locked, preventing both critters inside from 
    /// getting out, but also preventing anything from being added or removed from the container.
    /// </summary>
    public interface ICanBeLocked : IPreventsThingsInsideFromGettingOut
    {
        /// <summary>
        /// True if the container is locked else false
        /// </summary>
        bool IsLocked { get; }

        /// <summary>
        /// Locks the container
        /// </summary>
        void Lock();

        /// <summary>
        /// Unlocks the container
        /// </summary>
        void Unlock();
    }
}