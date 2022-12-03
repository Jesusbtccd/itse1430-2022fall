using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts
{
    public class ContactDatabase : IContactDatabase
    {
        int _Id=1;
        List<Contact> _contacts = new List<Contact>();

        public Contact Add (Contact c)
        {
            c.ContactId = _Id++;
            _contacts.Add(c);
            return c;
        }
        public Contact Get ( int Id )
        {
            return _contacts.FirstOrDefault(x => x.ContactId == Id);
        }
        public IEnumerable<Contact> GetAll ()
        {
            return from contact in _contacts
                   select contact;
  
        }
        public void Remove ( int Id)
        {
            var oldContact = FindById(Id);
            if (oldContact != null)
                _contacts.Remove(oldContact);
        }
        public void Update (Contact c)
        {
            var contact = FindById(_Id);
            if (contact == null)
                return;
        }
         private Contact FindById (int Id)
        {
            return _contacts.FirstOrDefault(x => x.ContactId == Id);
        }


        

    }
}
