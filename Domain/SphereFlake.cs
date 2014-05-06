using Domain.Base;

namespace Domain
{
    /// <summary>
    /// A model of a sphereflake.
    /// A nearly infinite surface area yields a nearly infinite capacity to accumulate dirt!
    /// </summary>
    public class SphereFlake : WashableObject
    {
        /// <summary>
        /// Overall size of the object
        /// </summary>
        public override int Size
        {
            get { return 2; }
        }

        /// <summary>
        /// How long it takes to make the object totally clean
        /// </summary>
        public override int MinutesRequiredToClean
        {
            get { return 144000; }
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
