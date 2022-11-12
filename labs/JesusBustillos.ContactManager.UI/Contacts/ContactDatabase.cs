using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts
{
    public class ContactDatabase : IContactDatabase
    {
        public Contact Add (Contact c)
        {
            return c;
        }
        public Contact Get ( int Id )
        {
            Contact c = null;
            return (c);
        }
        public IEnumerable<Contact> GetAll ()
        {
            return GetAll();
        }
        public void Remove ( int Id )
        {
            Remove(Id);
        }
        public void Update (Contact c)
        {
            Update(c);
        }
        

        

    }
}
