using Domain.Base;

namespace Domain
{
    /// <summary>
    /// A magic bag for which to store large quanties of gold, suits of armor, and dozens of halberds.
    /// Like the Doctor's phonebooth, it's larger on the inside!
    /// </summary>
    public class BagOfHolding : ContainerObject, IPreventsThingsInsideFromGettingOut
    {
        /// <summary>
        /// Overall size of the object
        /// </summary>
        public override int Size
        {
            get { return 1; }
        }

        /// <summary>
        /// Initializes a new instance of the BagOfHolding class.
        /// </summary>
        internal BagOfHolding() : base(150000)
        {
        }
    }
}
