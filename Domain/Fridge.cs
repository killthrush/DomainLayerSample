using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Base;
using Domain.Exceptions;

namespace Domain
{
    /// <summary>
    /// Where food & beverages magically appear.
    /// </summary>
    public class Fridge : ContainerObject
    {
        private const int DefaultBaconCount = 5;
        private const int DefaultIceCreamCount = 3;
        private const int DefaultBeerAmount = 500;

        /// <summary>
        /// Overall size of the object
        /// </summary>
        public override int Size
        {
            get { return 25000; }
        }

        /// <summary>
        /// The slabs of bacon that are in the fridge (if any)
        /// </summary>
        public IEnumerable<BaconSlab> BaconSlabs
        {
            get { return Contents.OfType<BaconSlab>().ToArray(); }
        }

        /// <summary>
        /// The ice cream tubs that are in the fridge (if any)
        /// </summary>
        public IEnumerable<IceCream> IceCreamTubs
        {
            get { return Contents.OfType<IceCream>().ToArray(); }
        }

        /// <summary>
        /// Indicates the amount of beer remaining in the fridge.
        /// It will be a sad day if this reaches zero.
        /// </summary>
        public int BeerRemaining { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the Fridge class.
        /// </summary>
        internal Fridge() : base(20000)
        {
            CreateObjects<BaconSlab>(DefaultBaconCount); // TODO: this will create an issue with deserialization from SQL
            CreateObjects<IceCream>(DefaultIceCreamCount);
            BeerRemaining = DefaultBeerAmount;
        }

        /// <summary>
        /// Allows the dispensation of beer into a container
        /// </summary>
        /// <param name="container">The container into which to dispense beer</param>
        internal void DispenseBeerInto(ContainerObject container)
        {
            if (BeerRemaining == 0)
            {
                throw new BeverageException("Oh no! The beer is gone! (apocalyptic music plays)");
            }

            if (!(container is IBeverageContainer))
            {
                throw new BeverageException("This is really going to make a mess...");
            }

            if (container is WashableContainerObject)
            {
                var washableContainer = container as WashableContainerObject;
                washableContainer.PercentClean = 80m;
            }

            int amountOfLiquid = Math.Min(container.RemainingCapacity, BeerRemaining);
            Transfer(new Beer(amountOfLiquid)).To(container);
            BeerRemaining = Math.Max(BeerRemaining - amountOfLiquid, 0);
        }

        /// <summary>
        /// Helper method to quickly create large numbers of household items
        /// </summary>
        /// <typeparam name="T">The type of object to create</typeparam>
        /// <param name="numberToCreate">The number to create</param>
        private void CreateObjects<T>(int numberToCreate)
            where T : WorldObject, new()
        {
            for (int i = 0; i < numberToCreate; i++)
            {
                Transfer(new T()).To(this);
            }
        }
    }
}
