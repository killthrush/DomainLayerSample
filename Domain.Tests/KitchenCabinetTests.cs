using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests
{
    [TestClass]
    public class KitchenCabinetTests
    {
        [TestMethod]
        public void Ensure_that_every_new_cabinet_comes_fully_stocked()
        {
            KitchenCabinet cabinet = new KitchenCabinet();
            Assert.AreEqual(8, cabinet.Spoons.Count());
            Assert.AreEqual(12, cabinet.Forks.Count());
            Assert.AreEqual(12, cabinet.Knives.Count());
            Assert.AreEqual(6, cabinet.Glasses.Count());
            Assert.AreEqual(10, cabinet.Plates.Count());
            Assert.AreEqual(2, cabinet.Pans.Count());
            Assert.IsNotNull(cabinet.SphereFlake);
            Assert.IsNotNull(cabinet.MagicBag);
        }
    }
}
