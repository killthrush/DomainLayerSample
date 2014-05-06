using System;
using System.Globalization;

namespace Domain.Base
{
    /// <summary>
    /// A value object that can encode a color value using RGB (and possibly other values)
    /// </summary>
    public class Color : IEquatable<Color>
    {
        /// <summary>
        /// The red component value of the RGB color space (0-255)
        /// </summary>
        private readonly byte _redValue;

        /// <summary>
        /// The green component value of the RGB color space (0-255)
        /// </summary>
        private readonly byte _greenValue;

        /// <summary>
        /// The blue component value of the RGB color space (0-255)
        /// </summary>
        private readonly byte _blueValue;

        /// <summary>
        /// Returns the embedded color value as a 6-digit hex string
        /// </summary>
        public string ColorAsRgbString
        {
            get { return string.Format("{0}{1}{2}", _redValue.ToString("X2"), _greenValue.ToString("X2"), _blueValue.ToString("X2")); }
        }

        /// <summary>
        /// Initializes a new instance of the Color class.
        /// </summary>
        /// <param name="redValue">The red component value of the RGB color space (0-255)</param>
        /// <param name="greenValue">The green component value of the RGB color space (0-255)</param>
        /// <param name="blueValue">The blue component value of the RGB color space (0-255)</param>
        public Color(byte redValue, byte greenValue, byte blueValue)
        {
            _redValue = redValue;
            _greenValue = greenValue;
            _blueValue = blueValue;
        }

        /// <summary>
        /// Helper method to attempt to parse an RGB hex string into its component values
        /// </summary>
        /// <param name="input">The string input to parse</param>
        /// <param name="color">The parsed color instance or null if not successful</param>
        /// <returns>True if parsing was successful, else false</returns>
        public static bool TryParse(string input, out Color color)
        {
            if (input == null || input.Length != 6)
            {
                color = null;
                return false;
            }

            string redString = input.Substring(0, 2);
            string greenString = input.Substring(2, 2);
            string blueString = input.Substring(4, 2);

            byte redComponent;
            bool parsedRed = byte.TryParse(redString, NumberStyles.AllowHexSpecifier, null, out redComponent);

            byte greenComponent;
            bool parsedGreen = byte.TryParse(greenString, NumberStyles.AllowHexSpecifier, null, out greenComponent);

            byte blueComponent;
            bool parsedBlue = byte.TryParse(blueString, NumberStyles.AllowHexSpecifier, null, out blueComponent);

            if (!parsedRed || !parsedGreen || !parsedBlue)
            {
                color = null;
                return false;
            }

            color = new Color(redComponent, greenComponent, blueComponent);
            return true;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Color other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return other._blueValue == _blueValue && other._redValue == _redValue && other._greenValue == _greenValue;
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != typeof (Color))
            {
                return false;
            }
            return Equals((Color) obj);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            unchecked
            {
                int result = _blueValue.GetHashCode();
                result = (result*397) ^ _redValue.GetHashCode();
                result = (result*397) ^ _greenValue.GetHashCode();
                return result;
            }
        }

        /// <summary>
        /// Determines if two operands are equal using the equality operator
        /// </summary>
        /// <param name="left">The first item to compare</param>
        /// <param name="right">The second item to compare</param>
        /// <returns>True if the operands are equal else false</returns>
        public static bool operator ==(Color left, Color right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Determines if two operands are not equal using the inequality operator
        /// </summary>
        /// <param name="left">The first item to compare</param>
        /// <param name="right">The second item to compare</param>
        /// <returns>True if the operands are not equal else false</returns>
        public static bool operator !=(Color left, Color right)
        {
            return !Equals(left, right);
        }
    }
}
