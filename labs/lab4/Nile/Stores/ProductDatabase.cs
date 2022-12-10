/*Jesus Bustillos
 * ITSE 1430 Fall 2022
 */
using System.ComponentModel.DataAnnotations;

namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {        
        /// <inheritdoc />
        public Product Add ( Product product )
        {
            //TODO: Check arguments

            //TODO: Validate product

            if (product == null)
                throw new ArgumentNullException(nameof(product));

            //IValidatableObject.Validate(product);

            var existing = FindByTitle(product.Name);
            if (existing != null)
                throw new InvalidOperationException("");

            product.OldMethod();



            //Emulate database by storing copy
            return AddCore(product);
        }

        /// <inheritdoc />
        public Product Get ( int id )
        {
            //TODO: Check arguments
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");   //ADDED 1ST

            return GetCore(id);
        }

        /// <inheritdoc />
        public IEnumerable<Product> GetAll ()
        {
            return GetAllCore();
        }

        /// <inheritdoc />
        public void Remove ( int id )
        {
            //TODO: Check arguments
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");   //ADDED 2ND

            RemoveCore(id);
        }

        /// <inheritdoc />
        public Product Update ( int id, Product product )
        {
            //TODO: Check arguments
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");   //ADDED 3RD
            //TODO: Validate product
            if (product == null)
                throw new ArgumentNullException(nameof(product));     //ADDED 4TH
           // IValidatableObject.Validate(product);
               
            //Get existing product
            var existing = GetCore(product.Id);
            if (existing == null)
                throw new ArgumentException("Movie does not exist", nameof(product));


            return UpdateCore(existing, product);
        }

        #region Protected Members

        protected abstract Product GetCore( int id );

        protected abstract IEnumerable<Product> GetAllCore();

        protected abstract void RemoveCore( int id );

        protected abstract Product UpdateCore( Product existing, Product newItem );

        protected abstract Product AddCore( Product product );
        #endregion
        protected abstract Product FindByTitle (string title);
        public Product Update ( Product product ) => throw new NotImplementedException();
    }
}
