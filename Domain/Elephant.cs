using Domain.Base;

namespace Domain
{
    /// <summary>
    /// A very large, somewhat irascible pachyderm.
    /// </summary>
    public class Elephant : WashableObject, IHasName
    {
        /// <summary>
        /// Overall size of the object
        /// </summary>
        public override int Size
        {
            get { return 100000; }
        }

        /// <summary>
        /// How long it takes to make the object totally clean
        /// </summary>
        public override int MinutesRequiredToClean
        {
            get { return 240; }
        }

        /// <summary>
        /// Flag that indicates whether or not the item is dishwasher-safe
        /// </summary>
        public override bool IsDishwasherSafe
        {
            get { return false; }
        }

        /// <summary>
        /// The name of the elephant
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// A measurement of the elephant's patience.  Don't let it run out!
        /// </summary>
        public decimal Patience { get; set; }

        /// <summary>
        /// Ok, here's what happens when you annoy the elephant
        /// </summary>
        private void Trample()
        {
            
        }
    }
}
