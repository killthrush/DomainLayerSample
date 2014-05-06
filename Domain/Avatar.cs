using System.Linq;
using Domain.Base;
using Domain.Exceptions;
using Domain.FluentInterface;

namespace Domain
{
    /// <summary>
    /// You.  
    /// Allows you to interact with the world.
    /// </summary>
    public class Avatar : ContainerObject, IPreventsThingsInsideFromGettingOut, ICanWashStuff, IHasName
    {
        /// <summary>
        /// Event handler(s) for when the average dirt rating for objects being washed improves.
        /// </summary>
        public event DirtRatingImprovementEvent.EventHandler NotifyWhenDirtRatingImproves;

        /// <summary>
        /// Event handler(s) for when all objects being washed are squeaky clean.
        /// </summary>
        public event ItemsAreTotallyCleanEvent.EventHandler NotifyWhenItemsAreTotallyClean;

        /// <summary>
        /// How much we can hold in our hands.  It's not that much.
        /// </summary>
        private const int HandCapacity = 2000;

        /// <summary>
        /// The default soap factor for washing items
        /// </summary>
        private const int DefaultSoapFactor = 1;

        /// <summary>
        /// Your name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The total number of calories you've consumed
        /// </summary>
        public int CaloriesConsumed { get; internal set; }

        /// <summary>
        /// Overall size of the object
        /// </summary>
        public override int Size
        {
            get { return 0; } // The Avatar is kind of magical and can float around and not be constrained
        }

        /// <summary>
        /// Creates an instance of Avatar
        /// </summary>
        public Avatar() : base(HandCapacity)
        {
        }

        /// <summary>
        /// Creates an instance of Avatar
        /// </summary>
        public Avatar(string name) : base(HandCapacity)
        {
            if (name == null || name.Length > 100)
            {
                throw new NameException(string.Format("The name '{0}' is not valid for your Avatar.", name));
            }
            Name = name;
        }

        /// <summary>
        /// Picks up an object
        /// </summary>
        /// <param name="objectToPickUp">The object to pick up</param>
        public void PickUp(WorldObject objectToPickUp)
        {
            Transfer(objectToPickUp).To(this);
        }

        /// <summary>
        /// Moves an object you've picked up from one container to another
        /// </summary>
        /// <param name="objectToMove">The object to move </param>
        /// <returns>An object used to complete the operation</returns>
        public PutOperator Put(WorldObject objectToMove)
        {
            return new PutOperator(this, objectToMove);
        }

        /// <summary>
        /// Attempt to eat the given object
        /// </summary>
        /// <param name="food">The food to be consumed</param>
        /// <returns>An object used to complete the operation</returns>
        public EatOperator Eat(IFood food)
        {
            return new EatOperator(this, food);
        }

        /// <summary>
        /// Attempt to drink the given object
        /// </summary>
        /// <param name="beverage"></param>
        /// <returns>An object used to complete the operation</returns>
        public DrinkOperator Drink(IBeverage beverage)
        {
            return new DrinkOperator(this, beverage);
        }

        /// <summary>
        /// Attempt to dispense a beverage from the fridge
        /// </summary>
        /// <param name="fridge">The fridge containing the beverage</param>
        /// <returns>An object used to complete the operation</returns>
        public DispenseBeerOperator DispenseBeerFrom(Fridge fridge)
        {
            return new DispenseBeerOperator(this, fridge);
        }

        /// <summary>
        /// Washes all items being held.
        /// </summary>
        public void StartWashing()
        {
            IWashableObject[] objectsToWash = Contents.OfType<IWashableObject>().ToArray();
            PerformWashing(objectsToWash);
        }

        /// <summary>
        /// Algorithm for actually washing a bunch of washable items
        /// </summary>
        /// <param name="objectsToWash">The objects to wash</param>
        private void PerformWashing(IWashableObject[] objectsToWash)
        {
            if (Contents.Count(x => !(x is IWashableObject)) > 0)
            {
                throw new InappropriateBehaviorException("You can't wash anything while holding something that can't be washed.");
            }

            decimal currentAveragePercentClean = objectsToWash.Average(x => x.PercentClean);
            DirtRating currentAverageDirtRating = WashableObjectExtensions.CalculateDirtRating(currentAveragePercentClean);
            int minutesElapsed = 0;
            while (currentAveragePercentClean < 100m)
            {
                foreach (var washableObject in objectsToWash)
                {
                    washableObject.WashForOneMinute(DefaultSoapFactor);
                }

                currentAveragePercentClean = objectsToWash.Average(x => x.PercentClean);
                DirtRating calculatedDirtRating = WashableObjectExtensions.CalculateDirtRating(currentAveragePercentClean);
                if (currentAverageDirtRating != calculatedDirtRating)
                {
                    if (NotifyWhenDirtRatingImproves != null)
                    {
                        NotifyWhenDirtRatingImproves(this, new DirtRatingImprovementEvent.HandlerArgs
                                                               {
                                                                   AverageDirtRating = calculatedDirtRating,
                                                                   AveragePercentageClean = currentAveragePercentClean
                                                               });
                    }
                }
                minutesElapsed++;
                currentAverageDirtRating = calculatedDirtRating;
            }

            if (NotifyWhenItemsAreTotallyClean != null)
            {
                NotifyWhenItemsAreTotallyClean(this, new ItemsAreTotallyCleanEvent.HandlerArgs
                                                         {
                                                             TotalMinutesElapsed = minutesElapsed
                                                         });
            }
        }
    }
}