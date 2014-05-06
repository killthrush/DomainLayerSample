using System.Linq;
using Domain.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests
{
    [TestClass]
    public class AvatarTests
    {
        [TestMethod]
        [ExpectedException(typeof (CapacityException))]
        public void Ensure_that_you_cannot_pick_up_more_than_you_can_carry()
        {
            Avatar avatar = new Avatar();
            avatar.PickUp(new Elephant());
        }

        [TestMethod]
        [ExpectedException(typeof (LawsOfPhysicsViolationException))]
        public void Ensure_that_you_cannot_pick_up_an_item_more_than_once()
        {
            Avatar avatar = new Avatar();
            Fork fork = new Fork();
            avatar.PickUp(fork);
            avatar.PickUp(fork);
        }

        [TestMethod]
        [ExpectedException(typeof (InappropriateBehaviorException))]
        public void Ensure_that_you_cannot_wash_things_if_you_are_holding_non_washable_stuff()
        {
            Avatar avatar = new Avatar();
            BagOfHolding bag = new BagOfHolding();
            Fork fork = new Fork();
            avatar.PickUp(bag);
            avatar.PickUp(fork);
            avatar.StartWashing();
        }

        [TestMethod]
        public void Ensure_that_you_can_wash_items_without_specifying_wash_event_handlers()
        {
            Avatar avatar = new Avatar();
            Fork fork1 = new Fork();
            Fork fork2 = new Fork();
            avatar.PickUp(fork1);
            avatar.PickUp(fork2);
            avatar.StartWashing();
        }

        [TestMethod]
        public void Ensure_that_you_can_wash_multiple_items_at_once()
        {
            bool dirtRatingImprovedEventHandled = false;
            bool allItemsCleanEventHandled = false;

            Avatar avatar = new Avatar();
            avatar.NotifyWhenDirtRatingImproves += (sender, args) => { dirtRatingImprovedEventHandled = true; };
            avatar.NotifyWhenItemsAreTotallyClean += (sender, args) => { allItemsCleanEventHandled = true; };

            Fork fork1 = new Fork {PercentClean = 0};
            Fork fork2 = new Fork {PercentClean = 0};
            Fork fork3 = new Fork {PercentClean = 0};
            avatar.PickUp(fork1);
            avatar.PickUp(fork2);
            avatar.PickUp(fork3);
            avatar.StartWashing();

            Assert.IsTrue(dirtRatingImprovedEventHandled);
            Assert.IsTrue(allItemsCleanEventHandled);
        }

        [TestMethod]
        [ExpectedException(typeof (LawsOfPhysicsViolationException))]
        public void Ensure_that_moving_items_requires_you_to_pick_them_up_first()
        {
            Avatar avatar = new Avatar();
            BarOfSoap barOfSoap = new BarOfSoap();
            House house = new House();
            avatar.Put(barOfSoap).In(house);
        }

        [TestMethod]
        public void Ensure_that_moving_items_properly_transfers_them()
        {
            Avatar avatar = new Avatar();
            BarOfSoap barOfSoap = new BarOfSoap();
            avatar.PickUp(barOfSoap);
            House house = new House();
            avatar.Put(barOfSoap).In(house);
            Assert.AreSame(house, barOfSoap.ParentContainerObject);
            Assert.IsFalse(avatar.Contents.Any(x => x.ObjectId == barOfSoap.ObjectId));
            Assert.IsTrue(house.Contents.Any(x => x.ObjectId == barOfSoap.ObjectId));
        }

        [TestMethod]
        public void Ensure_that_you_can_give_yourself_a_name()
        {
            Avatar avatar = new Avatar("Joe Bob");
            Assert.AreEqual("Joe Bob", avatar.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(NameException))]
        public void Ensure_that_you_cannot_assign_a_null_name()
        {
            new Avatar(null);
        }

        [TestMethod]
        [ExpectedException(typeof(NameException))]
        public void Ensure_that_you_cannot_assign_an_invalid_name()
        {
            string nameThatIsJustABitTooLong = string.Join("", Enumerable.Repeat("a", 101).ToArray());
            new Avatar(nameThatIsJustABitTooLong);
        }
    }
}