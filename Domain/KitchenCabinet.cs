using System.Collections.Generic;
using System.Linq;
using Domain.Base;

namespace Domain
{
    /// <summary>
    /// Where you can find all sorts of household paraphernalia.
    /// Please don't put dirty dishes in the cabinet.
    /// </summary>
    public class KitchenCabinet : ContainerObject
    {
        private const int DefaultForkCount = 12;
        private const int DefaultKnifeCount = 12;
        private const int DefaultPanCount = 2;
        private const int DefaultGlassCount = 6;
        private const int DefaultPlateCount = 10;
        private const int DefaultSpoonCount = 8;

        /// <summary>
        /// Overall size of the object
        /// </summary>
        public override int Size
        {
            get { return 25000; }
        }

        /// <summary>
        /// The spoons that are in the cabinet (if any)
        /// </summary>
        public IEnumerable<Spoon> Spoons
        {
            get { return Contents.OfType<Spoon>().ToArray(); }
        }

        /// <summary>
        /// The forks that are in the cabinet (if any)
        /// </summary>
        public IEnumerable<Fork> Forks
        {
            get { return Contents.OfType<Fork>().ToArray(); }
        }

        /// <summary>
        /// The knives that are in the cabinet (if any)
        /// </summary>
        public IEnumerable<Knife> Knives
        {
            get { return Contents.OfType<Knife>().ToArray(); }
        }

        /// <summary>
        /// The glasses that are in the cabinet (if any)
        /// </summary>
        public IEnumerable<Glass> Glasses
        {
            get { return Contents.OfType<Glass>().ToArray(); }
        }

        /// <summary>
        /// The plates that are in the cabinet (if any)
        /// </summary>
        public IEnumerable<Plate> Plates
        {
            get { return Contents.OfType<Plate>().ToArray(); }
        }

        /// <summary>
        /// The frying pans that are in the cabinet (if any)
        /// </summary>
        public IEnumerable<FryingPan> Pans
        {
            get { return Contents.OfType<FryingPan>().ToArray(); }
        }

        /// <summary>
        /// The sphereflake that's in the cabinet (if any)
        /// </summary>
        public SphereFlake SphereFlake
        {
            get { return Contents.OfType<SphereFlake>().FirstOrDefault(); }
        }

        /// <summary>
        /// The bag of holding that's in the cabinet (if any)
        /// </summary>
        public BagOfHolding MagicBag
        {
            get { return Contents.OfType<BagOfHolding>().FirstOrDefault(); }
        }

        /// <summary>
        /// Initializes a new instance of the KitchenCabinet class.
        /// </summary>
        internal KitchenCabinet() : base(20000)
        {
            CreateObjects<Spoon>(DefaultSpoonCount);
            CreateObjects<Fork>(DefaultForkCount);
            CreateObjects<Knife>(DefaultKnifeCount);
            CreateObjects<FryingPan>(DefaultPanCount);
            CreateObjects<Glass>(DefaultGlassCount);
            CreateObjects<Plate>(DefaultPlateCount);
            Transfer(new SphereFlake()).To(this);
            Transfer(new BagOfHolding()).To(this);
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
