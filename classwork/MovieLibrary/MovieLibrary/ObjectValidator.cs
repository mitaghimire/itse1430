﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieLibrary
{
    //Static class
    // 1. Cannot be instantiated
    // 2. Cannot contain instance members
   public static class ObjectValidator
    {
        //Make static because it doesn't use any instance data
        public static IEnumerable<ValidationResult>TryValidateFullObject (IValidatableObject value)
        {
            var ValidationResults = new List<ValidationResult>();
            Validator.TryValidateObject(value, new ValidationContext(value), ValidationResults, true);

            return ValidationResults;
        }

        public static void ValidateFullObject( IValidatableObject value )
        {
            
            Validator.ValidateObject(value, new ValidationContext(value), true);

        }

    }
}
