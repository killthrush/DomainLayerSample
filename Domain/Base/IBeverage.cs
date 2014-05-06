namespace Domain.Base
{
    /// <summary>
    /// Feature interface for beverages
    /// </summary>
    public interface IBeverage : IHouseholdObject
    {
        /// <summary>
        /// Returns the number of calories in this beverage
        /// </summary>
        int Calories { get; }

        /// <summary>
        /// Attempt to drink this item
        /// </summary>
        void Drink();
    }
}