namespace Contacts
{
    public class Contact : IContactDatabase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public bool IsFavorite { get; set; }
        public int ContactId { get; set; }

        Contact Add ( Contact c ) { return c; }



    }


}