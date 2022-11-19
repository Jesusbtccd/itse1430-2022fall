using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts
{
    public interface IContactDatabase
    {
        Contact Add (Contact c);
        Contact Get (int Id);
        IEnumerable<Contact> GetAll ();
        void Remove (int Id);
        void Update (Contact c);
        
    }
}
