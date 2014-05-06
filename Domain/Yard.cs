using System.Linq;
using Domain.Base;
using Domain.Exceptions;

namespace Domain
{
    /// <summary>
    /// A yard in which you can place one (and only one) house
    /// </summary>
    public class Yard : ContainerObject, IIsOutdoors
    {
        /// <summary>
        /// Overall size of the object
        /// </summary>
        public override int Size
        {
            get { return 500000; }
        }

        /// <summary>
        /// The house that's in the yard (if any)
        /// </summary>
        public House House
        {
            get { return Contents.OfType<House>().FirstOrDefault(); }
        }

        /// <summary>
        /// Initializes a new instance of the Yard class.
        /// </summary>
        public Yard() : base(500000)
        {
        }

        /// <summary>
        /// Builds a new house in the yard
        /// </summary>
        /// <returns>The newly-built house</returns>
        public House BuildHouse()
        {
            if (HouseIsInYard())
            {
                throw new BuildingCodeException("You can't build a second house in this yard.");
            }

            House house = new House();
            Transfer(house).To(this);
            return house;
        }

        /// <summary>
        /// Determines if a house is present
        /// </summary>
        /// <returns>Returns true if a house has already been built in the yard else false</returns>
        private bool HouseIsInYard()
        {
            return House != null;
        }
    }
}
