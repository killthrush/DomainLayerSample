using System;
using System.Linq;
using Domain.Base;
using Domain.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests
{
    [TestClass]
    public class BaconSlabTests
    {
        [TestMethod]
        public void Ensure_that_cooking_bacon_more_than_once_causes_it_to_burn_away_into_limbo()
        {
            Avatar avatar = new Avatar();
            BaconSlab bacon = new BaconSlab();
            avatar.PickUp(bacon);
            Assert.AreSame(avatar, bacon.ParentContainerObject);
            Assert.IsTrue(avatar.Contents.Any(x => x.ObjectId == bacon.ObjectId));
            bool exceptionHandled = false;
            try
            {
                bacon.Cook();
                bacon.Cook();
            }
            catch (Exception e)
            {
                exceptionHandled = true;
                Assert.IsInstanceOfType(e, typeof(InappropriateBehaviorException));
            }
            Assert.IsTrue(exceptionHandled);
            Assert.IsNull(bacon.ParentContainerObject);
            Assert.IsFalse(avatar.Contents.Any(x => x.ObjectId == bacon.ObjectId));            
        }

        [TestMethod]
        public void Ensure_that_properly_eating_bacon_causes_it_to_disappear_into_limbo()
        {
            Avatar avatar = new Avatar();
            BaconSlab bacon = new BaconSlab();
            avatar.PickUp(bacon);
            Assert.AreSame(avatar, bacon.ParentContainerObject);
            Assert.IsTrue(avatar.Contents.Any(x => x.ObjectId == bacon.ObjectId));

            Fork fork = new Fork();
            Knife knife = new Knife();
            avatar.PickUp(fork);
            avatar.PickUp(knife);
            bacon.Cook();
            avatar.Eat(bacon).With(fork, knife);
            Assert.IsNull(bacon.ParentContainerObject);
            Assert.IsFalse(avatar.Contents.Any(x => x.ObjectId == bacon.ObjectId));
        }

        [TestMethod]
        public void Ensure_that_you_can_eat_bacon_with_a_knife_and_fork_and_doing_so_makes_them_dirty()
        {
            Avatar avatar = new Avatar();
            BaconSlab bacon = new BaconSlab();
            avatar.PickUp(bacon);
            Assert.AreSame(avatar, bacon.ParentContainerObject);
            Assert.IsTrue(avatar.Contents.Any(x => x.ObjectId == bacon.ObjectId));

            Fork fork = new Fork();
            Knife knife = new Knife();
            avatar.PickUp(fork);
            avatar.PickUp(knife);

            Assert.AreEqual(DirtRating.SqueakyClean, fork.DirtRating);
            Assert.AreEqual(100m, fork.PercentClean);
            Assert.AreEqual(DirtRating.SqueakyClean, knife.DirtRating);
            Assert.AreEqual(100m, knife.PercentClean);

            bacon.Cook();
            avatar.Eat(bacon).With(fork, knife);

            Assert.AreEqual(DirtRating.Smudged, fork.DirtRating);
            Assert.AreEqual(80m, fork.PercentClean);
            Assert.AreEqual(DirtRating.Smudged, knife.DirtRating);
            Assert.AreEqual(80m, knife.PercentClean);
        }

        [TestMethod]
        [ExpectedException(typeof(TrichinosisException))]
        public void Eating_raw_bacon_is_bad_for_you()
        {
            Avatar avatar = new Avatar();
            BaconSlab bacon = new BaconSlab();
            Fork fork = new Fork();
            Knife knife = new Knife();
            avatar.PickUp(fork);
            avatar.PickUp(knife);
            avatar.Eat(bacon).With(fork, knife);
        }

        [TestMethod]
        [ExpectedException(typeof(InappropriateBehaviorException))]
        public void Ensure_that_you_cannot_eat_bacon_with_a_spoon()
        {
            Avatar avatar = new Avatar();
            BaconSlab bacon = new BaconSlab();
            Spoon spoon = new Spoon();
            bacon.Cook();
            avatar.PickUp(spoon);
            avatar.Eat(bacon).With(spoon);
        }
    }
}
