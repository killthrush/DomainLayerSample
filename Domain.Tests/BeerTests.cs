using Domain.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests
{
    [TestClass]
    public class BeerTests
    {
        [TestMethod]
        public void Ensure_that_beer_can_be_created_and_calories_are_proportional_to_volume()
        {
            Beer beer = new Beer(10);
            Assert.IsNotNull(beer);
            Assert.AreEqual(10, beer.Size);
            Assert.AreEqual(500, beer.Calories);
        }

        [TestMethod]
        [ExpectedException(typeof(BeverageException))]
        public void Ensure_that_beer_amount_cannot_be_zero()
        {
            new Beer(0);
        }

        [TestMethod]
        [ExpectedException(typeof(BeverageException))]
        public void Ensure_that_beer_amount_cannot_be_negative()
        {
            new Beer(-1);
        }
    }
}
