using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Base;
using Domain.Exceptions;

namespace Domain.FluentInterface
{
    /// <summary>
    /// Helper class used to provide a fluent interface for eating stuff
    /// </summary>
    public class EatOperator
    {
        /// <summary>
        /// The food that will be consumed
        /// </summary>
        private readonly IFood _food;

        /// <summary>
        /// The avatar performing the action
        /// </summary>
        private readonly Avatar _avatar;

        /// <summary>
        /// Initializes a new instance of the EatOperator class.
        /// </summary>
        /// <param name="avatar">The avatar performing the action</param>
        /// <param name="food">The food that will be consumed</param>
        public EatOperator(Avatar avatar, IFood food)
        {
            _food = food;
            _avatar = avatar;
        }

        /// <summary>
        /// Attempts to eat the item with the given utensils
        /// </summary>
        /// <param name="utensils">One or more utensils which will be used to eat the item</param>
        public void With(params IUtensil[] utensils)
        {
            IEnumerable<Guid> idsForObjectsBeingHeld = _avatar.Contents.Select(x => x.ObjectId);
            IEnumerable<Guid> utensilObjectIds = utensils.OfType<WorldObject>().Select(x => x.ObjectId);
            bool tryingToUseUtensilsNotBeingHeld = utensilObjectIds.Except(idsForObjectsBeingHeld).Any();

            if (tryingToUseUtensilsNotBeingHeld)
            {
                throw new LawsOfPhysicsViolationException("You do not have telekinesis! You need to pick the item(s) up first.");
            }

            _food.EatWith(utensils);

            IEnumerable<WashableObject> washableUtensils = utensils.OfType<WashableObject>();
            foreach (var washableUtensil in washableUtensils)
            {
                washableUtensil.PercentClean = 80m;  // TODO: this should move to the utensil itself
            }
        }
    }
}