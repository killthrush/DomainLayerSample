using Domain.Base;

namespace Domain
{
    /// <summary>
    /// A common steel spoon.  Or, if you prefer, a justice-filled battle cry!
    /// </summary>
    public class Spoon : WashableObject, IUtensil
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
