using System.Linq;
using Domain.Base;
using Domain.Exceptions;

namespace Domain
{
    /// <summary>
    /// A huge slab of delicious bacon.
    /// Please cook it before eating!
    /// </summary>
    public class BaconSlab : WorldObject, IFood
    {
        private const int MaxBaconSize = 100;

        /// <summary>
        /// Overall size of the object.
        /// Depending on how thick the bacon is, the size changes.
        /// </summary>
        public override int Size
        {
            get { return MaxBaconSize; }
        }

        /// <summary>
        /// Returns the number of calories in this slice of bacon
        /// </summary>
        public int Calories 
        { 
            get
            {
                return Size * 150;
            }
        }

        /// <summary>
        /// True if the food is cooked else false
        /// </summary>
        public bool IsCooked { get; internal set; }

        public BaconSlab Slice()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Cooks the item - some items require cooking before eating.
        /// </summary>
        public void Cook()
        {
            if (IsCooked)
            {
                ParentContainerObject.Transfer(this).ToLimbo();
                throw new InappropriateBehaviorException("The bacon burns away into nothingness. Nice job, Einstein!");
            }
            IsCooked = true;
        }

        /// <summary>
        /// Attempt to eat this item with utensils
        /// </summary>
        /// <param name="utensils">One or more utensils which will be used to eat the item</param>
        public void EatWith(params IUtensil[] utensils)
        {
            if (!IsCooked)
            {
                throw new TrichinosisException("You fool! You should never eat raw bacon!");
            }
            Fork fork = utensils.OfType<Fork>().FirstOrDefault();
            Knife knife = utensils.OfType<Knife>().FirstOrDefault();
            if (fork == null || knife == null)
            {
                throw new InappropriateBehaviorException("You flail wildly at the bacon but can't seem to eat it.  Maybe a different implement will do?");
            }
            ParentContainerObject.Transfer(this).ToLimbo(); // Where the food goes when you eat it
        }
    }
}
