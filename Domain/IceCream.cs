using System.Linq;
using Domain.Base;
using Domain.Exceptions;

namespace Domain
{
    /// <summary>
    /// Delicious sea-salt flavored ice cream with kelp and octopus chunks
    /// </summary>
    public class IceCream : WorldObject, IFood
    {
        /// <summary>
        /// True if the food is cooked else false
        /// </summary>
        private bool _isCooked;

        /// <summary>
        /// Overall size of the object.
        /// </summary>
        public override int Size
        {
            get { return 50; }
        }

        /// <summary>
        /// Returns the number of calories in this ice cream
        /// </summary>
        public int Calories
        {
            get { return 2000; }
        }

        /// <summary>
        /// True if the food is cooked else false
        /// </summary>
        public bool IsCooked
        {
            get { return _isCooked; }
            set { _isCooked = value; }
        }

        /// <summary>
        /// Creates an instance of IceCream
        /// </summary>
        public IceCream()
        {
            _isCooked = true;
        }

        /// <summary>
        /// Cooks the item
        /// </summary>
        public void Cook()
        {
            ParentContainerObject.Transfer(this).ToLimbo();
            throw new InappropriateBehaviorException("The ice cream burns away into nothingness. Nice job, Einstein!");
        }

        /// <summary>
        /// Attempt to eat this item with utensils
        /// </summary>
        /// <param name="utensils">One or more utensils which will be used to eat the item</param>
        public void EatWith(params IUtensil[] utensils)
        {
            Spoon spoon = utensils.OfType<Spoon>().FirstOrDefault();
            if (spoon == null)
            {
                throw new InappropriateBehaviorException("You flail wildly at the ice cream but can't seem to eat it.  Maybe a different implement will do?");
            }
            ParentContainerObject.Transfer(this).ToLimbo(); // Where the food goes when you eat it
        }
    }
}