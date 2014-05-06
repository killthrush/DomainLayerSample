using System.Linq;
using Domain.Base;
using Domain.Exceptions;

namespace Domain
{
    /// <summary>
    /// A house in which objects can dwell.  A dwelling, if you will.
    /// </summary>
    public class House : ContainerObject, IHasColor
    {
        /// <summary>
        /// The number of stories in the house
        /// </summary>
        private int _numberOfStories;

        /// <summary>
        /// Overall size of the object
        /// </summary>
        public override int Size
        {
            get { return 250000; }
        }

        /// <summary>
        /// The house's address
        /// </summary>
        public Address Address { get; internal set; }

        /// <summary>
        /// The color of the house
        /// </summary>
        public Color Color { get; internal set; }

        /// <summary>
        /// The number of stories in the house
        /// </summary>
        public int NumberOfStories
        {
            get
            {
                return _numberOfStories;
            }
            internal set
            {
                if (value > 4 && value <= 0)
                {
                    throw new BuildingCodeException("The building code states that all houses should be between 1 and 4 stories.");  // TODO: might need to move this to the constructor
                }
                _numberOfStories = value;
            }
        }

        /// <summary>
        /// The yard outside the house (if any)
        /// </summary>
        public Yard Yard
        {
            get { return ParentContainerObject as Yard; }
        }

        /// <summary>
        /// The dishwasher that comes standard with every house
        /// </summary>
        public Dishwasher Dishwasher
        {
            get { return Contents.OfType<Dishwasher>().FirstOrDefault(); }
        }

        /// <summary>
        /// The kitchen cabinet that comes standard with every house
        /// </summary>
        public KitchenCabinet KitchenCabinet
        {
            get { return Contents.OfType<KitchenCabinet>().FirstOrDefault(); }
        }

        /// <summary>
        /// The refrigerator that comes standard with every house
        /// </summary>
        public Fridge Refrigerator
        {
            get { return Contents.OfType<Fridge>().FirstOrDefault(); }
        }

        /// <summary>
        /// Initializes a new instance of the House class.
        /// </summary>
        internal House() : base(200000)
        {
            Transfer(new Dishwasher()).To(this); // TODO: logic like this will cause a problem when deserializing from SQL
            Transfer(new KitchenCabinet()).To(this);
            Transfer(new Fridge()).To(this);
        }
    }
}
