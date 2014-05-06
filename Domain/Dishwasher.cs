using System;
using System.Linq;
using System.Collections.Generic;
using Domain.Base;
using Domain.Exceptions;

namespace Domain
{
    /// <summary>
    /// An Awesome-O Model 2000 Smart Dishwasher.
    /// The only known dishwasher that's serializable to a SQL Database!
    /// Also has limited time-warp capability (patents pending).
    /// </summary>
    public class Dishwasher : ContainerObject, ICanWashStuff, ICanBeLocked
    {
        /// <summary>
        /// The maximum amount of dishwasher soap that the Awesome-O Model 2000 can hold
        /// </summary>
        public const int MaxSoapCapacity = 100;

        /// <summary>
        /// Event handler(s) for when the average dirt rating for objects being washed improves.
        /// </summary>
        public event DirtRatingImprovementEvent.EventHandler NotifyWhenDirtRatingImproves;

        /// <summary>
        /// Event handler(s) for when all objects being washed are squeaky clean.
        /// </summary>
        public event ItemsAreTotallyCleanEvent.EventHandler NotifyWhenItemsAreTotallyClean;

        /// <summary>
        /// Overall size of the object
        /// </summary>
        public override int Size
        {
            get { return 25000; }
        }

        /// <summary>
        /// True if the container is locked else false
        /// </summary>
        public bool IsLocked { get; internal set; }

        /// <summary>
        /// The current amount of soap remaining in the dishwasher.  
        /// When the soap runs out, washing is less effective
        /// </summary>
        public decimal CurrentSoapCapacity { get; internal set; }

        /// <summary>
        /// The current contents of the dishwasher, which gives information about cleanliness and so forth
        /// </summary>
        public IEnumerable<IWashableObject> DishwasherContents
        {
            get
            {
                return Contents.OfType<IWashableObject>().ToArray();
            }
        }

        /// <summary>
        /// Creates an instance of Dishwasher
        /// </summary>
        internal Dishwasher() : base(20000)
        {
        }

        /// <summary>
        /// Reports whether or not the contents are currently clean
        /// </summary>
        /// <returns>True if the contents are clean or the dishwasher is empty, else false</returns>
        public bool ContentsAreClean()
        {
            return DishwasherContents.All(x => x.DirtRating == DirtRating.SqueakyClean);
        }

        /// <summary>
        /// Loads a single item into the dishwasher
        /// </summary>
        /// <param name="objectToLoad">The item to load</param>
        /// <remarks>
        /// This overload accepts regular washable items
        /// </remarks>
        public void Load(WashableObject objectToLoad)
        {
            if (!objectToLoad.IsDishwasherSafe)
            {
                throw new DishwasherException("Are you nuts? You can't put this in a dishwasher!");
            }
            Transfer(objectToLoad).To(this);
        }

        /// <summary>
        /// Loads a single item into the dishwasher
        /// </summary>
        /// <param name="objectToLoad">The item to load</param>
        /// <remarks>
        /// This overload accepts washable items that are containers
        /// </remarks>
        public void Load(WashableContainerObject objectToLoad)
        {
            if (!objectToLoad.IsDishwasherSafe)
            {
                throw new DishwasherException("Are you nuts? You can't put this in a dishwasher!");
            }
            if (!objectToLoad.IsEmpty)
            {
                throw new DishwasherException("Containers need to be emptied before placing in the dishwasher.");
            }
            Transfer(objectToLoad).To(this);
        }

        public IEnumerable<IWashableObject> TakeTheseItemsOut(Func<IWashableObject, bool> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes all 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WorldObject> TakeEverythingOut()
        {
            return InternalContainer.RemoveAllObjects();
        }

        /// <summary>
        /// Washes all items currently being held
        /// </summary>
        public void StartWashing()
        {
        }

        /// <summary>
        /// Locks the container
        /// </summary>
        public void Lock()
        {
            if (IsLocked)
            {
                throw new InappropriateBehaviorException("Cannot lock the dishwasher if it's already locked.");
            }
            IsLocked = true;
        }

        /// <summary>
        /// Unlocks the container
        /// </summary>
        public void Unlock()
        {
            if (!IsLocked)
            {
                throw new InappropriateBehaviorException("Cannot unlock the dishwasher if it's already unlocked.");
            }
            IsLocked = false;
        }
    }
}