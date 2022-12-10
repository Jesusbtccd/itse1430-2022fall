/*Jesus Bustillos
 * ITSE 1430 Fall 2022
 */
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Nile
{
    /// <summary>Represents a product.</summary>
    public class Product : IValidatableObject
    {
        /// <summary>Gets or sets the unique identifier.</summary>
        [Range(0, Int32.MaxValue)]
        public int Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>Never returns null.</value>
        [Required(AllowEmptyStrings = false)]
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value?.Trim(); }
        }
        
        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value?.Trim(); }
        }

        /// <summary>Gets or sets the price.</summary>
        [Range(0, Int32.MaxValue)]

        public decimal Price { get; set; } = 0;      

        /// <summary>Determines if discontinued.</summary>
        public bool IsDiscontinued { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            var results = new List<ValidationResult>();
            {
                Validator.TryValidateProperty(this.Id, new ValidationContext(this, null, null) { MemberName = "Id" }, results);
                Validator.TryValidateProperty(this.Name, new ValidationContext(this, null, null) { MemberName = "Name" }, results);
                Validator.TryValidateProperty(this.Price, new ValidationContext(this, null, null) { MemberName = "Price" }, results);
            }
            return results;
        }

        public static bool IsValid (object instance, out string errorMessage)
        {
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(instance, new ValidationContext(instance), results, true))
            {
                errorMessage = null;
                return false;   
            };
            errorMessage = null;
            return true;
        }

        public static void Validate ( object instance)
        {
            Validator.ValidateObject(instance, new ValidationContext(instance));
        }

        #region Private Members

        private string _name;
        private string _description;
        #endregion
        public void OldMethod ()
        { }
    }
}
