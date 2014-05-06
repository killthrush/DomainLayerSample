namespace Domain.Base
{
    /// <summary>
    /// Feature interface for items that can be eaten
    /// </summary>
    public interface IFood : IHouseholdObject
    {
        /// <summary>
        /// Returns the number of calories in this food
        /// </summary>
        int Calories { get; }

        /// <summary>
        /// Returns true if the food is cooked else false
        /// </summary>
        bool IsCooked { get; }

        /// <summary>
        /// Cooks the item - some items require cooking before eating.
        /// </summary>
        void Cook();

        /// <summary>
        /// Attempt to eat this item with utensils
        /// </summary>
        /// <param name="utensils">One or more utensils which will be used to eat the item</param>
        void EatWith(params IUtensil[] utensils);
    }
}