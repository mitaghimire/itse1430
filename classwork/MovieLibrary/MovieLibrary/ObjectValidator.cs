using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieLibrary
{
   public  class ObjectValidator
    {
        public IEnumerable<ValidationResult>TryValidateFullObject (IValidatableObject value)
        {
            var ValidationResults = new List<ValidationResult>();
            Validator.TryValidateObject(value, new ValidationContext(value), ValidationResults, true);

            return ValidationResults;
        }

        public void ValidateFullObject( IValidatableObject value )
        {
            
            Validator.ValidateObject(value, new ValidationContext(value), true);

        }

    }
}
