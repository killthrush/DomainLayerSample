using System.Linq;
using Domain.Base;
using Domain.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        [ExpectedException(typeof(BuildingCodeException))]
        public void Ensure_that_you_cannot_create_an_address_without_a_street()
        {
            new Address(null, "unit", "city", "AL", "01234");
        }

        [TestMethod]
        [ExpectedException(typeof(BuildingCodeException))]
        public void Ensure_that_you_cannot_create_an_address_without_a_city()
        {
            new Address("street", "unit", null, "AL", "01234");
        }

        [TestMethod]
        [ExpectedException(typeof(BuildingCodeException))]
        public void Ensure_that_you_cannot_create_an_address_without_a_state()
        {
            new Address("street", "unit", "city", null, "01234");
        }

        [TestMethod]
        [ExpectedException(typeof(BuildingCodeException))]
        public void Ensure_that_you_cannot_create_an_address_without_a_zip()
        {
            new Address("street", "unit", "city", "AL", null);
        }

        [TestMethod]
        public void Ensure_that_you_can_create_an_address_with_valid_inputs()
        {
            var address = new Address("street", "unit", "city", "AL", "01234");
            Assert.IsNotNull(address);
            Assert.AreEqual("street", address.Street);
            Assert.AreEqual("unit", address.Unit);
            Assert.AreEqual("city", address.City);
            Assert.AreEqual("AL", address.State);
            Assert.AreEqual("01234", address.Zip);
        }

        [TestMethod]
        public void Ensure_that_you_can_create_an_address_without_a_unit()
        {
            var address = new Address("street", null, "city", "AL", "01234");
            Assert.IsNotNull(address);
            Assert.AreEqual("street", address.Street);
            Assert.IsNull(address.Unit);
            Assert.AreEqual("city", address.City);
            Assert.AreEqual("AL", address.State);
            Assert.AreEqual("01234", address.Zip);
        }

        [TestMethod]
        [ExpectedException(typeof(BuildingCodeException))]
        public void Ensure_that_you_cannot_create_an_address_with_a_street_name_that_is_too_long()
        {
            string streetNameThatIsJustABitTooLong = string.Join("", Enumerable.Repeat("a", 101).ToArray());
            new Address(streetNameThatIsJustABitTooLong, "unit", "city", "AL", "01234");
        }

        [TestMethod]
        [ExpectedException(typeof(BuildingCodeException))]
        public void Ensure_that_you_cannot_create_an_address_with_a_unit_field_that_is_too_long()
        {
            new Address("street", "aaaaaa", "city", "AL", "01234");
        }

        [TestMethod]
        [ExpectedException(typeof(BuildingCodeException))]
        public void Ensure_that_you_cannot_create_an_address_with_a_city_name_that_is_too_long()
        {
            string cityNameThatIsJustABitTooLong = string.Join("", Enumerable.Repeat("a", 51).ToArray());
            new Address("street", "unit", cityNameThatIsJustABitTooLong, "AL", "01234");
        }

        [TestMethod]
        [ExpectedException(typeof(BuildingCodeException))]
        public void Ensure_that_you_cannot_create_an_address_with_a_state_that_is_not_valid()
        {
            new Address("street", "unit", "city", "a", "01234");
        }

        [TestMethod]
        public void Ensure_that_state_code_is_not_case_sensitive()
        {
            var address = new Address("street", "unit", "city", "nV", "01234");
            Assert.IsNotNull(address);
            Assert.AreEqual("street", address.Street);
            Assert.AreEqual("unit", address.Unit);
            Assert.AreEqual("city", address.City);
            Assert.AreEqual("NV", address.State);
            Assert.AreEqual("01234", address.Zip);
        }

        [TestMethod]
        [ExpectedException(typeof(BuildingCodeException))]
        public void Ensure_that_you_cannot_create_an_address_with_an_alphanumeric_zip_code()
        {
            new Address("street", "unit", "city", "vt", "01A34");
        }

        [TestMethod]
        [ExpectedException(typeof(BuildingCodeException))]
        public void Ensure_that_you_cannot_create_an_address_with_a_zip_code_that_is_too_long()
        {
            new Address("street", "unit", "city", "vt", "012345");
        }

        [TestMethod]
        [ExpectedException(typeof(BuildingCodeException))]
        public void Ensure_that_you_cannot_create_an_address_with_a_zip_code_that_is_too_short()
        {
            new Address("street", "unit", "city", "vt", "1234");
        }

        [TestMethod]
        public void Ensure_that_equality_operator_works()
        {
            var address1 = new Address("street", "unit", "city", "NV", "01234");
            var address2 = new Address("street", "unit", "city", "nV", "01234");
            Assert.IsTrue(address1 == address2);
        }

        [TestMethod]
        public void Ensure_that_inequality_operator_works()
        {
            var address1 = new Address("street", "unit", "city", "NV", "01234");
            var address2 = new Address("street", "unit", "city", "nV", "01134");
            Assert.IsTrue(address1 != address2);
        }

        [TestMethod]
        public void Ensure_that_equals_returns_false_when_compared_with_null()
        {
            var address = new Address("street", "unit", "city", "nV", "01134");
            Assert.IsFalse(address.Equals(null));
            Assert.IsFalse(address.Equals((object)null));
        }

        [TestMethod]
        public void Ensure_that_equals_returns_false_when_compared_with_a_different_type_of_object()
        {
            var address = new Address("street", "unit", "city", "nV", "01134");
            Assert.IsFalse(address.Equals(""));
        }

        [TestMethod]
        public void Ensure_that_equals_returns_true_for_identity()
        {
            var address = new Address("street", "unit", "city", "nV", "01134");
            Assert.IsTrue(address.Equals(address));
            Assert.IsTrue(address.Equals((object)address));
        }

        [TestMethod]
        public void Ensure_that_hash_code_can_be_generated()
        {
            var address = new Address("street", "unit", "city", "nV", "01134");
            Assert.AreEqual(-2039642170, address.GetHashCode());
        }
    }
}
