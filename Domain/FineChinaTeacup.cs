using Domain.Base;

namespace Domain
{
    /// <summary>
    /// Part of your aunt Sally's antique fine china collection, which you were warned about when you were 6 years old.
    /// It's probably not even a good idea to let photons hit this thing, let alone oxygen, grubby fingers, and erm... beer.
    /// </summary>
    public class FineChinaTeacup : WashableContainerObject, IBeverageContainer
    {
        /// <summary>
        /// Initializes a new instance of the FineChinaTeacup class.
        /// </summary>
        public FineChinaTeacup() : base(25)
        {
        }

        /// <summary>
        /// Overall size of the object
        /// </summary>
        public override int Size
        {
            get { return 35; }
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
            get { return false; }
        }
    }
}
