using System;
using System.Linq;
using Domain.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests
{
    [TestClass]
    public class YardTests
    {
        [TestMethod]
        public void Ensure_that_you_can_build_a_house_in_the_yard()
        {
            Yard yard = new Yard();
            House house = yard.BuildHouse();
            Assert.IsNotNull(house);
            Assert.AreNotEqual(default(Guid), house.ObjectId);
            Assert.AreSame(house, yard.House);
            Assert.IsTrue(yard.Contents.Any(x => x.ObjectId == house.ObjectId));
            Assert.AreSame(yard, house.Yard);
            Assert.AreSame(yard, house.ParentContainerObject);
        }

        [TestMethod]
        [ExpectedException(typeof(BuildingCodeException))]
        public void Ensure_that_only_one_house_may_exist_in_the_yard()
        {
            Yard yard = new Yard();
            yard.BuildHouse();
            yard.BuildHouse();
        }
    }
}
