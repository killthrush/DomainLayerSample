using System;
using Domain.Base;
using Domain.Exceptions;

namespace Domain
{
    /// <summary>
    /// A small Pomeranian.  We will not rent it shoes, we will not buy it a beer, and it will not take the Dude's turn.
    /// </summary>
    public class Dog : WashableObject, IHasName, IHasColor
    {
        /// <summary>
        /// Overall size of the object
        /// </summary>
        public override int Size
        {
            get { return 1500; }
        }

        /// <summary>
        /// How long it takes to make the object totally clean
        /// </summary>
        public override int MinutesRequiredToClean
        {
            get { return 60; }
        }

        /// <summary>
        /// Flag that indicates whether or not the item is dishwasher-safe
        /// </summary>
        public override bool IsDishwasherSafe
        {
            get { return false; }
        }

        /// <summary>
        /// The name of the dog
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// The color of the dog
        /// </summary>
        public Color Color { get; internal set; }

        /// <summary>
        /// Counts the number of holes the dog has dug in the yard
        /// </summary>
        public int HolesDug { get; internal set; }

        /// <summary>
        /// Counts the number of times the dog rolled in mud
        /// </summary>
        public int TimesRolledInMud { get; internal set; }

        /// <summary>
        /// The dirtier the dog, the higher the stench.
        /// This is a very scientific measurement.
        /// </summary>
        public decimal StenchFactor
        {
            get
            {
                return (100 - PercentClean) * (decimal)Math.PI;
            }
        }

        /// <summary>
        /// True if the dog is outdoors, otherwise false
        /// </summary>
        public bool IsOutside
        {
            get { return (ParentContainerObject != null && ParentContainerObject is IIsOutdoors); }
        }

        /// <summary>
        /// True if the dog is wild (does not have a name)
        /// </summary>
        public bool IsWild
        {
            get { return Name == null; }
        }

        /// <summary>
        /// Allows a wandering dog to wander into a particular yard from somewhere else
        /// </summary>
        /// <param name="yard">The yard into which the dog will wander</param>
        public void WanderInto(Yard yard)
        {
            CheckMovementRules();
            yard.Transfer(this).To(yard);
        }

        /// <summary>
        /// Allows a wandering dog to wander into a particular house
        /// </summary>
        /// <param name="house">The house into which the dog will wander</param>
        public void WanderInto(House house)
        {
            CheckMovementRules();
            house.Transfer(this).To(house);
        }

        /// <summary>
        /// Dig a hole in the backyard.  SQUIRREL!
        /// </summary>
        public void DigHole()
        {
            if (!IsOutside)
            {
                throw new InappropriateBehaviorException("This dog can't dig a hole unless it's outside.");
            }
            PercentClean = Math.Max(PercentClean - 75, 0);
            HolesDug++;
        }

        /// <summary>
        /// Roll in cool, comfortable, relaxing mud.  
        /// </summary>
        public void RollInMud()
        {
            if (!IsOutside)
            {
                throw new InappropriateBehaviorException("This dog can't roll in mud unless it's outside.");
            }
            PercentClean = 0;
            TimesRolledInMud++;
        }

        /// <summary>
        /// Allows you to name a dog
        /// </summary>
        /// <param name="name">The name</param>
        public void GiveName(string name)
        {
            if (name == null || name.Length > 100)
            {
                throw new NameException(string.Format("The name '{0}' is not valid for the dog.", name));
            }
            Name = name;
        }

        /// <summary>
        /// Internal state check to see if the dog can move around on its own or not
        /// </summary>
        private void CheckMovementRules()
        {
            if (ParentContainerObject == null)
            {
                throw new LawsOfPhysicsViolationException("The dog is floating in limbo and really can't go anywhere.");
            }
            if (ParentContainerObject is IPreventsThingsInsideFromGettingOut)
            {
                throw new StuckException("The dog can't move while restrained.");
            }

            // TODO: add constraints: It should be able to go to any yard from any yard, any house to its yard, any yard to its house.  
        }
    }
}
