namespace Domain.Base
{
    /// <summary>
    /// Feature interface for objects that can have color
    /// </summary>
    public interface IHasColor : IWorldObject
    {
        /// <summary>
        /// The color of the object
        /// </summary>
        Color Color { get; }
    }
}