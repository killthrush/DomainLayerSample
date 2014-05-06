using System;
using System.Linq;
using Domain.Base;
using Domain.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests
{
    [TestClass]
    public class IceCreamTests
    {
        [TestMethod]
        public void Ensure_that_cooking_ice_cream_causes_it_to_burn_away_into_limbo()
        {
            Avatar avatar = new Avatar();
            IceCream iceCream = new IceCream();
            avatar.PickUp(iceCream);
            Assert.AreSame(avatar, iceCream.ParentContainerObject);
            Assert.IsTrue(avatar.Contents.Any(x => x.ObjectId == iceCream.ObjectId));
            bool exceptionHandled = false;
            try
            {
                iceCream.Cook();
            }
            catch (Exception e)
            {
                exceptionHandled = true;
                Assert.IsInstanceOfType(e, typeof(InappropriateBehaviorException));
            }
            Assert.IsTrue(exceptionHandled);
            Assert.IsNull(iceCream.ParentContainerObject);
            Assert.IsFalse(avatar.Contents.Any(x => x.ObjectId == iceCream.ObjectId));            
        }

        [TestMethod]
        public void Ensure_that_properly_eating_ice_cream_causes_it_to_disappear_into_limbo()
        {
            Avatar avatar = new Avatar();
            IceCream iceCream = new IceCream();
            avatar.PickUp(iceCream);
            Assert.AreSame(avatar, iceCream.ParentContainerObject);
            Assert.IsTrue(avatar.Contents.Any(x => x.ObjectId == iceCream.ObjectId));

            Spoon spoon = new Spoon();
            avatar.PickUp(spoon);
            avatar.Eat(iceCream).With(spoon);
            Assert.IsNull(iceCream.ParentContainerObject);
            Assert.IsFalse(avatar.Contents.Any(x => x.ObjectId == iceCream.ObjectId));
        }

        [TestMethod]
        public void Ensure_that_you_can_eat_ice_cream_with_a_spoon_and_doing_so_makes_it_dirty()
        {
            Avatar avatar = new Avatar();
            IceCream iceCream = new IceCream();
            avatar.PickUp(iceCream);
            Spoon spoon = new Spoon();
            avatar.PickUp(spoon);
            avatar.Eat(iceCream).With(spoon);
            Assert.AreEqual(DirtRating.Smudged, spoon.DirtRating);
            Assert.AreEqual(80m, spoon.PercentClean);
        }

        [TestMethod]
        [ExpectedException(typeof(InappropriateBehaviorException))]
        public void Ensure_that_you_cannot_eat_ice_cream_with_a_knife()
        {
            Avatar avatar = new Avatar();
            IceCream iceCream = new IceCream();
            Knife knife = new Knife();
            avatar.PickUp(knife);
            avatar.Eat(iceCream).With(knife);
        }

        [TestMethod]
        [ExpectedException(typeof(InappropriateBehaviorException))]
        public void Ensure_that_you_cannot_eat_ice_cream_with_a_fork()
        {
            Avatar avatar = new Avatar();
            IceCream iceCream = new IceCream();
            Fork fork = new Fork();
            avatar.PickUp(fork);
            avatar.Eat(iceCream).With(fork);
        }
    }
}
