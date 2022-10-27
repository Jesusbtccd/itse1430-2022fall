using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    internal class ObjectValidator
    {
        public bool IsValid ( IValidatableObject instance, out string errorMessage)
        {
            var results = new List<ValidationResults>();
            // Validator.TryValidateObject(movie, new ValidationContext(movie), results, true)
            if (Validator.TryValidateObject(movie, new ValidationContext(movie), results, true)
            {
                errorMessage = results[0].ErrorMessage;
                return null;
            };
            errorMessage = null;
            return null;
        }
    }
}
