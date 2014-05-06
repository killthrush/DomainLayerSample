using System;
using System.Linq;
using Domain.Base;
using Domain.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests
{
    [TestClass]
    public class DogTests
    {
        private Avatar _testAvatar;
        private WideWorld _testWorld;
        private Yard _testYard;
        private House _testHouse;
        private Dog _testDog;

        private readonly Tuple<decimal, decimal, DirtRating>[] _testDoggyDirtData = new[]
                                                                                       {
                                                                                           new Tuple<decimal, decimal, DirtRating>(0, 19, DirtRating.UtterlyFilthy),
                                                                                           new Tuple<decimal, decimal, DirtRating>(19, 39, DirtRating.PrettyDirty),
                                                                                           new Tuple<decimal, decimal, DirtRating>(39, 79, DirtRating.NominallyBesmirched),
                                                                                           new Tuple<decimal, decimal, DirtRating>(79, 89, DirtRating.Smudged),
                                                                                           new Tuple<decimal, decimal, DirtRating>(89, 99, DirtRating.SortaCleanButSmellsFunny),
                                                                                           new Tuple<decimal, decimal, DirtRating>(99, 100, DirtRating.SqueakyClean)
                                                                                       };

        [TestInitialize]
        public void SetUp()
        {
            _testAvatar = new Avatar();
            _testWorld = new WideWorld();
            _testYard = _testWorld.DrawResidentialPlot();
            _testHouse = _testYard.BuildHouse();
            _testDog = _testWorld.FindRandomDog();
        }

        [TestMethod]
        [ExpectedException(typeof (InappropriateBehaviorException))]
        public void Ensure_that_a_dog_cannot_dig_a_hole_if_it_is_not_outside()
        {
            _testDog.WanderInto(_testHouse);
            _testDog.DigHole();
        }

        [TestMethod]
        [ExpectedException(typeof (InappropriateBehaviorException))]
        public void Ensure_that_a_dog_cannot_roll_in_mud_if_it_is_not_outside()
        {
            _testAvatar.PickUp(_testDog);
            _testDog.RollInMud();
        }

        [TestMethod]
        [ExpectedException(typeof (StuckException))]
        public void Ensure_that_a_dog_cannot_wander_while_it_is_held_in_the_hands()
        {
            _testAvatar.PickUp(_testDog);
            _testDog.WanderInto(new Yard());
        }

        [TestMethod]
        [ExpectedException(typeof (LawsOfPhysicsViolationException))]
        public void Ensure_that_a_dog_cannot_wander_if_it_is_floating_in_limbo()
        {
            Dog dog = new Dog();
            dog.WanderInto(new Yard());
        }

        [TestMethod]
        [ExpectedException(typeof (StuckException))]
        public void Ensure_that_a_dog_cannot_go_outside_while_it_is_held_in_the_hands()
        {
            _testAvatar.PickUp(_testDog);
            _testDog.WanderInto(_testYard);
        }

        [TestMethod]
        [ExpectedException(typeof (LawsOfPhysicsViolationException))]
        public void Ensure_that_a_dog_cannot_go_outside_if_it_is_already_there()
        {
            _testDog.WanderInto(_testYard);
            _testDog.WanderInto(_testYard);
        }

        [TestMethod]
        [ExpectedException(typeof (LawsOfPhysicsViolationException))]
        public void Ensure_that_a_dog_cannot_go_outside_if_it_is_floating_in_limbo()
        {
            Dog dog = new Dog();
            dog.WanderInto(_testYard);
        }

        [TestMethod]
        [ExpectedException(typeof (StuckException))]
        public void Ensure_that_a_dog_cannot_go_inside_while_it_is_held_in_the_hands()
        {
            _testDog.WanderInto(_testYard);
            _testAvatar.PickUp(_testDog);
            _testDog.WanderInto(_testHouse);
        }

        [TestMethod]
        [ExpectedException(typeof (LawsOfPhysicsViolationException))]
        public void Ensure_that_a_dog_cannot_go_inside_if_it_is_already_there()
        {
            _testDog.WanderInto(_testYard);
            _testDog.WanderInto(_testHouse);
            _testDog.WanderInto(_testHouse);
        }

        [TestMethod]
        [ExpectedException(typeof (LawsOfPhysicsViolationException))]
        public void Ensure_that_a_dog_cannot_go_inside_if_it_is_floating_in_limbo()
        {
            Dog dog = new Dog();
            dog.WanderInto(_testHouse);
        }

        [TestMethod]
        public void Ensure_that_digging_one_hole_does_not_make_a_dog_completely_dirty()
        {
            _testDog.WanderInto(_testYard);
            _testDog.DigHole();
            Assert.AreEqual(DirtRating.PrettyDirty, _testDog.DirtRating);
            Assert.AreEqual(25m, _testDog.PercentClean);
        }

        [TestMethod]
        public void Ensure_that_digging_multiple_holes_gets_properly_tallied_dirt_maxes_out_at_100_and_contributes_to_stench()
        {
            Assert.AreEqual(0, _testDog.HolesDug);
            Assert.AreEqual(0, _testDog.TimesRolledInMud);

            _testDog.WanderInto(_testYard);
            _testDog.DigHole();
            _testDog.DigHole();
            _testDog.DigHole();
            _testDog.DigHole();

            Assert.AreEqual(4, _testDog.HolesDug);
            Assert.AreEqual(0, _testDog.TimesRolledInMud);
            Assert.AreEqual(DirtRating.UtterlyFilthy, _testDog.DirtRating);
            Assert.AreEqual(0m, _testDog.PercentClean);
            Assert.IsTrue(_testDog.StenchFactor > 300 && _testDog.StenchFactor < 350);
        }

        [TestMethod]
        public void Ensure_that_rolling_in_mud_once_makes_a_dog_completely_dirty()
        {
            _testDog.WanderInto(_testYard);
            _testDog.RollInMud();
            Assert.AreEqual(DirtRating.UtterlyFilthy, _testDog.DirtRating);
            Assert.AreEqual(0m, _testDog.PercentClean);
        }

        [TestMethod]
        public void Ensure_that_rolling_in_mud_multiple_times_gets_properly_tallied_dirt_maxes_out_at_100_and_contributes_to_stench()
        {
            Assert.AreEqual(0, _testDog.HolesDug);
            Assert.AreEqual(0, _testDog.TimesRolledInMud);

            _testDog.WanderInto(_testYard);
            _testDog.RollInMud();
            _testDog.RollInMud();
            _testDog.RollInMud();

            Assert.AreEqual(0, _testDog.HolesDug);
            Assert.AreEqual(3, _testDog.TimesRolledInMud);
            Assert.AreEqual(DirtRating.UtterlyFilthy, _testDog.DirtRating);
            Assert.AreEqual(0m, _testDog.PercentClean);
            Assert.IsTrue(_testDog.StenchFactor > 300 && _testDog.StenchFactor < 350);
        }

        [TestMethod]
        [ExpectedException(typeof (InappropriateBehaviorException))]
        public void Ensure_that_the_dog_cannot_dig_holes_if_pulled_back_inside_the_house()
        {
            _testDog.WanderInto(_testYard);
            House house = new House();
            _testAvatar.PickUp(_testDog);
            _testAvatar.Put(_testDog).In(house);
            _testDog.DigHole();
        }

        [TestMethod]
        [ExpectedException(typeof (InappropriateBehaviorException))]
        public void Ensure_that_the_dog_cannot_roll_in_mud_if_pulled_back_inside_the_house()
        {
            _testDog.WanderInto(_testYard);
            House house = new House();
            _testAvatar.PickUp(_testDog);
            _testAvatar.Put(_testDog).In(house);
            _testDog.DigHole();
        }

        [TestMethod]
        public void Ensure_that_the_dog_can_go_back_in_the_house_on_its_own()
        {
            House house = new House();
            _testDog.WanderInto(_testYard);
            Assert.IsFalse(house.Contents.Any(x => x.ObjectId == _testDog.ObjectId));
            Assert.IsTrue(_testYard.Contents.Any(x => x.ObjectId == _testDog.ObjectId));
            _testDog.WanderInto(house);
            Assert.IsTrue(house.Contents.Any(x => x.ObjectId == _testDog.ObjectId));
            Assert.IsFalse(_testYard.Contents.Any(x => x.ObjectId == _testDog.ObjectId));
        }

        [TestMethod]
        public void Ensure_that_washing_a_dog_by_hand_gradually_cleans_it()
        {
            _testDog.WanderInto(_testYard);
            _testDog.RollInMud();

            // Set up event handlers for testing
            DirtRating? lastDirtRating = _testDog.DirtRating;
            bool ratingImprovementCalled = false;
            bool itemsCleanCalled = false;

            _testAvatar.NotifyWhenDirtRatingImproves += (sender, args) =>
                                                            {
                                                                Avatar callingObject = (Avatar)sender;

                                                                Tuple<decimal, decimal, DirtRating> expectedDirtData = _testDoggyDirtData.First(x => x.Item1 <= args.AveragePercentageClean && x.Item2 >= args.AveragePercentageClean);
                                                                decimal expectedPercentCleanLow = expectedDirtData.Item1;
                                                                decimal expectedPercentCleanHigh = expectedDirtData.Item2;
                                                                DirtRating expectedDirtRating = expectedDirtData.Item3;

                                                                Assert.AreEqual(expectedDirtRating, args.AverageDirtRating);
                                                                Assert.AreNotEqual(lastDirtRating, args.AverageDirtRating);
                                                                Assert.IsTrue(callingObject.Contents.Cast<IWashableObject>().All(x => x.PercentClean >= expectedPercentCleanLow && x.PercentClean <= expectedPercentCleanHigh));
                                                                Assert.IsTrue(callingObject.Contents.Cast<IWashableObject>().All(x => x.DirtRating == args.AverageDirtRating));

                                                                lastDirtRating = args.AverageDirtRating;
                                                                ratingImprovementCalled = true;
                                                            };

            _testAvatar.NotifyWhenItemsAreTotallyClean += (sender, args) =>
                                                              {
                                                                  Avatar callingObject = (Avatar)sender;

                                                                  Assert.AreEqual(_testDog.MinutesRequiredToClean, args.TotalMinutesElapsed);
                                                                  Assert.IsTrue(callingObject.Contents.Cast<IWashableObject>().All(x => x.DirtRating == DirtRating.SqueakyClean));
                                                                  Assert.IsTrue(callingObject.Contents.Cast<IWashableObject>().All(x => x.PercentClean == 100m));
                                                                  itemsCleanCalled = true;
                                                              };


            _testAvatar.PickUp(_testDog);
            _testAvatar.StartWashing();

            Assert.IsTrue(ratingImprovementCalled);
            Assert.IsTrue(itemsCleanCalled);
        }

        [TestMethod]
        public void Ensure_that_you_can_give_the_dog_names_and_that_named_dogs_are_not_wild()
        {
            Dog dog = new Dog();
            Assert.IsTrue(dog.IsWild);
            dog.GiveName("Speak");
            Assert.AreEqual("Speak", dog.Name);
            Assert.IsFalse(dog.IsWild);
            dog.GiveName("Arthur");
            Assert.AreEqual("Arthur", dog.Name);
            Assert.IsFalse(dog.IsWild);
        }

        [TestMethod]
        [ExpectedException(typeof(NameException))]
        public void Ensure_that_you_cannot_assign_a_null_name()
        {
            Dog dog = new Dog();
            dog.GiveName(null);
        }

        [TestMethod]
        [ExpectedException(typeof(NameException))]
        public void Ensure_that_you_cannot_assign_an_invalid_name()
        {
            string nameThatIsJustABitTooLong = string.Join("", Enumerable.Repeat("a", 101).ToArray());
            Dog dog = new Dog();
            dog.GiveName(nameThatIsJustABitTooLong);
        }
    }
}