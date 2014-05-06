using Domain.Base;

namespace Domain
{
    /// <summary>
    /// A common pint-glass for serving beer.  It is half-full.  No wait, half-empty... Ah, screw it.
    /// </summary>
    public class Glass : WashableContainerObject, IBeverageContainer
    {
        /// <summary>
        /// Initializes a new instance of the Glass class.
        /// </summary>
        public Glass() : base(50)
        {
        }

        /// <summary>
        /// Overall size of the object
        /// </summary>
        public override int Size
        {
            get { return 65; }
        }

        /// <summary>
        /// How long it takes to make the object totally clean
        /// </summary>
        public override int MinutesRequiredToClean
        {
            get { return 15; }
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
