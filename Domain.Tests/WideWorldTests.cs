using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests
{
    [TestClass]
    public class WideWorldTests
    {
        [TestMethod]
        public void Ensure_that_we_can_create_any_number_of_yards_in_the_world()
        {
            WideWorld world = new WideWorld();
            Yard yard1 = world.DrawResidentialPlot();
            Yard yard2 = world.DrawResidentialPlot();
            Yard yard3 = world.DrawResidentialPlot();
            Assert.IsNotNull(yard1);
            Assert.IsNotNull(yard2);
            Assert.IsNotNull(yard3);
            Assert.AreNotSame(yard1, yard3);
            Assert.AreNotSame(yard1, yard2);
            Assert.AreNotSame(yard2, yard3);
            Assert.AreEqual(3, world.ResidentialPlots.Count());
            Assert.AreSame(yard1.ParentContainerObject, world);
            Assert.AreSame(yard2.ParentContainerObject, world);
            Assert.AreSame(yard3.ParentContainerObject, world);
        }

        [TestMethod]
        public void Ensure_that_the_world_keeps_track_of_yards()
        {
            WideWorld world = new WideWorld();
            Yard yard = world.DrawResidentialPlot();
            Assert.AreSame(yard, world.ResidentialPlots.First());
        }

        [TestMethod]
        public void Ensure_that_we_can_always_find_a_dog_out_there_somewhere()
        {
            WideWorld world = new WideWorld();
            Dog dog = world.FindRandomDog();
            Assert.IsNotNull(dog);
        }

        [TestMethod]
        public void Ensure_that_ten_wild_dogs_are_in_the_world_by_default()
        {
            WideWorld world = new WideWorld();
            Assert.AreEqual(10, world.WildDogs.Count());
            foreach (var dog in world.WildDogs)
            {
                Assert.AreSame(dog.ParentContainerObject, world);
            }
        }
    }
}
