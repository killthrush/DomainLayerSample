using Domain.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests
{
    [TestClass]
    public class DishwasherTests
    {
        [TestMethod]
        public void Contents_of_a_new_dishwasher_are_always_clean()
        {
            Dishwasher washer = new Dishwasher();
            Assert.IsTrue(washer.ContentsAreClean());
        }

        [TestMethod]
        public void New_dishwasher_is_always_empty()
        {
            Dishwasher washer = new Dishwasher();
            Assert.IsTrue(washer.IsEmpty);
        }

        [TestMethod]
        public void New_dishwasher_is_always_unlocked()
        {
            Dishwasher washer = new Dishwasher();
            Assert.IsFalse(washer.IsLocked);
        }

        [TestMethod]
        public void Contents_of_an_emptied_dishwasher_are_always_clean()
        {
            var fork = new Fork();
            var spoon = new Spoon();
            var glass = new Glass();

            Avatar avatar = new Avatar();
            avatar.PickUp(fork);
            avatar.PickUp(spoon);
            avatar.PickUp(glass);

            Dishwasher washer = new Dishwasher();
            washer.Load(fork);
            washer.Load(spoon);
            washer.Load(glass);
            washer.TakeEverythingOut();
            Assert.IsTrue(washer.ContentsAreClean());
        }

        [TestMethod]
        public void Dishwasher_reports_clean_if_only_clean_items_are_added()
        {
            Dishwasher washer = new Dishwasher();
            washer.Load(new Fork());
            washer.Load(new Spoon());
            Assert.IsTrue(washer.ContentsAreClean());
        }

        [TestMethod]
        [ExpectedException(typeof (LawsOfPhysicsViolationException))]
        public void Cannot_eat_with_an_item_while_it_is_in_the_dishwasher()
        {
            Dishwasher washer = new Dishwasher();
            Spoon spoon = new Spoon();
            washer.Load(spoon);
            Avatar avatar = new Avatar();
            avatar.Eat(new IceCream()).With(spoon);
        }

        [TestMethod]
        [ExpectedException(typeof (LockedException))]
        public void Cannot_pick_up_an_item_while_it_is_locked_in_the_dishwasher()
        {
            Dishwasher washer = new Dishwasher();
            Spoon spoon = new Spoon();
            washer.Load(spoon);
            washer.Lock();
            Avatar avatar = new Avatar();
            avatar.PickUp(spoon);
        }

        [TestMethod]
        [ExpectedException(typeof (InappropriateBehaviorException))]
        public void Cannot_lock_the_dishwasher_if_it_is_already_locked()
        {
            Dishwasher washer = new Dishwasher();
            washer.Lock();
            washer.Lock();
        }

        [TestMethod]
        [ExpectedException(typeof (InappropriateBehaviorException))]
        public void Cannot_unlock_the_dishwasher_if_it_is_already_unlocked()
        {
            Dishwasher washer = new Dishwasher();
            washer.Unlock();
        }

        [TestMethod]
        [ExpectedException(typeof (DishwasherException))]
        public void Ensure_that_we_cannot_add_an_item_to_the_dishwasher_that_is_too_big_to_fit()
        {
            Dishwasher washer = new Dishwasher();
            washer.Load(new Elephant());
        }

        [TestMethod]
        [ExpectedException(typeof(DishwasherException))]
        public void Ensure_that_you_cannot_load_objects_that_are_not_safe_into_the_dishwasher()
        {
            Dishwasher washer = new Dishwasher();
            Dog dog = new Dog();
            washer.Load(dog);
        }

        [TestMethod]
        [ExpectedException(typeof(DishwasherException))]
        public void Ensure_that_you_cannot_load_containers_that_are_not_safe_into_the_dishwasher()
        {
            Dishwasher washer = new Dishwasher();
            FineChinaTeacup teacup = new FineChinaTeacup();
            washer.Load(teacup);
        }

        [TestMethod]
        [ExpectedException(typeof(DishwasherException))]
        public void Ensure_that_containers_loaded_into_the_dishwasher_are_empty_first()
        {
            Avatar avatar = new Avatar();
            BaconSlab bacon = new BaconSlab();
            avatar.PickUp(bacon);
            Dishwasher washer = new Dishwasher();
            Plate plate = new Plate();
            avatar.Put(bacon).In(plate);
            washer.Load(plate);
        }
    }
}