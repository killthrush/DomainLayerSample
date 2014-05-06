using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Base;

namespace Domain
{
    /// <summary>
    /// The whole wide world.
    /// Probably can have a lot of items in it...
    /// </summary>
    public class WideWorld : ContainerObject, IIsOutdoors
    {
        /// <summary>
        /// The number of dogs to create out of thin air when creating the world
        /// </summary>
        private const int DefaultNumberOfDogs = 10;

        /// <summary>
        /// A random number generator
        /// </summary>
        private static readonly Random RandomNumberGenerator = new Random();

        /// <summary>
        /// Helper property to retrieve the list of known plots where we can have houses and stuff
        /// </summary>
        public IEnumerable<Yard> ResidentialPlots 
        {
            get
            {
                return Contents.OfType<Yard>();
            }
        }

        /// <summary>
        /// Helper property to retrieve the list of wild dogs out there
        /// </summary>
        public IEnumerable<Dog> WildDogs
        {
            get
            {
                return Contents.OfType<Dog>();
            }
        }

        /// <summary>
        /// Overall size of the object
        /// </summary>
        public override int Size
        {
            get { return 0; }
        }

        /// <summary>
        /// Initializes a new instance of the WideWorld class.
        /// </summary>
        public WideWorld() : base(int.MaxValue)
        {
            Transfer(this).To(this); // This item is its own container (insert obscure set-theoretic reference here)

            // The world comes with a pack of semi-feral pomeranians by default
            for (int i = 0; i < DefaultNumberOfDogs; i++)
            {
                Dog wildDog = new Dog();
                Transfer(wildDog).To(this);
            }
        }

        /// <summary>
        /// Invokes the almighty building code to draw up a new plot of land for building houses and washing dishes.
        /// </summary>
        /// <returns></returns>
        public Yard DrawResidentialPlot()
        {
            Yard yard = new Yard();
            Transfer(yard).To(this);
            return yard;
        }

        /// <summary>
        /// Find a dog out there somewhere
        /// </summary>
        public Dog FindRandomDog()
        {
            int randomIndex = RandomNumberGenerator.Next() % 10;
            return WildDogs.ElementAt(randomIndex);
        }
    }
}
