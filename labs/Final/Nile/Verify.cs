/*
 * ITSE 1430
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Nile
{
    /// <summary>Provides extension methods for verifying arguments.</summary>
    public static class Verify
    {
        /// <summary>Verifies an argument is not <see langword="null"/>.</summary>
        /// <param name="name">The argument name.</param>
        /// <param name="value">The value.</param>
        public static void ArgumentIsNotNull ( string name, object value )
        {
            if (value == null)
                throw new ArgumentNullException(name);
        }        

        /// <summary>Verifies an argument is not <see langword="null"/> or empty.</summary>
        /// <param name="name">The argument name.</param>
        /// <param name="value">The value.</param>
        public static void ArgumentIsNotNullOrEmpty ( string name, string value )
        {
            if (value == null)
                throw new ArgumentNullException(name);

            if (String.IsNullOrEmpty(value))
                throw new ArgumentException($"{name} cannot be empty.", name);
        }

        /// <summary>Verifies an argument is within a specific range.</summary>
        /// <param name="name">The argument name.</param>
        /// <param name="value">The value.</param>
        /// <param name="minValue">The minimum value.</param>
        public static void ArgumentIsGreaterThan<T> ( string name, T value, T minValue ) where T : IComparable<T>
        {
            if (value.CompareTo(minValue) <= 0)
                throw new ArgumentOutOfRangeException(name, value, $"{name} must be greater than {minValue}.");
        }

        /// <summary>Verifies an argument is within a specific range.</summary>
        /// <param name="name">The argument name.</param>
        /// <param name="value">The value.</param>
        /// <param name="minValue">The minimum allowed value.</param>
        public static void ArgumentIsGreaterThanOrEqualTo<T> ( string name, T value, T minValue ) where T: IComparable<T>
        {
            if (value.CompareTo(minValue) < 0)
                throw new ArgumentOutOfRangeException(name, value, $"{name} must be greater than or equal to {minValue}.");
        }

        /// <summary>Verifies an argument is within a specific range.</summary>
        /// <param name="name">The argument name.</param>
        /// <param name="value">The value.</param>
        /// <param name="minValue">The minimum allowed value.</param>
        /// <param name="maxValue">The maximum allowed value.</param>
        public static void ArgumentIsBetween<T> ( string name, T value, T minValue, T maxValue ) where T : IComparable<T>
        {
            if (value.CompareTo(minValue) < 0 || value.CompareTo(maxValue) > 0)
                throw new ArgumentOutOfRangeException(name, value, $"{name} must be between {minValue} and {maxValue}.");
        }

        /// <summary>Verifies an argument is within a specific range.</summary>
        /// <param name="name">The argument name.</param>
        /// <param name="value">The value.</param>
        /// <param name="maxValue">The maximum value.</param>
        public static void ArgumentIsLessThan<T> ( string name, T value, T maxValue ) where T : IComparable<T>
        {
            if (value.CompareTo(maxValue) >= 0)
                throw new ArgumentOutOfRangeException(name, value, $"{name} must be less than {maxValue}.");
        }

        /// <summary>Verifies an argument is within a specific range.</summary>
        /// <param name="name">The argument name.</param>
        /// <param name="value">The value.</param>
        /// <param name="maxValue">The maximum allowed value.</param>
        public static void ArgumentIsLessThanOrEqualTo<T> ( string name, T value, T maxValue ) where T : IComparable<T>
        {
            if (value.CompareTo(maxValue) > 0)
                throw new ArgumentOutOfRangeException(name, value, $"{name} must be less than or equal to {maxValue}.");
        }

        /// <summary>Verifies an argument is not <see langword="null"/> and valid.</summary>
        /// <param name="name">The argument name.</param>
        /// <param name="value">The value.</param>
        public static void ArgumentIsValidAndNotNull ( string name, IValidatableObject value )
        {
            if (value == null)
                throw new ArgumentNullException(name);

            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(value, new ValidationContext(value), results, true))
                throw new ValidationException(results.FirstOrDefault(), null, null);
        }
    }
}
