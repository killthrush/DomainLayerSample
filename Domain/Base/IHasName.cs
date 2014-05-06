namespace Domain.Base
{
    /// <summary>
    /// Feature interface for objects that can have names
    /// </summary>
    public interface IHasName : IWorldObject
    {
        /// <summary>
        /// The name
        /// </summary>
        string Name { get; }
    }
}