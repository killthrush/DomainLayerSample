using Domain.Base;

namespace Domain
{
    /// <summary>
    /// A large heavy frying pan for cooking bacon.
    /// MMMMMM.... Unexplained Bacon.
    /// </summary>
    public class FryingPan : WashableContainerObject
    {
        /// <summary>
        /// True if the frying pan currently contains bacon
        /// </summary>
        internal bool HasBacon { get; set; }

        /// <summary>
        /// True if the frying pan currently contains cooked bacon
        /// </summary>
        internal bool BaconIsCooked { get; set; }

        /// <summary>
        /// Overall size of the object
        /// </summary>
        public override int Size
        {
            get { return 500; }
        }

        /// <summary>
        /// How long it takes to make the object totally clean
        /// </summary>
        public override int MinutesRequiredToClean
        {
            get { return 45; }
        }

        /// <summary>
        /// Flag that indicates whether or not the item is dishwasher-safe
        /// </summary>
        public override bool IsDishwasherSafe
        {
            get { return true; }
        }

        /// <summary>
        /// Creates an instance of FryingPan
        /// </summary>
        public FryingPan() : base(250)
        {
        }

        public void AddBacon()
        {
            PercentClean = 50m;
        }

        public void CookBacon()
        {
            PercentClean = 0m;
        }

        public void ConsumeBacon()
        {

        }
    }
}
