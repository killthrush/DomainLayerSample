using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Base;
using Domain.Exceptions;

namespace Domain.FluentInterface
{
    /// <summary>
    /// Helper class used to provide a fluent interface for drinking stuff
    /// </summary>
    public class DrinkOperator
    {
        /// <summary>
        /// The beverage that will be consumed
        /// </summary>
        private readonly IBeverage _beverage;

        /// <summary>
        /// The avatar performing the action
        /// </summary>
        private readonly Avatar _avatar;

        /// <summary>
        /// Initializes a new instance of the DrinkOperator class.
        /// </summary>
        /// <param name="avatar">The avatar performing the action</param>
        /// <param name="beverage">The beverage that will be consumed</param>
        public DrinkOperator(Avatar avatar, IBeverage beverage) // TODO: this should use a concrete type
        {
            _beverage = beverage;
            _avatar = avatar;
        }

        /// <summary>
        /// Attempts to drink the item from the given container
        /// </summary>
        /// <param name="beverageContainer">The container from which to drink the beverage</param>
        public void From(IBeverageContainer beverageContainer)
        {
            IBeverageContainer[] beverageContainers = new[] {beverageContainer};

            IEnumerable<Guid> idsForObjectsBeingHeld = _avatar.Contents.Select(x => x.ObjectId);
            IEnumerable<Guid> beverageContainerObjectIds = beverageContainers.OfType<WorldObject>().Select(x => x.ObjectId);
            bool tryingToUseContainerNotBeingHeld = beverageContainerObjectIds.Except(idsForObjectsBeingHeld).Any();

            if (tryingToUseContainerNotBeingHeld)
            {
                throw new LawsOfPhysicsViolationException("You do not have telekinesis! You need to pick the item(s) up first.");
            }

            _beverage.Drink();
        }
    }
}