using Domain.Base;
using Domain.Exceptions;

namespace Domain
{
    /// <summary>
    /// "One day I became so desperate for a beer, I went to the football stadium and ate the dirt under the bleachers."
    /// -Homer
    /// </summary>
    public class Beer : WorldObject, IBeverage
    {
        /// <summary>
        /// The amount of liquid that this object represents
        /// </summary>
        private readonly int _amountOfLiquid;

        /// <summary>
        /// Overall size of the object
        /// </summary>
        public override int Size
        {
            get { return _amountOfLiquid; }
        }

        /// <summary>
        /// Returns the number of calories in this beverage
        /// </summary>
        public int Calories
        {
            get { return _amountOfLiquid*50; }
        }

        /// <summary>
        /// Creates an instance of Beer
        /// </summary>
        /// <param name="amountOfLiquid">The amount of liquid that this object represents</param>
        public Beer(int amountOfLiquid)
        {
            if (amountOfLiquid < 1)
            {
                throw new BeverageException("The amount of liquid must be greater than zero.");
            }
            _amountOfLiquid = amountOfLiquid;
        }

        /// <summary>
        /// Attempt to drink this item
        /// </summary>
        public void Drink()
        {
            throw new System.NotImplementedException();
        }
    }
}