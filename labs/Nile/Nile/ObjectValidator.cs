using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile
{
    public static class ObjectValidator
    {
       
        public static IEnumerable<ValidationResult> TryValidateFullObject(IValidatableObject value)
        {
            var ValidationResults = new List<ValidationResult>();
            Validator.TryValidateObject(value, new ValidationContext(value), ValidationResults, true);

            return ValidationResults;
        }

        public static void ValidateFullObject(IValidatableObject value)
        {

            Validator.ValidateObject(value, new ValidationContext(value), true);

        }

        internal static void ValidateFullObject(Product product)
        {
            throw new NotImplementedException();
        }
    }
   
}
