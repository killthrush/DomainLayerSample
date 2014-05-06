using Domain.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests
{
    [TestClass]
    public class ColorTests
    {
        [TestMethod]
        public void Ensure_that_the_parse_method_will_not_accept_invalid_values()
        {
            Color color;

            Assert.IsFalse(Color.TryParse("ABCDEG", out color));
            Assert.IsNull(color);

            Assert.IsFalse(Color.TryParse(null, out color));
            Assert.IsNull(color);

            Assert.IsFalse(Color.TryParse("ABCEF", out color));
            Assert.IsNull(color);

            Assert.IsFalse(Color.TryParse("-12345", out color));
            Assert.IsNull(color);

            Assert.IsFalse(Color.TryParse(string.Empty, out color));
            Assert.IsNull(color);

            Assert.IsFalse(Color.TryParse("12345", out color));
            Assert.IsNull(color);

            Assert.IsFalse(Color.TryParse("!@#$%", out color));
            Assert.IsNull(color);
        }

        [TestMethod]
        public void Assert_that_you_can_create_color_using_valid_inputs()
        {
            Color color1 = new Color(0, 0, 0);
            Color color2 = new Color(1, 2, 3);
            Color color3 = new Color(255, 255, 255);
            Assert.AreEqual("000000", color1.ColorAsRgbString);
            Assert.AreEqual("010203", color2.ColorAsRgbString);
            Assert.AreEqual("FFFFFF", color3.ColorAsRgbString);

            Color.TryParse("000000", out color1);
            Assert.AreEqual(new Color(0, 0, 0), color1);

            Color.TryParse("010203", out color2);
            Assert.AreEqual(new Color(1, 2, 3), color2);

            Color.TryParse("FFFFFF", out color3);
            Assert.AreEqual(new Color(255, 255, 255), color3);
        }

        [TestMethod]
        public void Ensure_that_equality_operator_works()
        {
            var color1 = new Color(0, 0, 0);
            var color2 = new Color(0, 0, 0);
            Assert.IsTrue(color1 == color2);
        }

        [TestMethod]
        public void Ensure_that_inequality_operator_works()
        {
            var color1 = new Color(0, 0, 0);
            var color2 = new Color(0, 1, 0);
            Assert.IsTrue(color1 != color2);
        }

        [TestMethod]
        public void Ensure_that_equals_returns_false_when_compared_with_null()
        {
            var color = new Color(0, 0, 0);
            Assert.IsFalse(color.Equals(null));
            Assert.IsFalse(color.Equals((object)null));
        }

        [TestMethod]
        public void Ensure_that_equals_returns_false_when_compared_with_a_different_type_of_object()
        {
            var color = new Color(0, 0, 0);
            Assert.IsFalse(color.Equals(""));
        }

        [TestMethod]
        public void Ensure_that_equals_returns_true_for_identity()
        {
            var color = new Color(0, 0, 0);
            Assert.IsTrue(color.Equals(color));
            Assert.IsTrue(color.Equals((object)color));
        }

        [TestMethod]
        public void Ensure_that_hash_code_can_be_generated()
        {
            var color = new Color(0, 1, 0);
            Assert.AreEqual(1, color.GetHashCode());
        }
    }
}
