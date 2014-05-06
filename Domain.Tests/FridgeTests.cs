using System.Linq;
using Domain.Base;
using Domain.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests
{
    [TestClass]
    public class FridgeTests
    {
        [TestMethod]
        public void Ensure_that_every_new_fridge_comes_fully_stocked()
        {
            Fridge fridge = new Fridge();
            Assert.AreEqual(5, fridge.BaconSlabs.Count());
            Assert.AreEqual(3, fridge.IceCreamTubs.Count());
            Assert.AreEqual(500, fridge.BeerRemaining);
        }

        [TestMethod]
        public void Ensure_that_the_beer_tap_dispenses_beer_fills_containers_and_makes_containers_dirtier()
        {
            Avatar avatar = new Avatar();
            Glass glass = new Glass();
            avatar.PickUp(glass);
            FineChinaTeacup teacup = new FineChinaTeacup();
            avatar.PickUp(teacup);

            Fridge fridge = new Fridge();
            avatar.DispenseBeerFrom(fridge).Into(glass);
            avatar.DispenseBeerFrom(fridge).Into(teacup);

            Assert.IsTrue(glass.IsFull);
            Assert.AreEqual(80m, glass.PercentClean);
            Assert.AreEqual(DirtRating.Smudged, glass.DirtRating);
            Assert.IsTrue(teacup.IsFull);
            Assert.AreEqual(80m, teacup.PercentClean);
            Assert.AreEqual(DirtRating.Smudged, teacup.DirtRating);
            Assert.AreEqual(425, fridge.BeerRemaining);
        }

        [TestMethod]
        [ExpectedException(typeof(BeverageException))]
        public void Ensure_that_you_cannot_fill_a_bag_of_holding_with_beer()
        {
            Avatar avatar = new Avatar();
            BagOfHolding bag = new BagOfHolding();
            avatar.PickUp(bag);

            Fridge fridge = new Fridge();
            avatar.DispenseBeerFrom(fridge).Into(bag);
        }

        [TestMethod]
        [ExpectedException(typeof(BeverageException))]
        public void Ensure_that_you_cannot_fill_a_frying_pan_with_beer()
        {
            Avatar avatar = new Avatar();
            FryingPan pan = new FryingPan();
            avatar.PickUp(pan);

            Fridge fridge = new Fridge();
            avatar.DispenseBeerFrom(fridge).Into(pan);
        }

        [TestMethod]
        [ExpectedException(typeof(BeverageException))]
        public void Ensure_that_you_cannot_fill_a_plate_with_beer()
        {
            Avatar avatar = new Avatar();
            Plate plate = new Plate();
            avatar.PickUp(plate);

            Fridge fridge = new Fridge();
            avatar.DispenseBeerFrom(fridge).Into(plate);
        }

        [TestMethod]
        [ExpectedException(typeof(BeverageException))]
        public void Ensure_that_the_beer_tap_does_not_dispense_beer_if_there_is_none_left()
        {
            Avatar avatar = new Avatar();
            Glass glass = new Glass();
            avatar.PickUp(glass);

            Fridge fridge = new Fridge();
            fridge.BeerRemaining = 0;
            avatar.DispenseBeerFrom(fridge).Into(glass);
        }

        [TestMethod]
        [ExpectedException(typeof(LawsOfPhysicsViolationException))]
        public void Ensure_that_you_cannot_dispense_a_beverage_into_a_container_not_being_held()
        {
            Avatar avatar = new Avatar();
            Fridge fridge = new Fridge();
            avatar.DispenseBeerFrom(fridge).Into(new Glass());
        }

        [TestMethod]
        [ExpectedException(typeof(BeverageException))]
        public void Ensure_that_you_cannot_dispense_a_beverage_into_a_container_that_is_full()
        {
            Avatar avatar = new Avatar();
            Glass glass = new Glass();
            avatar.PickUp(glass);

            Fridge fridge = new Fridge();
            avatar.DispenseBeerFrom(fridge).Into(glass);
            avatar.DispenseBeerFrom(fridge).Into(glass);
        }

        [TestMethod]
        public void Ensure_that_if_there_is_only_a_little_bit_of_beer_left_the_container_will_not_be_totally_full()
        {
            Avatar avatar = new Avatar();
            Glass glass = new Glass();
            avatar.PickUp(glass);

            Fridge fridge = new Fridge();
            fridge.BeerRemaining = 2;
            avatar.DispenseBeerFrom(fridge).Into(glass);

            Assert.IsFalse(glass.IsEmpty);
            Assert.IsFalse(glass.IsFull);
            Assert.AreEqual(48, glass.RemainingCapacity);
            Assert.AreEqual(0, fridge.BeerRemaining);
        }

        [TestMethod]
        public void Ensure_that_you_can_always_fill_a_partially_full_container()
        {
            Avatar avatar = new Avatar();
            Glass glass = new Glass();
            avatar.PickUp(glass);

            Fridge fridge1 = new Fridge();
            fridge1.BeerRemaining = 2;
            avatar.DispenseBeerFrom(fridge1).Into(glass);
            Assert.AreEqual(0, fridge1.BeerRemaining);

            Fridge fridge2 = new Fridge();
            avatar.DispenseBeerFrom(fridge2).Into(glass);
            Assert.AreEqual(452, fridge2.BeerRemaining);
            Assert.IsFalse(glass.IsEmpty);
            Assert.IsTrue(glass.IsFull);
        }
    }
}