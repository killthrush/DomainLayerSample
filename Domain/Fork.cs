using Domain.Base;

namespace Domain
{
    /// <summary>
    /// One-half of a spork (or perhaps a semi-foon)
    /// </summary>
    public class Fork : WashableObject, IUtensil
    {
        /// <summary>
        /// Overall size of the object
        /// </summary>
        public override int Size
        {
            get { return 5; }
        }

        /// <summary>
        /// How long it takes to make the object totally clean
        /// </summary>
        public override int MinutesRequiredToClean
        {
            get { return 10; }
        }

        /// <summary>
        /// Flag that indicates whether or not the item is dishwasher-safe
        /// </summary>
        public override bool IsDishwasherSafe
        {
            get { return true; }
        }
    }
}
