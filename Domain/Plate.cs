using Domain.Base;

namespace Domain
{
    /// <summary>
    /// An unusually heavy frisbee, made out of some sort of ceramic.
    /// </summary>
    public class Plate : WashableContainerObject
    {
        /// <summary>
        /// Overall size of the object
        /// </summary>
        public override int Size
        {
            get { return 200; }
        }

        /// <summary>
        /// How long it takes to make the object totally clean
        /// </summary>
        public override int MinutesRequiredToClean
        {
            get { return 20; }
        }

        /// <summary>
        /// Flag that indicates whether or not the item is dishwasher-safe
        /// </summary>
        public override bool IsDishwasherSafe
        {
            get { return true; }
        }

        /// <summary>
        /// Creates an instance of Plate
        /// </summary>
        public Plate() : base(2000)
        {
        }
    }
}
