using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public static class ObjectValidator
    {
        //private ObjectValidator() { }

        public static bool IsValid ( object instance, out string errorMessage )
        {
            //var used = _unused;
            //var that = this;

            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(instance, new ValidationContext(instance), results, true))
            {
                errorMessage = results[0].ErrorMessage;
                return false;
            };

            errorMessage = null;
            return true;
        }

        public static void Validate ( object instance )
        {
            Validator.ValidateObject(instance, new ValidationContext(instance), true);
        }

        //private int _unused;
    }
}
//{
//    public static class ObjectValidator
//    {
//        public static bool IsValid ( IValidatableObject instance, out string errorMessage)
//        {
//            var results = new List<ValidationResult>();
//            // Validator.TryValidateObject(movie, new ValidationContext(movie), results, true)
//            if (!Validator.TryValidateObject(instance, new ValidationContext(instance), results, true))
//            {
//                errorMessage = results[0].ErrorMessage;
//                return false;
//            };
//            errorMessage = null;
//            return true;
//        }

//        public static void Validate ( IValidatableObject instance )
//        {
//            Validator.ValidateObject(instance, new ValidationContext(instance), true);
//        }
//    }
//}
