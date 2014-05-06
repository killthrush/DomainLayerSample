using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests
{
    [TestClass]
    public class HouseTests
    {
        [TestMethod]
        public void Ensure_that_a_house_created_out_of_thin_air_does_not_have_a_yard()
        {
            Assert.IsNull(new House().Yard);
        }

        [TestMethod]
        public void A_house_gets_one_dishwasher_one_fridge_and_one_cabinet()
        {
            House house = new House();
            Assert.IsNotNull(house.Dishwasher);
            Assert.IsNotNull(house.KitchenCabinet);
            Assert.IsNotNull(house.Refrigerator);
        }
    }
}
