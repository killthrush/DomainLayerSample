using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Domain.Exceptions;

namespace Domain.Base
{
    /// <summary>
    /// Value object that indicates an address
    /// </summary>
    public class Address : IEquatable<Address>
    {
        /// <summary>
        /// Contains a list of state information
        /// </summary>
        private static readonly IDictionary<string, string> StateList = new Dictionary<string, string>();

        /// <summary>
        /// The street address, limited to 100 characters
        /// </summary>
        public string Street { get; private set; }

        /// <summary>
        /// The optional unit number, limited to 5 characters
        /// </summary>
        public string Unit { get; private set; }

        /// <summary>
        /// The city, limited to 50 characters
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// The state, limited to 2 characters
        /// </summary>
        public string State { get; private set; }

        /// <summary>
        /// The zip code, limited to 5 numeric characters
        /// </summary>
        public string Zip { get; private set; }

        /// <summary>
        /// Initializes a new instance of the Address class.
        /// </summary>
        /// <param name="street">The street address, limited to 100 characters</param>
        /// <param name="unit">The optional unit number, limited to 5 characters</param>
        /// <param name="city">The city, limited to 50 characters</param>
        /// <param name="state">The state, limited to 2 characters</param>
        /// <param name="zip">The zip code, limited to 5 numeric characters</param>
        public Address(string street, string unit, string city, string state, string zip)
        {
            string normalizedState = state != null ? state.ToUpper() : null;
            ValidateAddress(street, unit, city, normalizedState, zip);

            Street = street;
            Unit = unit;
            City = city;
            State = normalizedState;
            Zip = zip;
        }

        /// <summary>
        /// Initializes static members of the Address class.
        /// </summary>
        static Address()
        {
            StateList.Add("AL", "Alabama");
            StateList.Add("AK", "Alaska");
            StateList.Add("AZ", "Arizona");
            StateList.Add("AR", "Arkansas");
            StateList.Add("CA", "California");
            StateList.Add("CO", "Colorado");
            StateList.Add("CT", "Connecticut");
            StateList.Add("DE", "Delaware");
            StateList.Add("DC", "District of Columbia");
            StateList.Add("FL", "Florida");
            StateList.Add("GA", "Georgia");
            StateList.Add("HI", "Hawaii");
            StateList.Add("ID", "Idaho");
            StateList.Add("IL", "Illinois");
            StateList.Add("IN", "Indiana");
            StateList.Add("IA", "Iowa");
            StateList.Add("KS", "Kansas");
            StateList.Add("KY", "Kentucky");
            StateList.Add("LA", "Louisiana");
            StateList.Add("ME", "Maine");
            StateList.Add("MD", "Maryland");
            StateList.Add("MA", "Massachusetts");
            StateList.Add("MI", "Michigan");
            StateList.Add("MN", "Minnesota");
            StateList.Add("MS", "Mississippi");
            StateList.Add("MO", "Missouri");
            StateList.Add("MT", "Montana");
            StateList.Add("NE", "Nebraska");
            StateList.Add("NV", "Nevada");
            StateList.Add("NH", "New Hampshire");
            StateList.Add("NJ", "New Jersey");
            StateList.Add("NM", "New Mexico");
            StateList.Add("NY", "New York");
            StateList.Add("NC", "North Carolina");
            StateList.Add("ND", "North Dakota");
            StateList.Add("OH", "Ohio");
            StateList.Add("OK", "Oklahoma");
            StateList.Add("OR", "Oregon");
            StateList.Add("PA", "Pennsylvania");
            StateList.Add("RI", "Rhode Island");
            StateList.Add("SC", "South Carolina");
            StateList.Add("SD", "South Dakota");
            StateList.Add("TN", "Tennessee");
            StateList.Add("TX", "Texas");
            StateList.Add("UT", "Utah");
            StateList.Add("VT", "Vermont");
            StateList.Add("VA", "Virginia");
            StateList.Add("WA", "Washington");
            StateList.Add("WV", "West Virginia");
            StateList.Add("WI", "Wisconsin");
            StateList.Add("WY", "Wyoming");
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Address other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(other.Street, Street) && Equals(other.Unit, Unit) && Equals(other.City, City) && Equals(other.State, State) && Equals(other.Zip, Zip);
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
            if (obj.GetType() != typeof (Address))
            {
                return false;
            }
            return Equals((Address) obj);
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
                int result = (Street != null ? Street.GetHashCode() : 0);
                result = (result*397) ^ (Unit != null ? Unit.GetHashCode() : 0);
                result = (result*397) ^ (City != null ? City.GetHashCode() : 0);
                result = (result*397) ^ (State != null ? State.GetHashCode() : 0);
                result = (result*397) ^ (Zip != null ? Zip.GetHashCode() : 0);
                return result;
            }
        }

        /// <summary>
        /// Determines if two operands are equal using the equality operator
        /// </summary>
        /// <param name="left">The first item to compare</param>
        /// <param name="right">The second item to compare</param>
        /// <returns>True if the operands are equal else false</returns>
        public static bool operator ==(Address left, Address right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Determines if two operands are not equal using the inequality operator
        /// </summary>
        /// <param name="left">The first item to compare</param>
        /// <param name="right">The second item to compare</param>
        /// <returns>True if the operands are not equal else false</returns>
        public static bool operator !=(Address left, Address right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        /// Runs validation logic on the address components
        /// </summary>
        /// <param name="street">The street address, limited to 100 characters</param>
        /// <param name="unit">The optional unit number, limited to 5 characters</param>
        /// <param name="city">The city, limited to 50 characters</param>
        /// <param name="state">The state, limited to 2 characters</param>
        /// <param name="zip">The zip code, limited to 5 numeric characters</param>
        private void ValidateAddress(string street, string unit, string city, string state, string zip)
        {
            if (street == null || city == null || state == null || zip == null)
            {
                throw new BuildingCodeException("The street, city, state, and zip must be specified for a valid address.");
            }

            if (!StateList.ContainsKey(state))
            {
                throw new BuildingCodeException(string.Format("The state code '{0}' is not valid.", state));
            }

            if (street.Length > 100)
            {
                throw new BuildingCodeException(string.Format("The street '{0}' is too long to be processed.", street));
            }

            if (unit != null && unit.Length > 5)
            {
                throw new BuildingCodeException(string.Format("The unit '{0}' is too long to be processed.", unit));
            }

            if (city.Length > 50)
            {
                throw new BuildingCodeException(string.Format("The city '{0}' is too long to be processed.", city));
            }

            if (zip.Length != 5 || !Regex.IsMatch(zip, @"^\d{5}$"))
            {
                throw new BuildingCodeException(string.Format("The zip '{0}' is not valid.", zip));
            }
        }
    }
}