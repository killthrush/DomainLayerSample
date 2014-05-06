using Domain.Base;

namespace Domain
{
    /// <summary>
    /// Fun fact: hiding your money under the soap keeps it safe from hippies.
    /// </summary>
    public class BarOfSoap : WashableObject, IHouseholdObject
    {
        /// <summary>
        /// Overall size of the object
        /// </summary>
        public override int Size
        {
            get { return 30; }
        }

        /// <summary>
        /// How long it takes to make the object totally clean
        /// </summary>
        public override int MinutesRequiredToClean
        {
            get { return 1; } // It's pretty easy to keep the soap clean!
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
